using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lib.Common
{
    public class ExcelNPOI<T>
    {
        public ExcelNPOI()
        {

        }

        public XSSFWorkbook CreateExcelFile(List<T> datas, string sheetName)
        {
            var workbook = new XSSFWorkbook();

            List<string> headers = new List<string>();

            var sheet = workbook.CreateSheet(sheetName);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            IRow sheetRow = null;
            var rowIndex = 0;
            foreach (T item in datas)
            {
                sheetRow = sheet.CreateRow(rowIndex + 1);

                var columnIndex = 0;
                foreach (PropertyDescriptor prop in properties)
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    string header = Regex.Replace(prop.Name, "([A-Z])", " $1").Trim();

                    if (rowIndex == 0)
                    {
                        if (prop.Name == "NamaProperty")
                            header = "Nama Apartemen/Nama Perumahan/Komplek Ruko";

                        if (prop.Name == "GeoTag")
                            header = "Geo Tag (Long/Lat)";

                        headers.Add(header);
                    }

                    var value = prop.GetValue(item) ?? DBNull.Value;
                    var isCurrency = prop.Name == "LimitYangDiMinta" || prop.Name == "JumlahDiAjukan" || prop.Name == "NominalAngsuran";

                    setCellValue(workbook, sheetRow, columnIndex, type, value, isCurrency);
                    columnIndex++;
                }
                rowIndex++;
            }

            setHeader(workbook, sheet, headers);

            return workbook;
        }

        private void setHeader(IWorkbook workbook, ISheet sheet, List<string> headers)
        {
            int i = 0;
            var headerStyle = workbook.CreateCellStyle();
            
            var rowHeader = sheet.CreateRow(0);
            foreach (var header in headers)
            {
                var cell = rowHeader.CreateCell(i);
                cell.SetCellValue(headers[i]);
                cell.CellStyle = headerStyle;
                sheet.AutoSizeColumn(i);
                i++;
            }
        }

        private void setCellValue(IWorkbook workbook, IRow sheetRow, int columnIndex, Type type, object value, bool isCurrency = false)
        {
            IDataFormat dataFormatCustom = workbook.CreateDataFormat();
            ICellStyle dateStyle = workbook.CreateCellStyle();
            dateStyle.DataFormat = (short)dataFormatCustom.GetFormat("d/M/yy H:m");

            ICellStyle decimalStyle = workbook.CreateCellStyle();
            decimalStyle.DataFormat = (short)dataFormatCustom.GetFormat("##,###.00");

            ICellStyle intStyle = workbook.CreateCellStyle();
            intStyle.DataFormat = (short)dataFormatCustom.GetFormat("#####");

            ICell cell = sheetRow.CreateCell(columnIndex);

            if (value != null &&
                !string.IsNullOrEmpty(Convert.ToString(value)))
            {
                if (type.Name.ToLower() == "string")
                    cell.SetCellValue(Convert.ToString(value));
                else if (type.Name.ToLower() == "int32")
                {
                    cell.SetCellValue(Convert.ToInt32(value));
                    cell.CellStyle = intStyle;
                }
                else if (type.Name.ToLower() == "double")
                {
                    cell.SetCellValue(Convert.ToDouble(value));
                    if(isCurrency  && Convert.ToDouble(value) > 0)
                        cell.CellStyle = decimalStyle;
                }
                else if (type.Name.ToLower() == "decimal")
                {
                    cell.SetCellValue(Convert.ToDouble(value));
                    if (isCurrency && Convert.ToDouble(value) > 0)
                        cell.CellStyle = decimalStyle;
                }
                else if (type.Name.ToLower() == "datetime")
                {
                    cell.SetCellValue(Convert.ToDateTime(value));
                    cell.CellStyle = dateStyle;
                }
                else if (type.Name.ToLower() == "date")
                {
                    cell.SetCellValue(Convert.ToDateTime(value));
                    cell.CellStyle = dateStyle;
                }
                else
                {
                    cell.SetCellValue(Convert.ToDateTime(value));
                }
            }
            else
            {
                cell.SetCellValue(string.Empty);
            }
        }
    }
}
