using Agenda.Application.Model;
using Agenda.Domain.Core;
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
            CreateMap<Phone, PhoneModel>()
                .ForMember(x => x.PhoneType, m => m.MapFrom(req => Enumeration.FromId<PhoneType>((int)req.PhoneTypeId!).Name));
            CreateMap<PhoneType, PhoneTypeModel>();
            CreateMap<Interaction, InteractionModel>()
                .ForMember(x => x.InteractionType, m => m.MapFrom(req => Enumeration.FromId<InteractionType>((int)req.InteractionTypeId!).Name));
            CreateMap<InteractionType, InteractionTypeModel>();            
            CreateMap<User, UserModel>()
                .ForMember(x => x.UserRole, m => m.MapFrom(req => Enumeration.FromId<UserRole>(req.UserRoleId).Name));
        }
    }
}
