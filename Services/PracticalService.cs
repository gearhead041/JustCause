using AutoMapper;
using JustCause.Data;
using JustCause.Dtos;
using JustCause.Models;
using JustCause.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JustCause.Services;

public class Practicalservice : IPracticalService

{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public Practicalservice(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public Task<PracticalDto> CreatePracticalAsync(PracticalDto practical)
    {
        var practicalToSave = mapper.Map<Practical>(practical);
        context.Practicals?.Add(practicalToSave);
        mapper.Map(practicalToSave, practical);
        return Task.FromResult(practical);
    }

    public async Task DeletePracticalAsync(int practicalId)
    {
        var PracticalToDelete = await context!.Practicals!
            .SingleOrDefaultAsync( p => p.Id == practicalId );
        if (PracticalToDelete == null)
            return;
        context.Practicals!.Remove(PracticalToDelete);
    }

    public async Task<PracticalDto?> GetPracticalAsync(int practicalId)
    {
        var practical = await context!.Practicals!
        .Include(p => p.StudentRegistrations)
        .SingleOrDefaultAsync(p => p.Id == practicalId);
        if(practical == null)
            return default;

        var practicalToReturn = mapper.Map<PracticalDto>(practical);
        return practicalToReturn;
    }

    public Task<IEnumerable<PracticalDto>> GetAllPracticalsAsync()
    {
        var practicals = context!.Practicals!.Include(p => p.StudentRegistrations);
        var practicalsToReturn = mapper.Map<IEnumerable<PracticalDto>>(practicals);
        return Task.FromResult(practicalsToReturn);
    }

    public async Task<PracticalDto> UpdatePracticalAsync(PracticalDto practicalDto)
    {
        var practicalFromDb = await context.Practicals!.SingleOrDefaultAsync(p => p.Id == practicalDto.Id);
        if(practicalFromDb != null)
            mapper.Map(practicalDto, practicalFromDb);

        return practicalDto;
    }
}
