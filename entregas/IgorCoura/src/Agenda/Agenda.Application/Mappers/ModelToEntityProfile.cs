using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Entities;
using Agenda.Domain.Model;
using AutoMapper;

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
        }
    }
}
