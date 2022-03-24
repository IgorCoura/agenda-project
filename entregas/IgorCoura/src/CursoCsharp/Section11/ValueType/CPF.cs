using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Exceptions;

namespace Section11.ValueType
{
    public struct CPF
    {
        private readonly string _value;

        private CPF(string value)
        {
            _value = value;
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator CPF(string input) =>
            new CPF(input);

        public static bool operator ==(CPF l , CPF r)=> l._value.Equals(r._value);

        public static bool operator !=(CPF l, CPF r) => l._value.Equals(r._value) is false;
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                throw new DomainException("Is necessary to inform the CPF.");

            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<string> cpfInvalid = new List<string> { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
            string aux;
            string digit;
            int sum, rest;

            var value = _value.Trim();
            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
                throw new DomainException("CPF should have 11 chars.");


            if (cpfInvalid.Contains(_value))
                throw new DomainException("This CPF is invalid.");



            aux = value.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(aux[i].ToString()) * multiplierOne[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            aux = aux + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(aux[i].ToString()) * multiplierTwo[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            if (!value.EndsWith(digit))
                throw new DomainException("This CPF is invalid.");
        }
    }
}
