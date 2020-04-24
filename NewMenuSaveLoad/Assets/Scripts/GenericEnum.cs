using System;
using System.Collections.Generic;
using System.Reflection;

public abstract class GenericEnum<T, TU> where T : GenericEnum<T, TU>, new()
{
    static readonly List<string> names;

    static readonly List<TU> values;

    static bool allowInstanceExceptions;

    static GenericEnum()
    {
        Type t = typeof(T);
        Type u = typeof(TU);
        if (t == u) throw new InvalidOperationException(String.Format("{0} and its underlying type cannot be the same", t.Name));
        BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
        FieldInfo[] fia = t.GetFields(bf);
        names = new List<string>();
        values = new List<TU>();
        for (int i = 0; i < fia.Length; i++)
        {
            if (fia[i].FieldType == u && (fia[i].IsLiteral || fia[i].IsInitOnly))
            {
                names.Add(fia[i].Name);
                values.Add((TU)fia[i].GetValue(null));
            }
        }
        if (names.Count == 0) throw new InvalidOperationException(String.Format("{0} has no suitable fields", t.Name));
    }

    public static bool AllowInstanceExceptions
    {
        get { return allowInstanceExceptions; }
        set { allowInstanceExceptions = value; }
    }

    public static string[] GetNames()
    {
        return names.ToArray();
    }

    public static string[] GetNames(TU value)
    {
        List<string> nameList = new List<string>();
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].Equals(value)) nameList.Add(names[i]);
        }
        return nameList.ToArray();
    }

    public static TU[] GetValues()
    {
        return values.ToArray();
    }

    public static int[] GetIndices(TU value)
    {
        List<int> indexList = new List<int>();
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].Equals(value)) indexList.Add(i);
        }
        return indexList.ToArray();
    }

    public static int IndexOf(string name)
    {
        return names.IndexOf(name);
    }

    public static TU ValueOf(string name)
    {
        int index = names.IndexOf(name);
        if (index >= 0)
        {
            return values[index];
        }
        throw new ArgumentException(String.Format("'{0}' is not a defined name of {1}", name, typeof(T).Name));
    }

    public static string FirstNameWith(TU value)
    {
        int index = values.IndexOf(value);
        if (index >= 0)
        {
            return names[index];
        }
        throw new ArgumentException(String.Format("'{0}' is not a defined value of {1}", value, typeof(T).Name));
    }

    public static int FirstIndexWith(TU value)
    {
        int index = values.IndexOf(value);
        if (index >= 0)
        {
            return index;
        }
        throw new ArgumentException(String.Format("'{0}' is not a defined value of {1}", value, typeof(T).Name));
    }

    public static string NameAt(int index)
    {
        if (index >= 0 && index < Count)
        {
            return names[index];
        }
        throw new IndexOutOfRangeException(String.Format("Index must be between 0 and {0}", Count - 1));
    }

    public static TU ValueAt(int index)
    {
        if (index >= 0 && index < Count)
        {
            return values[index];
        }
        throw new IndexOutOfRangeException(String.Format("Index must be between 0 and {0}", Count - 1));
    }

    public static Type UnderlyingType
    {
        get { return typeof(TU); }
    }

    public static int Count
    {
        get { return names.Count; }
    }

    public static bool IsDefinedName(string name)
    {
        if (names.IndexOf(name) >= 0) return true;
        return false;
    }

    public static bool IsDefinedValue(TU value)
    {
        if (values.IndexOf(value) >= 0) return true;
        return false;
    }

    public static bool IsDefinedIndex(int index)
    {
        if (index >= 0 && index < Count) return true;
        return false;
    }

    public static T ByName(string name)
    {
        if (!IsDefinedName(name))
        {
            if (allowInstanceExceptions) throw new ArgumentException(String.Format("'{0}' is not a defined name of {1}", name, typeof(T).Name));
            return null;
        }
        T t = new T();
        t._index = names.IndexOf(name);
        return t;
    }

    public static T ByValue(TU value)
    {
        if (!IsDefinedValue(value))
        {
            if (allowInstanceExceptions) throw new ArgumentException(String.Format("'{0}' is not a defined value of {1}", value, typeof(T).Name));
            return null;
        }
        T t = new T();
        t._index = values.IndexOf(value);
        return t;
    }

    public static T ByIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            if (allowInstanceExceptions) throw new ArgumentException(String.Format("Index must be between 0 and {0}", Count - 1));
            return null;
        }
        T t = new T();
        t._index = index;
        return t;
    }

    protected int _index;

    public int Index
    {
        get { return _index; }
        set
        {
            if (value < 0 || value >= Count)
            {
                if (allowInstanceExceptions) throw new ArgumentException(String.Format("Index must be between 0 and {0}", Count - 1));
                return;
            }
            _index = value;
        }
    }

    public string Name
    {
        get { return names[_index]; }
        set
        {
            int index = names.IndexOf(value);
            if (index == -1)
            {
                if (allowInstanceExceptions) throw new ArgumentException(String.Format("'{0}' is not a defined name of {1}", value, typeof(T).Name));
                return;
            }
            _index = index;
        }
    }

    public TU Value
    {
        get { return values[_index]; }
        set
        {
            int index = values.IndexOf(value);
            if (index == -1)
            {
                if (allowInstanceExceptions) throw new ArgumentException(String.Format("'{0}' is not a defined value of {1}", value, typeof(T).Name));
                return;
            }
            _index = index;
        }
    }
 
    public override string ToString()
    {
        return names[_index];
    }
}