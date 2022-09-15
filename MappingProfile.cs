using AutoMapper;
using JustCause.Dtos;
using JustCause.Models;

namespace JustCause;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<PracticalDto, Practical>().ReverseMap();
		CreateMap<StudentRegistrationInfo, StudentDto>().ReverseMap();
	}
}
