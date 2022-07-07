using Agenda.MVC.ViewModel;
using AutoMapper;

namespace Agenda.MVC.Mapper
{
    public class MappersProfile: Profile
    {
        public MappersProfile()
        {
            CreateMap<EditContactViewModel, ContactViewModel>().ReverseMap();
            CreateMap<EditPhoneViewModel, PhoneViewModel>().ReverseMap();
        }
    }
}
