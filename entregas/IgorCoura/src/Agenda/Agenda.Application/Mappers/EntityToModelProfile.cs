using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Model;
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
        }
    }
}
