#if UNITY_EDITOR
using Manager;
using MySO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerSO))]
public class PlayerSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerSO playerSO = (PlayerSO)target;

        EditorGUILayout.LabelField("BackpackArr", EditorStyles.boldLabel);

        if (playerSO.backpackArr != null)
        {
            for(int i = 0; i < 6; i++)
            {
                GUILayout.BeginHorizontal();

                for(int j = 0; j < 9; j++)
                {
                    playerSO.backpackArr[j, i] = EditorGUILayout.IntField(playerSO.backpackArr[j, i]);
                }

                GUILayout.EndHorizontal();
            }
        }

        if(GUI.changed)
        {
            playerSO.SaveBackpackArr();
            EditorUtility.SetDirty(playerSO);
            AssetDatabase.SaveAssets();
        }

        DrawDefaultInspector();
    }
}
#endif
