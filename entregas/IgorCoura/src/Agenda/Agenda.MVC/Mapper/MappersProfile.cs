using Agenda.MVC.ViewModel;
using Agenda.MVC.ViewModel.Contact;
using Agenda.MVC.ViewModel.User;
using AutoMapper;

namespace Agenda.MVC.Mapper
{
    public class MappersProfile: Profile
    {
        public MappersProfile()
        {
            CreateMap<EditContactViewModel, ContactViewModel>().ReverseMap();
            CreateMap<EditPhoneViewModel, PhoneViewModel>().ReverseMap();
            CreateMap<CreateUserViewModel, UserViewModel>().ReverseMap();
            CreateMap<EditUserViewModel, UserViewModel>().ReverseMap();
        }
    }
}
