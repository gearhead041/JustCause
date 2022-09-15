using JustCause.Dtos;

namespace JustCause.Services.Contracts;

public interface IExportService
{
    byte[] CreateExport(IEnumerable<PracticalDto> practicals);
}