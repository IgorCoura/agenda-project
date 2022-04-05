using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgendaConsole.Entities
{
    public class Phone: Register
    {
        public int ContactId { get;  set; }
        public string Description { get; set; } = string.Empty;
        public string FormattedPhone { get; set; } = string.Empty;
        public int DDD { get; set; }
        public int Number { get; set; }

        public Phone(string description, string formattedPhone)
        {
            Description = description;
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
                FormattedPhone = $"({ddd}) {stringNumber.Substring(0, stringNumber.Length - 4)}-{stringNumber.Substring(stringNumber.Length - 4)}";
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
