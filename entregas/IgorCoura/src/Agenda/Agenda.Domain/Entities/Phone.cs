using System.Text.RegularExpressions;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;

namespace Agenda.Domain.Entities
{
    public class Phone: Register
    {
        public Contact Contact { get; set; }
        public int ContactId { get;  set; }
        public string Description { get; set; } = string.Empty;
        public string FormattedPhone { get; set; } = string.Empty;
        public int DDD { get; set; }
        public int Number { get; set; }
        public PhoneType? PhoneType { get; set; }
        public int? PhoneTypeId { get; set; }
        
        public Phone(string description, string formattedPhone)
        {
            Description = description;
            SetPhone(formattedPhone);
        }
        public Phone(string description, string formattedPhone, int phoneTypeId)
        {
            Description = description;
            PhoneTypeId = phoneTypeId;
            SetPhone(formattedPhone);
        }

        public Phone(int id, int contactId, string description, string formattedPhone, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            ContactId = contactId;
            Description = description;
            SetPhone(formattedPhone);
        }

        public Phone()
        {

        }

        public void SetPhone(string formattedPhone)
        {
            int ddd;
            int number;
            var stringPhone = Regex.Replace(formattedPhone, "[ ()-]+", "", RegexOptions.Compiled);
            if (int.TryParse(stringPhone.Substring(0, 2), out ddd)
                && int.TryParse(stringPhone.Substring(2), out number))
            {
                DDD = ddd;
                Number = number;
                var stringNumber = number.ToString();
                FormattedPhone = $"({ddd}) {stringNumber.Insert(stringNumber.Length - 4, "-")}";
            }
            else
                throw new Exception($"Erro ao tentar converter o numero de telefone: {formattedPhone}");
            
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj!.GetType() != this.GetType())
            {
                return false;
            }
            var Phone = obj as Phone;
            return DDD == Phone!.DDD && Number == Phone!.Number;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return FormattedPhone;
        }
    }
}
