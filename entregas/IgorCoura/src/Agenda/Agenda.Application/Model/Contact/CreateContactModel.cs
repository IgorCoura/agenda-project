using System.ComponentModel.DataAnnotations;

namespace Agenda.Application.Model
{
    public record CreateContactModel: BaseContactModel<CreatePhoneModel>
    {
    }
}
