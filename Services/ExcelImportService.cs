using ExcelImportApp.Model;
using OfficeOpenXml;

namespace ExcelImportApp.Services
{
    public class ExcelImportService
    {
        public List<ClientModel> ParseClientData(IFormFile file)
        {
            List<ClientModel> excelData = new List<ClientModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (Stream stream = file.OpenReadStream())
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {

                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        if (i < 11)
                            continue;

                        var rowData = new ClientModel();

                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            if (worksheet.Cells[i, j].Value == null)
                                break;

                            if(j == 1)
                            {
                                rowData.Title = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 2)
                            {
                                rowData.FirstName = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 3)
                            {
                                rowData.LastName = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 4)
                            {
                                rowData.DateOfBirth = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 5)
                            {
                                rowData.IdNr = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 6)
                            {
                                rowData.EmailAddress = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 7)
                            {
                                rowData.TelNr = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 8)
                            {
                                rowData.MedicalScheme = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 9)
                            {
                                rowData.MedicalSchemePlan = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 10)
                            {
                                rowData.MemberNr = worksheet.Cells[i, j].Value.ToString();
                            }
                            if (j == 11)
                            {
                                rowData.DepartmentNr = worksheet.Cells[i, j].Value.ToString();
                            }
                            
                        }

                        excelData.Add(rowData);
                    }
                }
            }
            return excelData;
        }
    }
}
