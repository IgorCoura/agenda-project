using Agenda.Application.Model;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using AutoMapper;

namespace Agenda.Application.Mappers
{
    public class EntityToModelProfile:Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Contact, ContactModel>();
            CreateMap<Phone, PhoneModel>();
            CreateMap<PhoneType, PhoneTypeModel>();
            CreateMap<Interaction, InteractionModel>();
            CreateMap<InteractionType, InteractionTypeModel>();
            CreateMap<User, UserModel>();
        }
    }
}
