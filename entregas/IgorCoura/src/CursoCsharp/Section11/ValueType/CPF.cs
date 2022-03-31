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
        private static readonly int[] s_multiplierOne = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] s_multiplierTwo = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly string[] s_cpfInvalid = { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };

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

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CPF c = (CPF)obj;
                return _value.Equals(c._value);
            }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                throw new DomainException("Is necessary to inform the CPF.");

            var value = _value.Trim();
            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
                throw new DomainException("CPF should have 11 chars.");


            if (s_cpfInvalid.Contains(value))
                throw new DomainException("This CPF is invalid.");

            var digit = calculateDigit(value);

            if (!value.EndsWith(digit))
                throw new DomainException("This CPF is invalid.");
        }

        public string calculateDigit(string value)
        {

            string aux = value[..9];
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(aux[i].ToString()) * s_multiplierOne[i];

            int rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            aux += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(aux[i].ToString()) * s_multiplierTwo[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            return digit + rest.ToString();
        }

        
    }
}
