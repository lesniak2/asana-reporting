using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace AsanaCrescent
{
    class ExcelMaster
    {
        private Excel.Application oXL;
        private Excel._Workbook oWB;
        private Excel._Worksheet oSheet;
        private int currentRow = 2;
        private bool saved = false;
        Excel.Range oResizeRange;
        public ExcelMaster()
        {
            oXL = new Excel.Application();
            oWB = (Excel.Workbook)(oXL.Workbooks.Add(Missing.Value));
        }
        public void AddRow(string[] arr)
        {
           
                //Starts Excel and Gets Application Object
                oXL.Visible = true;

                //Creates New Workbook
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;

                char startCol = 'A';
                char endCol = (char)(startCol + arr.Length - 1);

                oSheet.get_Range("" + startCol + currentRow, "" + endCol + currentRow).Value2 = arr;
                currentRow++;
        }
        public void AddColumn(string[] col)
        {
            char titleCol = 'A';
            char endtitleCol = (char)(titleCol + col.Length - 1);

            oSheet.get_Range(titleCol + "1",endtitleCol+"1").Value2 = col;
            oSheet.Activate();
            oSheet.Application.ActiveWindow.SplitRow = 1;
            oSheet.Application.ActiveWindow.FreezePanes = true;
            
        }
    }
}
 