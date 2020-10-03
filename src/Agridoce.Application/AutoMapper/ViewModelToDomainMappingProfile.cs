using Agridoce.Application.ViewModels;
using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Commands;
using Agridoce.Domain.Commands.AccountCommand;
using AutoMapper;

namespace Agridoce.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterAccountViewModel, RegisterAccountCommand>()
               .ConstructUsing(c => new RegisterAccountCommand(c.Email, c.Password, c.ConfirmPassword));

            CreateMap<LoginAccountViewModel, LoginAccountCommand>()
               .ConstructUsing(c => new LoginAccountCommand(c.Email, c.Password));
        }
    }
}
