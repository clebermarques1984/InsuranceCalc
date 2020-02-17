using App.Application.SeguradoCommands;
using App.Domain.Entities;
using AutoMapper;

namespace App.Web.AutoMapper
{
	public class ClientRequestToEntityMappingProfile : Profile
	{
		public ClientRequestToEntityMappingProfile()
		{
			CreateMap<SeguradoRegisterRequest, Segurado>()
				.ForMember(dest => dest.Nome, opt => opt.MapFrom(source => source.Segurado.Nome))
				.ForMember(dest => dest.CPF, opt => opt.MapFrom(source => source.Segurado.Cpf))
				.ForMember(dest => dest.Idade, opt => opt.MapFrom(source => source.Segurado.Idade));

			CreateMap<SeguradoUpdateRequest, Segurado>()
				.ForMember(dest => dest.Nome, opt => opt.MapFrom(source => source.Segurado.Nome))
				.ForMember(dest => dest.CPF, opt => opt.MapFrom(source => source.Segurado.Cpf))
				.ForMember(dest => dest.Idade, opt => opt.MapFrom(source => source.Segurado.Idade));
		}
	}
}