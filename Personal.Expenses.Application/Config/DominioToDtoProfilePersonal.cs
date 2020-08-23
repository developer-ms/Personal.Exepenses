using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Dto;

namespace Personal.Expenses.Application.Config
{
    public class DominioToDtoProfilePersonal : AutoMapper.Profile
    {

        public DominioToDtoProfilePersonal()
        {
            CreateMap(typeof(Spent), typeof(SpentDto)).ReverseMap();
            CreateMap(typeof(Spent), typeof(SpentDtoSpecialized));
            CreateMap(typeof(Spent), typeof(SpentDtoSpecializedResult));
            CreateMap(typeof(Spent), typeof(SpentDtoSpecializedReport));
            CreateMap(typeof(Spent), typeof(SpentDtoSpecializedDetails));

        }

    }
}
