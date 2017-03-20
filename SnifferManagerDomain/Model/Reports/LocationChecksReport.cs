using OfficeOpenXml;
using SnifferManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnifferManager.Reports
{
   public class LocationChecksReport
    {
        public byte[] GetReport(int locationId, DateTime beginDate, DateTime endDate)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                DeviceDbContext context = new DeviceDbContext();
                endDate = endDate.AddDays(1);
                var check = context.Checks.Where(x => x.SerialNumber == locationId && x.CheckDate.HasValue && (x.CheckDate >= beginDate && x.CheckDate <= endDate)).ToList();
                var article = context.Articles.GroupBy(x => x.CheckId).ToList();
                var model = check.GroupJoin(article, x => x.id, y => y.Key, (x, y) => new 
                {
                    CheckId = x.id,
                    CheckNumber = x.CheckNumber.ToString(),
                    Price = x.Total,
                    Position = y.Count(),
                    Date = x.CheckDate.HasValue ? x.CheckDate.Value.ToString("dd.MM.yyyy") : ""
                }).ToList();
                excel.Workbook.Worksheets.Add(locationId.ToString());
                ExcelWorksheet report = excel.Workbook.Worksheets[1];
                report.Name = locationId.ToString();
                report.Cells["A1"].Value = "Номер чека";
                report.Cells["B1"].Value = "Дата";
                report.Cells["C1"].Value = "Позиции";
                report.Cells["D1"].Value = "Сумма";
                report.Column(1).Style.Numberformat.Format = "dd.MM.yyyy";
                int i = 2;
                foreach (var _check in model)
                {
                    report.Cells[i, 1].Value = _check.CheckNumber;
                    report.Cells[i, 2].Value = _check.Date;
                    report.Cells[i, 3].Value = _check.Position;
                    report.Cells[i, 3].Value = _check.Price;
                    i++;
                }
                report.Cells[i, 1].Value = "Итого";
                report.Cells[i, 3].Value = model.Sum(x => x.Position);
                report.Cells[i, 3].Value = model.Sum(x => x.Price);
                return excel.GetAsByteArray();
            }
        }
    }
}
