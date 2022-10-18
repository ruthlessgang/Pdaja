using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
//using Microsoft.Office.Interop.Excel;
//using _Excel = Microsoft.Office.Interop.Excel;

namespace Lib.Common
{
    public class Excel
    {
        string newPath = "";

        public Excel(string path, int Sheet)
        {
            newPath = path;
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;

            //Open the workbook
            var fi = new FileInfo(newPath);

            using (var p = new ExcelPackage(fi))
            {
                //Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["Sheet1"];
                return ws.Cells[i, j].Value.ToString();
            }
        }

        public void Close()
        {

        }
    }
}
