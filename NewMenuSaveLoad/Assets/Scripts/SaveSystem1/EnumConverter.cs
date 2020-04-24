using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;        
using System.Reflection;

#region Menu Enums

public enum GrapicsSettings { VeryLow, Low, Medium, High, VeryHigh, Ultra };


public enum TextureQuality { Full_res, Half_res, Quarter_res, Eighth_res }
public enum AntiAliasing { Disabled, X2, X4, X8 }

public enum VSyncCount { Dont_Sync,Every_V_Blank,Every_Second_V_Blank}
#endregion

#region Game Slots Enum
/// <summary>
/// GameSlots Enums
/// </summary>
public enum GameDifficulty {None=0, 
    Easy=1, 
    Normal=2, 
    Hard=3, 
    VeryHard=4, 
    Extreme=5 }
public enum TypeOfSavedGameSlot { Checkpoint, Manual_Save_Slot ,None}
#endregion



public class GameDifficultyEnum : GenericEnum<GameDifficultyEnum, int>
{
    public static readonly string Easy = "Easy";
}
#region Class EnumsConverter
/// <summary>
/// Static class for Convert enum keys and values to NameArray,ValueArray, ListOfValues, ToEumerable 
/// </summary>
public static class EnumConverter
{
    /// <summary>
    /// Converts Enum T to array with the names of Enum T
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Array of strings</returns>
    public static string[] ToNameArray<T>()
    {
        return Enum.GetNames(typeof(T)).ToArray();
    }
    /// <summary>
    /// Converts Enum T to array with the values of Enum T :[ 1,2,3..]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns> Array of numbers </returns>
    public static Array ToValueArray<T>()
    {
        return Enum.GetValues(typeof(T));
    }
    /// <summary>
    /// Converts Enum T to List with the values of Enum T List of [1,2,3..]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>List<T></returns>
    public static List<T> ToListOfValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }

    /// <summary>
    /// Converts Enum T to Enumerable with the Values of Enum T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Enumerable</returns>
    public static IEnumerable<T> ToEnumerable<T>()
    {
        return (T[])Enum.GetValues(typeof(T));
    }
  
    
}
[AttributeUsage(AttributeTargets.Field)]
public class ExtensionTest : Attribute
{
    private string m_name;
    public ExtensionTest(string name)
    {
        this.m_name = name;
    }
    public static string Set(Type tp, string name)
    {
        MemberInfo[] mi = tp.GetMember(name);
        if (mi != null && mi.Length > 0)
        {
            ExtensionTest attr = Attribute.GetCustomAttribute(mi[0],
                typeof(ExtensionTest)) as ExtensionTest;
            if (attr != null)
            {
                return attr.m_name;
            }
        }
        return null;
    }
    public static string Get(object enm)
    {
        if (enm != null)
        {
            MemberInfo[] mi = enm.GetType().GetMember(enm.ToString());
            if (mi != null && mi.Length > 0)
            {
                ExtensionTest attr = Attribute.GetCustomAttribute(mi[0],
                    typeof(ExtensionTest)) as ExtensionTest;
                if (attr != null)
                {
                    return attr.m_name;
                }
            }
        }
        return null;
    }
}
public enum EnumTest
{
    None,
    [ExtensionTest("(")] Left,
    [ExtensionTest(")")] Right,
}

#endregion