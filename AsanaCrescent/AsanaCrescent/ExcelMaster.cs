using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;
using AsanaNet;

namespace AsanaCrescent
{
    /// <summary>
    /// A very simple Asana to Excel library.
    /// </summary>
    class ExcelMaster
    {
        public ExcelMaster()
        {
            oXL = new Excel.Application();
            oWB = (Excel.Workbook)(oXL.Workbooks.Add(Missing.Value));
            ProjectWorksheetDictionary = new Dictionary<string, int>();
            sheets = oWB.Sheets;
        }
        /// <summary>
        /// Adds as many number of worksheets as there are projects
        /// and sets their name to be the name of the project.
        /// </summary>
        /// <param name="projects">The list of projects used to make the worksheets.</param>
        public void SetWorksheets(ArrayList projects)
        {
            ProjectWorksheetDictionary.Clear();
            int worksheetsToAdd = projects.Count - 3 <= 0 ? 0 : projects.Count - 3;
            currentRow = new int[projects.Count + 1];
            currentCol = new string[projects.Count + 1];
            validWorksheets = projects.Count;
            for (int i = 0; i < currentRow.Length; i++)
            {
                //currentRow[0] and currentCol[0] will never be used after their initialization.
                currentRow[i] = 2;
                currentCol[i] = "A";
            }
            // add worksheets as needed
            for (int i = 0; i < worksheetsToAdd; i++)
            {
                sheets.Add(Type.Missing, sheets[sheets.Count], Type.Missing, Type.Missing);
            }
            for (int i = 1; i < projects.Count + 1; i++)
            {
                // remove invalid characters
                string col_name = (projects[i - 1] as AsanaProject).Name;
                col_name = col_name.Replace(":", "");
                col_name = col_name.Replace("/", " ");
                col_name = col_name.Replace("\\", " ");
                sheets[i].Name = col_name;
                ProjectWorksheetDictionary.Add(col_name, i);
            }
            // The max number of columns supported by ExcelMaster is defined
            // here as 50.
            ColumnNames = new string[projects.Count + 1, 50];
        }
        /// <summary>
        /// Adds a row of data to the appropriate worksheet.
        /// </summary>
        /// <param name="data">The row to add into excel</param>
        /// <param name="worksheet">The name of the worksheet to which we add the row</param>
        public void AddRow(string[] data, string worksheet)
        {
            int worksheetNum = ProjectWorksheetDictionary[worksheet];
            Excel.Worksheet oSheet = (Excel.Worksheet)sheets[worksheetNum];
            // define the range and place into excel
            char startCol = 'A';
            char endCol = (char)(startCol + data.Length - 1);
            currentCol[worksheetNum] = "" + endCol;
            oSheet.get_Range("" + startCol + currentRow[worksheetNum], "" + endCol + currentRow[worksheetNum]).Value2 = data;
            // add to and store the current row pointer for this worksheet
            currentRow[worksheetNum]++;
        }
        /// <summary>
        /// Currently unused, but will add a 2D array to excel rather than a single row.
        /// </summary>
        /// <param name="data">The data to add to excel</param>
        /// <param name="worksheet">The name of the worksheet to which we add the row</param>
        public void AddDataRange(string[,] data, string worksheet)
        {
            int worksheetNum = ProjectWorksheetDictionary[worksheet];
            Excel.Worksheet oSheet = (Excel.Worksheet)sheets[worksheetNum];
            char startCol = 'A';
            int endRow = currentRow[worksheetNum] + data.GetLength(0);
            char endCol = (char)(startCol + data.Length - 1);
            oSheet.get_Range("" + startCol + currentRow[worksheetNum], "" + endCol + endRow).Value2 = data;
            // update the current row pointer to the end of the array
            currentRow[worksheetNum] = endRow + 1;
        }
        /// <summary>
        /// Sets the cell in the first row to be a column name.
        /// </summary>
        /// <param name="col">An array of column names to add</param>
        /// <param name="worksheetName">The name of the worksheet to which we add the columns</param>
        public void SetColumns(string[] col, string worksheetName)
        {
            //find the correct worksheet
            int i;
            for (i = 1; i <= sheets.Count && worksheetName != sheets[i].Name; i++)
                ;
            Excel.Worksheet oSheet = (Excel.Worksheet)sheets[i];
            char titleCol = 'A';
            char endtitleCol = (char)(titleCol + col.Length - 1);
            //add the data into the row
            oSheet.get_Range(titleCol + "1", endtitleCol + "1").Value2 = col;
            //split and freeze the first row in excel
            oSheet.Application.ActiveWindow.SplitRow = 1;
            oSheet.Application.ActiveWindow.FreezePanes = true;

            // store the column names in a 2d array
            for (int j = 0; j < col.Length; j++)
            {
                ColumnNames[i, j] = col[j];

            }
        }
        /// <summary>
        /// Displays the Excel document. Useful for debugging or watching what the code does in excel.
        /// </summary>
        public void Show()
        {
            oXL.Visible = true;
        }
        /// <summary>
        /// Get the names of the columns in a particular worksheet.
        /// </summary>
        /// <param name="worksheet">The worksheet from which to get the columns</param>
        /// <returns></returns>
        public string[] GetColumnNames(string worksheet)
        {
            int worksheetNum = ProjectWorksheetDictionary[worksheet];
            string[] data = new string[50];
            for (int i = 0; i < data.Length; i++)
                data[i] = ColumnNames[worksheetNum, i];
            return data;
        }
        /// <summary>
        /// Destroys all worksheets in Excel.
        /// </summary>
        public void ClearWorksheets()
        {
            sheets.Delete();
        }
        /// <summary>
        /// Creates a "reports" directory in the current location if it doesn't exist,
        /// and saves the excel document as a .xlsx file with a name based on the time
        /// of generation, down to the second.
        /// </summary>
        public void SaveAndClose()
        {
            try
            {
                Microsoft.VisualBasic.FileSystem.MkDir("reports");
            }
            catch (System.IO.IOException) { }
            finally
            {
                string name = "asana_report_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "").Replace(".", "").Replace("/", "");
                name = name.Remove(name.Length - 3);
                oWB.SaveAs(System.IO.Directory.GetCurrentDirectory() + "\\reports\\" + name + ".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);
                //Cleanup
                oWB.Close();
                oXL.Quit();
                releaseObject(oXL);
                releaseObject(oWB);
                releaseObject(sheets);
            }
        }
        /// <summary>
        /// Closes the excel document without saving work.
        /// </summary>
        public void CloseWithoutSaving()
        {
            //cleanup
            oWB.Close(false);
            oXL.Quit();
            releaseObject(oXL);
            releaseObject(oWB);
            releaseObject(sheets);
        }
        /// <summary>
        /// Properly disposes of Excel Interop objects
        /// </summary>
        /// <param name="obj"></param>
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
        /// <summary>
        /// Converts all of the data in a worksheet to a table with column headers
        /// in Excel.
        /// </summary>
        public void MakeWorksheetsTables()
        {
            for (int i = 0; i < validWorksheets; i++)
            {
                // get last column
                Excel.Worksheet CurrentWorksheet = (Excel.Worksheet)sheets[i + 1];
                int LastRow = currentRow[i + 1]; // table is made one past the last row with data
                string LastCol = currentCol[i + 1];
                Excel.Range tRange = CurrentWorksheet.get_Range("A1", LastCol + LastRow);
                CurrentWorksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, tRange,
                Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "Test Table";
                CurrentWorksheet.ListObjects["Test Table"].TableStyle = "TableStyleMedium2";
            }
        }

        private Excel.Application oXL;
        private Excel._Workbook oWB;
        private Excel.Sheets sheets;
        private int[] currentRow;
        private string[] currentCol;
        private string[,] ColumnNames;
        private int validWorksheets;
        private Dictionary<string, int> ProjectWorksheetDictionary;
    }
}
