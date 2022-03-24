using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.ValueType;

namespace Section11.Entities
{
    public class Client
    {
        public string Name { get; set; }
        public CPF Cpf { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Client(string name, CPF cpf, DateOnly dateOfBirth)
        {
            Name = name;
            Cpf = cpf;
            DateOfBirth = dateOfBirth;
        }

    }
}
