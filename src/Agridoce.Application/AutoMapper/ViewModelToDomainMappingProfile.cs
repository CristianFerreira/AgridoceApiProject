using Agridoce.Application.ViewModels.AccountViewModels;
using Agridoce.Domain.Commands.Requests.AccountCommand;
using AutoMapper;

namespace Agridoce.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterCompanyUserAccountViewModel, RegisterCompanyUserAccountCommand>()
               .ConstructUsing(c => new RegisterCompanyUserAccountCommand(c.Name, c.Email, c.Password, c.ConfirmPassword));

            CreateMap<RegisterEmployeeAccountViewModel, RegisterEmployeeUserAccountCommand>()
              .ConstructUsing(c => new RegisterEmployeeUserAccountCommand(c.CompanyId, c.Email, c.Password, c.ConfirmPassword));

            CreateMap<LoginAccountViewModel, LoginAccountCommand>()
               .ConstructUsing(c => new LoginAccountCommand(c.Email, c.Password));
        }
    }
}
