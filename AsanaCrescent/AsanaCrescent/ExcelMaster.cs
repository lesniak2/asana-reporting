using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;
using Microsoft.VisualBasic;
using AsanaNet;

namespace AsanaCrescent
{
    class ExcelMaster
    {
        private Excel.Application oXL;
        private Excel._Workbook oWB;
        private Excel.Sheets sheets;
        private int[] currentRow;
        private string[,] ColumnNames;
        private int validWorksheets;
        private Dictionary<string, int> ProjectWorksheetDictionary;
        public ExcelMaster()
        {
            oXL = new Excel.Application();
            oWB = (Excel.Workbook)(oXL.Workbooks.Add(Missing.Value));
            ProjectWorksheetDictionary = new Dictionary<string,int>();
            sheets = oWB.Sheets;
        }
        public void SetWorksheets(ArrayList projects)
        {
            ProjectWorksheetDictionary.Clear();
            int worksheetsToAdd = projects.Count -3 <= 0 ? 0 : projects.Count -3;
            currentRow = new int[projects.Count+1];
            validWorksheets = projects.Count;
                for (int i = 0; i < currentRow.Length ; i++)
                {
                    currentRow[i] = 2;
                }
                for (int i = 0; i < worksheetsToAdd; i++)
                {
                    sheets.Add(Type.Missing, sheets[sheets.Count], Type.Missing, Type.Missing);
                }
                    for (int i = 1; i < projects.Count + 1; i++)
                    {
                        string col_name = (projects[i - 1] as AsanaProject).Name;
                        col_name = col_name.Replace(":", "");
                        col_name = col_name.Replace("/", " ");
                        col_name = col_name.Replace("\\", " ");
                        sheets[i].Name = col_name;
                        ProjectWorksheetDictionary.Add(col_name,i);
                    }
                    ColumnNames = new string[projects.Count + 1, 20];
        }
        public void AddRow(string[] arr, string worksheet)
        {
            int worksheetNum = ProjectWorksheetDictionary[worksheet];
                Excel.Worksheet oSheet = (Excel.Worksheet) sheets[worksheetNum];
                char startCol = 'A';
                char endCol = (char)(startCol + arr.Length - 1);
                oSheet.get_Range("" + startCol + currentRow[worksheetNum], "" + endCol + currentRow[worksheetNum]).Value2 = arr;
                currentRow[worksheetNum]++;
        }
        public void SetColumns(string[] col, string worksheetName)
        {
            int i;
            for (i = 1; i <= sheets.Count && worksheetName != sheets[i].Name; i++)
                ;
            Excel.Worksheet oSheet = (Excel.Worksheet)sheets[i];
            char titleCol = 'A';
            char endtitleCol = (char)(titleCol + col.Length - 1);
            oSheet.get_Range(titleCol + "1", endtitleCol + "1").Value2 = col;
            oSheet.Application.ActiveWindow.SplitRow = 1;
            oSheet.Application.ActiveWindow.FreezePanes = true;
            
            for (int j = 0; j < col.Length; j++)
            {
                ColumnNames[i,j] = col[j];
                    
            }
        }

        public void Show()
        {
            oXL.Visible = true;
        }

        public string[] GetColumnNames(string worksheet)
        {
            int worksheetNum = ProjectWorksheetDictionary[worksheet];
            string[] data = new string[20];
            for(int i = 0; i < data.Length; i++)
                data[i] = ColumnNames[worksheetNum, i];
            return data;
        }

        public void ClearWorksheets()
        {
            sheets.Delete();
        }
        public void SaveAndClose()
        {
            try
            {
                FileSystem.MkDir("reports");
            }
            catch (System.IO.IOException) { }
            finally
            {
                string name = "asana_report_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "").Replace(".", "").Replace("/", "");
                name = name.Remove(name.Length - 3);
                oWB.SaveAs(System.IO.Directory.GetCurrentDirectory() + "\\reports\\" + name + ".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);
                oWB.Close();
                oXL.Quit();
                releaseObject(oXL);
                releaseObject(oWB);
                releaseObject(sheets);
            }
        }
        public void CloseWithoutSaving()
        {
            oWB.Close(false);
            oXL.Quit();
            releaseObject(oXL);
            releaseObject(oWB);
            releaseObject(sheets);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        public void MakeWorksheetsTables()
        {
            for (int i = 0; i < validWorksheets; i++)
            {
                Excel.Worksheet CurrentWorksheet = (Excel.Worksheet)sheets[i+1];
                int LastRow = currentRow[i+1]; // -1
                string LastCol = "U";
                Excel.Range tRange = CurrentWorksheet.get_Range("A1", LastCol + LastRow);
                CurrentWorksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, tRange,
                Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "Test Table";
                CurrentWorksheet.ListObjects["Test Table"].TableStyle = "TableStyleMedium3";
            }
        }
    }
}
 