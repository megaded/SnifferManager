using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Drawing;
using OfficeOpenXml;
using SnifferManager;

namespace SnifferManager.Reports
{
    public class LocationSalesReport
    {
        public byte[] GetReport(int locationId,DateTime beginDate,DateTime endDate)
        {
            using(ExcelPackage excel=new ExcelPackage())
            {
                DeviceDbContext context = new DeviceDbContext();
                endDate = endDate.AddDays(1);
                var checks = context.Checks.Where(y => y.SerialNumber == locationId && y.CheckDate.HasValue && (y.CheckDate >= beginDate && y.CheckDate <= endDate)).ToList().
                    GroupBy(x => x.CheckDate.Value.ToString("dd.MM.yyyy"));
                var sales = checks.Select(x => new 
                {
                    Date = DateTime.Parse(x.Key),
                    Total = (float)x.Sum(m => m.Total),
                    CountCheck = x.Count()
                }).ToList();
                excel.Workbook.Worksheets.Add(locationId.ToString());
                ExcelWorksheet report = excel.Workbook.Worksheets[1];
                report.Name = locationId.ToString();
                report.Cells["A1"].Value = "Дата";
                report.Cells["B1"].Value = "Сумма";
                report.Cells["C1"].Value = "Чекки";               
                report.Column(1).Style.Numberformat.Format = "dd.MM.yyyy";
                int i = 2;
                foreach (var sale in sales)
                {
                    report.Cells[i, 1].Value = sale.Date;
                    report.Cells[i, 2].Value = sale.Total;
                    report.Cells[i, 3].Value = sale.CountCheck;            
                    i++;
                }
                report.Cells[i, 1].Value = "Итого";
                report.Cells[i, 2].Value = sales.Sum(x => x.Total);
                report.Cells[i, 3].Value = sales.Sum(x => x.CountCheck);
                return excel.GetAsByteArray();
            }
        }
    }
}
