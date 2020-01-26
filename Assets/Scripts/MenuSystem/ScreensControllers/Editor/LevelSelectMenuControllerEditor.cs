using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LevelSelectionController))]
public class LevelSelectMenuControllerEditor : Editor
{
    LevelSelectionController _lsm;

    private void OnEnable()
    {
        _lsm = (LevelSelectionController)target;
    }

    public override void OnInspectorGUI()
    {
        //Controller texture
        Texture t = (Texture)Resources.Load("EditorContent/LevelSelectMenu-icon");
        GUILayout.Box(t, GUILayout.ExpandWidth(true));

        EditorGUILayout.BeginVertical("Box");

        DrawDefaultInspector();

        EditorGUILayout.EndVertical();

        DrawLevelsList();
    }

    void DrawLevelsList()
    {
        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.HelpBox("Add new Level Entry by pressing the Add button. \n" +
                                "> Level Title : Title which will be displayed on top. \n" +
                                "> Level Description : Some Description of your level. \n" +
                                "> Scene To Load : Which scene will be loaded by this level. \n" +
                                "> Level Sprite : Sprite which will be shown in the level select menu", MessageType.Info);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            AllLevelsData ald = new AllLevelsData();
            _lsm.AllLevelsData.Add(ald);
        }

        if (GUILayout.Button("Clear"))
        {
            _lsm.AllLevelsData.Clear();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();

        for (int i = 0; i < _lsm.AllLevelsData.Count; i++)
        {

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.BeginHorizontal();
            string LevelTitle = EditorGUILayout.TextField("Level Title", _lsm.AllLevelsData[i].LevelTitle);
            if (GUILayout.Button("X", GUILayout.Width(35)))
            {
                _lsm.AllLevelsData.RemoveAt(i);
                break;
            }
            EditorGUILayout.EndHorizontal();
            string LevelDescription = EditorGUILayout.TextField("Level Description", _lsm.AllLevelsData[i].LevelDescription);
            string SceneToLoad = EditorGUILayout.TextField("Scene To Load", _lsm.AllLevelsData[i].SceneToLoad);
            bool isLocked = EditorGUILayout.Toggle("Is locked level", _lsm.AllLevelsData[i].isLocked);
            Sprite LevelSprite = (Sprite)EditorGUILayout.ObjectField("Level Sprite", _lsm.AllLevelsData[i].LevelSprite, typeof(Sprite),true);
    

            EditorGUILayout.EndVertical();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Level Select Manager EMM");

                _lsm.AllLevelsData[i].LevelTitle = LevelTitle;
                _lsm.AllLevelsData[i].LevelDescription = LevelDescription;
                _lsm.AllLevelsData[i].SceneToLoad = SceneToLoad;
                _lsm.AllLevelsData[i].isLocked = isLocked;
                _lsm.AllLevelsData[i].LevelSprite = LevelSprite;
            }

        }


    }
}
