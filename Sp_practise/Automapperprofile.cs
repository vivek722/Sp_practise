using AutoMapper;
using Domain.Model;
using Sp_practise.RequestModel;

namespace Sp_practise
{
    public class Automapperprofile : Profile
    {
        public Automapperprofile()
        {
        CreateMap<EmployeeViewModel, EmployeeEntity>();
        CreateMap<EmployeeEntity, EmployeeViewModel>();
        }
    }
}
