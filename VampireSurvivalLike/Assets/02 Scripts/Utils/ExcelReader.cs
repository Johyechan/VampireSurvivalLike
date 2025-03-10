using UnityEngine;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System;
using MySO;
using MyEnum;

public class ExcelReader : MonoBehaviour
{
    private List<string> _excelList = new List<string>();

    private List<ItemSO> _itemSOList = new List<ItemSO>();
    public List<ItemSO> ItemSOList { get { return _itemSOList; } }

    private string _itemLevel;

    private bool _isEnded = false;
    public bool IsEnded { get { return _isEnded; } }

    public void ReadExcel(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Debug.LogError("파일 경로가 잘못되었거나 존재하지 않습니다");
            _isEnded = false;
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
                    _excelList.Clear();
                    ICell itemLevelCell = currentRow.GetCell(1);
                    if(itemLevelCell != null && itemLevelCell.ToString() != "")
                    {
                        _itemLevel = itemLevelCell.ToString();
                    }
                    // 각 행의 모든 셀을 순회
                    for(int col = 0; col < currentRow.LastCellNum; col++)
                    {
                        ICell cell = currentRow.GetCell(col);
                        string cellValue;
                        if (cell != null)
                        {
                            cellValue = cell.ToString();
                            if(cellValue == "")
                            {
                                cellValue = "0";
                            }
                        }
                        else
                        {
                            cellValue = "0";
                        }
                        _excelList.Add(cellValue);
                    }
                    MakeSO();
                }
            }
        }

        _isEnded = true;
        return;
    }

    private void MakeSO()
    {
        ItemSO newSO = ScriptableObject.CreateInstance<MySO.ItemSO>(); // 네임스페이스를 추가해서 적용해야됨

        if (_excelList[2] == "0" || _excelList[2] == "No" || _excelList[2] == "")
        {
            return;
        }
        newSO.itemLevel = _itemLevel;
        //Debug.Log($"{i}: {_excelList[i]}");
        for (int i = 2; i < _excelList.Count; i++)
        {
            switch (i)
            {
                case 2:
                    newSO.no = _excelList[i];
                    break;
                case 3:
                    newSO.itemName = _excelList[i];
                    newSO.name = _excelList[i];
                    break;
                case 6:
                    newSO.role = (RoleType)Enum.Parse(typeof(RoleType), _excelList[i]);
                    break;
                case 7:
                    newSO.attackDamage = float.Parse(_excelList[i]);
                    break;
                case 8:
                    newSO.abilityPower = float.Parse(_excelList[i]);
                    break;
                case 9:
                    newSO.soulPower = float.Parse(_excelList[i]);
                    break;
                case 10:
                    newSO.range = float.Parse(_excelList[i]);
                    break;
                case 11:
                    newSO.accuracyRate = float.Parse(_excelList[i]) * 100.0f;
                    break;
                case 12:
                    newSO.avoidanceRate = float.Parse(_excelList[i]) * 100.0f;
                    break;
                case 13:
                    newSO.criticalHitRate = float.Parse(_excelList[i]) * 100.0f;
                    break;
                case 14:
                    newSO.attackSpeed = float.Parse(_excelList[i]) * 100.0f;
                    break;
                case 15:
                    newSO.speedIncrease = float.Parse(_excelList[i]) * 100.0f;
                    break;
                case 16:
                    newSO.defence = float.Parse(_excelList[i]);
                    break;
                case 17:
                    newSO.health = float.Parse(_excelList[i]);
                    break;
                case 18:
                    newSO.mana = float.Parse(_excelList[i]);
                    break;
                case 19:
                    newSO.soul = float.Parse(_excelList[i]);
                    break;
                case 20:
                    _excelList[i] = _excelList[i].Replace("초당", "");
                    newSO.healingCost = float.Parse(_excelList[i]);
                    break;
                case 21:
                    newSO.manaCost = float.Parse(_excelList[i]);
                    break;
                case 22:
                    newSO.healingSteal = float.Parse(_excelList[i]);
                    break;
                case 23:
                    newSO.manaSteal = float.Parse(_excelList[i]);
                    break;
                case 24:
                    newSO.healingFactor = float.Parse(_excelList[i]);
                    break;
                case 25:
                    newSO.manaFactor = float.Parse(_excelList[i]);
                    break;
                case 27:
                    newSO.price = int.Parse(_excelList[i]);
                    break;
                default:
                    break;
            }
        }
        _itemSOList.Add(newSO);
    }
}
