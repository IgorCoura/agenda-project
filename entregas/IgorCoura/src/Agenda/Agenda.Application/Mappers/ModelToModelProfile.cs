using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Model;
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
