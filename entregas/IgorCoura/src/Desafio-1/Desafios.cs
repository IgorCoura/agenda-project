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
            IDictionary<string, double> dicionarioTipos = new Dictionary<string, double>() {
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

            try
            {
                var mult = dicionarioTipos[tipo];
                return valor * (decimal)mult;
            }
            catch
            {
                throw new Exception("O tipo informado não existe.");
            }

        }

        //1.3 - A função abaixo conta quantos números primos existem até o número informado.
        public static int ContarNumerosPrimos(int entrada)
        {
            var numeroPositivo = entrada < 0 ? entrada *= -1 : entrada;
            if (entrada < 2)
                return 0;


            var numeros = Enumerable.Range(2, numeroPositivo);
            var result = numeros.Where(n =>
            {
                for (int i = 2; i < n - 1; i++)
                    if (n % i == 0)
                        return false;
                return true;
            });
            return result.Count();
        }

        //1.4 - A função abaixo conta a quantidade de vogais dentro de uma string.
        public static int CalcularVogais(string frase)
        {
            var vogais = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var todasVogaisFrase = frase.Where(c => vogais.Contains(c));
            return todasVogaisFrase.Count();
        }

        //1.5 - A função abaixo aplica uma porcentagem de desconto a um valor e retorna o resultado
        public static string CalcularValorComDescontoFormatado(string valor, string porcentagem)
        {
            var valorLimpo = valor.Trim('R', 'r','$', '.', ' ' );
            var porcentagemLimpa = porcentagem.Trim('%');

            if (double.TryParse(valorLimpo, out double valorConvertido) is false)
                throw new Exception("Valor é inválido.");

            if (double.TryParse(porcentagemLimpa, out double porcentagemConvertido) is false)
                throw new Exception("Porcentagem é inválido.");

            var resultado = valorConvertido * (1 - (porcentagemConvertido / 100));
            return resultado.ToString("C", CultureInfo.CreateSpecificCulture("Pt-br"));
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
