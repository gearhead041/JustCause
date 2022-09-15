using JustCause.Dtos;

namespace JustCause.Services.Contracts;

public interface IPracticalService
{
    Task<IEnumerable<PracticalDto>> GetAllPracticalsAsync();
    Task<PracticalDto?> GetPracticalAsync(int practicalId);
    Task<PracticalDto> CreatePracticalAsync(PracticalDto practical);
    Task DeletePracticalAsync(int practicalId);
    Task<PracticalDto> UpdatePracticalAsync(PracticalDto practicalDto);
}
