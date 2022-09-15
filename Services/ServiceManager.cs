using AutoMapper;
using JustCause.Data;
using JustCause.Services.Contracts;

namespace JustCause.Services;

public class ServiceManager : IServiceManager
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public ServiceManager(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public IPracticalService PracticalService =>  new Practicalservice(context, mapper);

    public IStudentService StudentService => new StudentService(context,mapper);

    public IExportService ExportService =>  new ExportService();

    public async Task Save() => await context.SaveChangesAsync();
}
