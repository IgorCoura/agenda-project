using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Entities
{
    public class Phone: Register
    {
        public int ContactId { get;  set; }
        public string Description { get; private set; }
        public string FormattedPhone { get; private set; }
        public int DDD { get; private set; }
        public int Number { get; private set; }

        public Phone(int contactId, string description, string formattedPhone, int dDD, int number)
        {
            ContactId = contactId;
            Description = description;
            FormattedPhone = formattedPhone;
            DDD = dDD;
            Number = number;
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

        public override string ToString()
        {
            return $"{DDD} {Number}";
        }
    }
}
