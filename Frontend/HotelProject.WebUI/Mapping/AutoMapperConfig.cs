using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace HotelProject.WebUI.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<ResultServiceDto, Service>().ReverseMap();
			CreateMap<UpdateServiceDto, Service>().ReverseMap();
			CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();	// appuser'da ne varsa sendede olsun eşleşsin diyor
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
        }
	}
}
