using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Model;
using Agenda.Domain.Entities;
using AutoMapper;
using Agenda.Domain.Entities.Enumerations;

namespace Agenda.Application.Mappers
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<CreateContactModel, Contact>();
            CreateMap<UpdateContactModel, Contact>();
            CreateMap<CreatePhoneModel, Phone>();
            CreateMap<UpdatePhoneModel, Phone>();
            CreateMap<PhoneTypeModel, PhoneType>();
        }
    }
}
