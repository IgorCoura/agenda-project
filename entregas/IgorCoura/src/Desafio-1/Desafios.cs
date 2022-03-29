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
        public static decimal CalcularPremio(decimal valor, string tipo, decimal? fator)
        {
            IDictionary<string, decimal> dicionarioTipos = new Dictionary<string, decimal>() {
                {"basic", 1M} ,
                {"vip", 1.2M},
                {"premium", 1.5M },
                {"deluxe", 1.8M },
                {"special", 2M },
            };

            if (valor <= 0)
                throw new Exception("O valor não pode ser menor ou igual a zero.");

            if (fator is not null && fator > 0)
                return valor * fator.Value;

            try
            {
                var mult = dicionarioTipos[tipo];
                return valor * mult;
            }
            catch
            {
                throw new Exception("O tipo informado não existe.");
            }

        }

        //1.3 - A função abaixo conta quantos números primos existem até o número informado.
        public static int ContarNumerosPrimos(int entrada)
        {
            var numero = entrada < 0 ? entrada *= -1 : entrada;
            if (entrada < 2) return 0;
            return Enumerable.Range(2, numero).Count(n => (Enumerable.Range(1, n).Count(i => n % i == 0) <= 2));
        }

        //1.4 - A função abaixo conta a quantidade de vogais dentro de uma string.
        public static int CalcularVogais(string frase)
        {
            return frase.Count(c => new int[] { 'a', 'e', 'i', 'o', 'u' }.Contains(c));
        }

        //1.5 - A função abaixo aplica uma porcentagem de desconto a um valor e retorna o resultado
        public static string CalcularValorComDescontoFormatado(string valor, string porcentagem)
        {
            var valorLimpo = valor.Trim('R', 'r','$', '.', ' ' );
            var porcentagemLimpa = porcentagem.Trim('%');

            if (!decimal.TryParse(valorLimpo, out decimal valorConvertido))
                throw new Exception("Valor é inválido.");

            if (!decimal.TryParse(porcentagemLimpa, out decimal porcentagemConvertido))
                throw new Exception("Porcentagem é inválido.");

            var resultado = valorConvertido * (1 - (porcentagemConvertido / 100));
            return resultado.ToString("C", CultureInfo.CreateSpecificCulture("Pt-br"));
        }

        //1.6 - A função abaixo obtém duas string de datas e calcula a diferença de dias entre elas.
        public static int CalcularDiferencaData(string dataInicial, string dataFinal)
        {
            if (DateTime.TryParseExact(dataInicial, "ddMMyyyy" , new CultureInfo("pt-BR"), DateTimeStyles.None , out var initial)
                && DateTime.TryParseExact(dataFinal, "ddMMyyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out var final))
               return (int)(final - initial).TotalDays;
            else
                throw new Exception("Data é inválido.");
        }

        //1.7 - A função abaixo retorna um novo vetor com todos elementos pares do vetor informado.
        public static int[] ObterElementosPares(int[] vetor)
        {
            return vetor.Where(v => v % 2 == 0).ToArray();
        }


        //1.8 - A função abaixo buscar um ou mais elementos no vetor que contém o valor ou parte do valor informado na busca.
        public static string[] BuscarPessoa(string[] vetor, string palavra)
        {
            return vetor.Where(v => v.Contains(palavra)).ToArray();
        }
        //1.9 - A função abaixo obtém uma string com números separados por vírgula e transforma em um array de array de inteiros com no máximo dois elementos.
        public static int[][] TransformarEmMatriz(string frase)
        {
            int[] numeros = frase.Split(",").Select(c => int.Parse(c)).ToArray();
            List<int[]> resultado = new List<int[]>();  
            for(int i = 0; i < numeros.Length; i+=2)
            {
                int[] array;
                if (numeros.Length - i == 1)
                    array = new int[] { numeros[i]};
                else
                    array = new int[]{ numeros[i], numeros[i + 1] };
                resultado.Add(array);
            }
            return resultado.ToArray();
        }


        //1.10 Afunção abaixo compara dois vetores e cria um novo vetor com os elementos faltantes de ambos
        public static int[] ObterElementosFaltantes(int[] vetor1, int[] vetor2)
        {
            return vetor1.Except(vetor2).Union(vetor2.Except(vetor1)).OrderBy(v => v).ToArray();
        }
    }
}
