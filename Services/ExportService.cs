using ClosedXML.Excel;
using JustCause.Dtos;
using JustCause.Services.Contracts;

namespace JustCause.Services;

public class ExportService : IExportService
{
    private static byte[] ConvertToByte(XLWorkbook workbook)
    {
        var stream = new MemoryStream();
        workbook.SaveAs(stream);

        var content = stream.ToArray();
        return content;
    }

    private static void CreateStudentWorksheet(XLWorkbook package,IEnumerable<StudentDto> students,string title="Students")
    {
        var worksheet = package.Worksheets.Add(title);
        var studentArray = students.ToArray();
        worksheet.Cell(1, 1).Value = "Id";
        worksheet.Cell(1, 2).Value = "Name";
        worksheet.Cell(1, 3).Value = "Matric Number";
        worksheet.Cell(1, 4).Value = "Practical Registered";
        for (int index = 1; index <= studentArray.Length; index++)
        {
            worksheet.Cell(index + 1, 1).Value = studentArray[index - 1].Id;
            worksheet.Cell(index + 1, 2).Value = studentArray[index - 1].Name;
            worksheet.Cell(index + 1, 3).Value = studentArray[index - 1].MatricNumber;
            worksheet.Cell(index + 1, 4).Value = studentArray[index - 1].Practical?.Name;
        }
    }

    public byte[] CreateExport(IEnumerable<PracticalDto> practicals)
    {
        var workbook = new XLWorkbook();
        workbook.Properties.Title = "Student Eds Registrations";
        workbook.Properties.Author = "Adetoun Toluwanimi";
        workbook.Properties.Subject = "Export from authors";
        workbook.Properties.Keywords = "students, eds, blazor";

        foreach (var practical in practicals)
        {
            if(practical.StudentRegistrations != null && practical!.StudentRegistrations!.Count > 0 )
                CreateStudentWorksheet(workbook, practical!.StudentRegistrations!, practical.Name +" Students");
        }
        return ConvertToByte(workbook);
    }
}