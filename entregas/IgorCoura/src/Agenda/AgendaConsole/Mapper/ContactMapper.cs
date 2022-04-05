using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Model;

namespace AgendaConsole.Mapper
{
    public static class ContactMapper
    {
        public static Contact ToEntity(this CreateContactModel model) =>
            new(model.Name, model.Phones.Select(p => p.ToEntity()).ToList());
        public static Contact ToEntity(this UpdateContactModel model) =>
            new(model.Id, model.Name, model.Phones.Select(p => p.ToEntity()).ToList(), model.CreatedAt, model.UpdatedAt);
        public static ContactModel ToModel(this Contact entity) =>
            new ContactModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Phones = entity.Phones.Select(p => p.ToModel()).ToList(),
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };
        public static UpdateContactModel ToUpdateModel(this ContactModel model) =>
            new UpdateContactModel
            {
                Id = model.Id,
                Name = model.Name,
                Phones = model.Phones.Select(p => p.ToModel()).ToList(),
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
            };
    }
}
