using Agridoce.Application.ViewModels;
using Agridoce.Domain.Commands;
using AutoMapper;

namespace Agridoce.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TestViewModel, RegisterNewTestCommand>()
               .ConstructUsing(c => new RegisterNewTestCommand(c.Name, c.Age));
        }
    }
}
