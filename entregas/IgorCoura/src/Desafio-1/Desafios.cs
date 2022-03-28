using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_1
{
    public static class Desafios
    {
        //1.1 - A função abaixo calcula o fatorial de um número.
        public static int CalcularFatorial(int num)
        {
            return num <= 1 ? 1 : CalcularFatorial(num - 1) * num;
        }


        //1.2 - A função abaixo calcula ovalor total do prêmio somando fator do tipo do prêmio.
        //Caso o valor ou o tipo passado seja invalido irá retorna um exceção
        public static decimal CalcularPremio(decimal valor, string tipo, double? fator)
        {
            IDictionary<string, double> dicTipo = new Dictionary<string, double>() {
                {"basic", 1} ,
                {"vip", 1.2},
                {"premium", 1.5 },
                {"deluxe", 1.8 },
                {"special", 2 },
            };

            if (valor <= 0)
                throw new Exception("O valor não pode ser menor ou igual a zero.");
            if (fator is not null && fator > 0)
                return valor * (decimal)fator.Value;
            else
            {
                try
                {
                    var mult = dicTipo[tipo];
                    return valor *(decimal)mult;
                }
                catch
                {
                    throw new Exception("O tipo informado não existe.");
                }
            }

        }

        //1.3 - A função abaixo conta quantos números primos existem até o número informado.
        public static int ContarNumerosPrimos(int num)
        {
            if (num < 0)
                num *= -1;
            int countPrimo = 0;
            for (int i = 2; i <= num; i++)
                if(IsPrimo(i))
                    countPrimo++;
            return countPrimo;
        }

        public static bool IsPrimo(int num)
        {
            for (int i = num - 1; i > 1; i--)
                if (num % i == 0)
                    return false;
            return true;
        }


        //1.4 - A função abaixo conta a quantidade de vogais dentro de uma string.
        public static int CalcularVogais(string frase)
        {
            var vogais = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var count = 0;
            foreach (var c in frase)
                if (vogais.Contains(c))
                    count++;
            return count;
        }

        //1.5 - A função abaixo aplica uma porcentagem de desconto a um valor e retorna o resultado
        public static string CalcularValorComDescontoFormatado(string valor, string porcentagem)
        {
            var listChars = new List<string>() { "R", "r", "$", ".", " " };
            foreach (string c in listChars)
                valor = valor.Replace(c, "");
            porcentagem = porcentagem.Replace("%", "");

            double value;
            double porc;

            if (double.TryParse(valor, out value) is false)
                throw new Exception("Valor é inválido.");

            if (double.TryParse(porcentagem, out porc) is false)
                throw new Exception("Porcentagem é inválido.");

            var calc = value * (1 - (porc / 100));
            var result = calc.ToString("C", CultureInfo.CreateSpecificCulture("Pt-br"));
            return  result;
        }

        //1.6 - A função abaixo obtém duas string de datas e calcula a diferença de dias entre elas.
        public static int CalcularDiferencaData(string dataInicial, string dataFinal)
        {
            dataInicial = dataInicial.Insert(2, "-").Insert(5, "-");
            dataFinal = dataFinal.Insert(2, "-").Insert(5, "-");

            if (DateTime.TryParse(dataInicial, out var initial))
            {
                if (DateTime.TryParse(dataFinal, out var final))
                    return (int)(final - initial).TotalDays;
                else
                    throw new Exception("Data final é inválido.");
            }
            else
                throw new Exception("Data inicial é inválido.");
        }

        //1.7 - A função abaixo retorna um novo vetor com todos elementos pares do vetor informado.
        public static int[] ObterElementosPares(int[] vetor)
        {
            List<int> result = new();
            foreach (var v in vetor)
                if (v % 2 == 0)
                    result.Add(v);
            return result.ToArray();
        }


        //1.8 - A função abaixo buscar um ou mais elementos no vetor que contém o valor ou parte do valor informado na busca.
        public static string[] BuscarPessoa(string[] vetor, string palavra)
        {
            List<string> result = new List<string>();
            foreach (var v in vetor)
                if (v.Contains(palavra))
                    result.Add(v);
            return result.ToArray();
        }
        //1.9 - A função abaixo obtém uma string com números separados por vírgula e transforma em um array de array de inteiros com no máximo dois elementos.
        public static int[][] TransformarEmMatriz(string frase)
        {
            var result = new List<int[]>();
            var array = new int[2];
            int count = 0;
            foreach (var v in frase)
            {
                if (v == ',')
                    continue;

                array[count] = v - '0';

                count++;
                if (count >= 2)
                {
                    result.Add(array);
                    array = new int[2];
                    count = 0;
                }
            }

            return result.ToArray();
        }


        //1.10 Afunção abaixo compara dois vetores e cria um novo vetor com os elementos faltantes de ambos
        public static int[] ObterElementosFaltantes(int[] vetor1, int[] vetor2)
        {
            Array[] array = new Array[2] { vetor1, vetor2};
            var sorteSet = new SortedSet<int>();
            sorteSet.IntersectWith(vetor2);

            return sorteSet.ToArray();
        }


    }
}
