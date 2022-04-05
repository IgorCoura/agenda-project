using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Model;

namespace AgendaConsole.Mapper
{
    public static class PhoneMapper
    {
        public static Phone ToEntity(this CreatePhoneModel model) =>
            new(model.Description, model.FormattedPhone);
        public static Phone ToEntity(this UpdatePhoneModel model) =>
            new(model.Id, model.ContactId, model.Description, model.FormattedPhone, model.CreatedAt, model.UpdatedAt);
        public static PhoneModel ToModel(this Phone entity) =>
            new PhoneModel
            {
                Id = entity.Id,
                ContactId = entity.ContactId,
                Description = entity.Description,
                FormattedPhone = entity.FormattedPhone,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };

        public static UpdatePhoneModel ToUpdateModel(this PhoneModel model) =>
            new UpdatePhoneModel
            {
                Id = model.Id,
                ContactId = model.ContactId,
                Description = model.Description,
                FormattedPhone = model.FormattedPhone,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
            };
    }
}
