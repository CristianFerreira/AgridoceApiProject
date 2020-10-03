using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Models;
using AutoMapper;

namespace Agridoce.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, AccountViewModel>()
                .ConstructUsing(a => new AccountViewModel(a.Id, a.Email, a.GetToken(), a.GetClaims()));
        }
    }
}
