#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExcelReader))]
public class ExcelReadEditor : Editor
{
    ExcelReader script;

    string filePath = Application.dataPath + "/06 Excel/TBG_Sheet 250224.xlsx";

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();  // 기존 인스펙터 UI 유지

        script = (ExcelReader)target;

        if (GUILayout.Button("Read Excel and Make SO"))
        {
            script.ItemSOList.Clear();
            script.ReadExcel(filePath);

            EditorApplication.update += Loading;
        }
    }

    private void Loading()
    {
        if (script.IsEnded)
        {
            EditorApplication.update -= Loading;

            foreach (var so in script.ItemSOList)
            {
                string itemLevelFolderPath = "Assets/05 SOs/Item/" + so.itemLevel;
                string roleFolderPath = itemLevelFolderPath + "/" + so.role.ToString();

                if (!AssetDatabase.IsValidFolder(itemLevelFolderPath))
                {
                    AssetDatabase.CreateFolder("Assets/05 SOs/Item", so.itemLevel);
                }

                if (!AssetDatabase.IsValidFolder(roleFolderPath))
                {
                    AssetDatabase.CreateFolder(itemLevelFolderPath, so.role.ToString());
                }

                string assetPath = roleFolderPath + "/" + so.itemName + ".asset";
                AssetDatabase.CreateAsset(so, assetPath);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = so;

                //Debug.Log($"{so.itemName} SO 만들기 성공");
            }
        }
    }
}
#endif