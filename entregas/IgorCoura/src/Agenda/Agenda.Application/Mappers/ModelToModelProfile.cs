using Agenda.Application.Model;
using AutoMapper;

namespace Agenda.Application.Mappers
{
    public class ModelToModelProfile: Profile
    {
        public ModelToModelProfile()
        {
            CreateMap<ContactModel, UpdateContactModel>();
            CreateMap<UpdateContactModel, ContactModel>();
            CreateMap<PhoneModel, UpdatePhoneModel>();
            CreateMap<UpdatePhoneModel, PhoneModel>();
        }
    }
}
