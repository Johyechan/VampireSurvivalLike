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
            Debug.LogError("���� ��ΰ� �߸��Ǿ��ų� �������� �ʽ��ϴ�");
            return;
        }
        
        // ���� ��Ʈ���� ��� �д´�
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            // .xlsx�� ���� ���� Workbook�� ����Ѵ�
            IWorkbook workbook = new XSSFWorkbook(stream);
            // ù ��° ��Ʈ�� �����´� (0�� �ε���)
            ISheet sheet = workbook.GetSheetAt(0);

            // �� - ���ں��� ������ ��
            // �� - �������� �Ʒ� ��
            // ��� ���� ��ȸ
            for(int row = 0; row < sheet.LastRowNum; row++)
            {
                IRow currentRow = sheet.GetRow(row);
                if(currentRow != null)
                {
                    // �� ���� ��� ���� ��ȸ
                    for(int col = 0; col < currentRow.LastCellNum; col++)
                    {
                        ICell cell = currentRow.GetCell(col);
                        if(cell != null)
                        {
                            string cellValue = cell.ToString();
                            Debug.Log($"{row}��, {col}��: {cellValue}");
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
