namespace JustCause.Services.Contracts;

public interface IServiceManager
{
    IPracticalService PracticalService { get; }
    IStudentService StudentService { get; }

    IExportService ExportService { get; }
    Task Save();
}
