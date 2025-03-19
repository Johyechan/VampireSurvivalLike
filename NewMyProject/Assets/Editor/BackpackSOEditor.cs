using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BackpackSO))]
public class BackpackSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BackpackSO backpackSO = target as BackpackSO;

        EditorGUILayout.LabelField("BackpackArr", EditorStyles.boldLabel);

        if(backpackSO != null)
        {
            if(backpackSO.backpackArr != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    GUILayout.BeginHorizontal();

                    for (int j = 0; j < 9; j++)
                    {
                        backpackSO.backpackArr[j, i] = EditorGUILayout.IntField(backpackSO.backpackArr[j, i]);
                    }

                    GUILayout.EndHorizontal();
                }
            }
        }

        if (GUI.changed)
        {
            backpackSO.SaveBackpackArr();
            EditorUtility.SetDirty(backpackSO);
            AssetDatabase.SaveAssets();
        }

        DrawDefaultInspector();
    }
}
