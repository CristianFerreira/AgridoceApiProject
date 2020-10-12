using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Commands.Requests.AccountCommand;
using AutoMapper;

namespace Agridoce.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterCompanyUserAccountViewModel, RegisterCompanyAccountCommand>()
               .ConstructUsing(c => new RegisterCompanyAccountCommand(c.Name, c.Email, c.Password, c.ConfirmPassword));

            CreateMap<RegisterEmployeeAccountViewModel, RegisterEmployeeAccountCommand>()
              .ConstructUsing(c => new RegisterEmployeeAccountCommand(c.Name, c.CompanyUserId, c.Email, c.Password, c.ConfirmPassword));

            CreateMap<LoginAccountViewModel, LoginAccountCommand>()
               .ConstructUsing(c => new LoginAccountCommand(c.Email, c.Password));
        }
    }
}
