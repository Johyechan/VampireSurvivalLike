using UnityEngine;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

public class ExcelReader : MonoBehaviour
{
    void Start()
    {
        string filePath = Application.dataPath + "/06 Excels/TBG_Sheet 250224.xlsx";
        ReadExcel(filePath);
    }

    private void ReadExcel(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Debug.LogError("파일 경로가 잘못되었거나 존재하지 않습니다");
            return;
        }
        
        // 파일 스트림을 열어서 읽는다
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            // .xlsx를 읽을 때는 Workbook을 사용한다
            IWorkbook workbook = new XSSFWorkbook(stream);
            // 첫 번째 시트를 가져온다 (0번 인덱스)
            ISheet sheet = workbook.GetSheetAt(0);

            // 행 - 숫자부터 오른쪽 줄
            // 열 - 영문부터 아래 줄
            // 모든 행을 순회
            for(int row = 0; row < sheet.LastRowNum; row++)
            {
                IRow currentRow = sheet.GetRow(row);
                if(currentRow != null)
                {
                    // 각 행의 모든 셀을 순회
                    for(int col = 0; col < currentRow.LastCellNum; col++)
                    {
                        ICell cell = currentRow.GetCell(col);
                        if(cell != null)
                        {
                            string cellValue = cell.ToString();
                            Debug.Log($"{row}행, {col}열: {cellValue}");
                        }
                    }
                }
            }
        }
    }
    
    void Update()
    {
        
    }
}
