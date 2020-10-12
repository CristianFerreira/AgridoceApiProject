using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Commands.Responses;
using Agridoce.Domain.Models;
using AutoMapper;

namespace Agridoce.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AccountCommandResult, UserAccountViewModel>()
                .ConstructUsing(a => new UserAccountViewModel(a.UserId, a.Email, a.Token, a.AccountClaims));
        }
    }
}
