using AutoMapper;

namespace EffortEntry.AutoMapper
{
	public class EntityToModelMappingProfile : Profile
	{
		public EntityToModelMappingProfile()
		{
			CreateMap<Domain.Models.User, Repository.Models.User>()
			.ReverseMap()
			.PreserveReferences();
		}
	}
}
