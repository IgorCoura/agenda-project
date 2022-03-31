using Desafio_1;

Console.WriteLine("INICIO");

//1.1
Console.WriteLine("\nDesafio 1.1");
Console.WriteLine(Desafios.CalcularFatorial(5) == 120);//true

//1.2
Console.WriteLine("\nDesafio 1.2");
Console.WriteLine(Desafios.CalcularPremio(100, "vip", null) == 120.00M);//true
Console.WriteLine(Desafios.CalcularPremio(100, "basic", 3) == 300.00M);//true

//1.3
Console.WriteLine("\nDesafio 1.3");
Console.WriteLine(Desafios.ContarNumerosPrimos(7919) == 1000);//true

//1.4
Console.WriteLine("\nDesafio 1.4");
Console.WriteLine(Desafios.CalcularVogais("Luby Software") == 4);//true

//1.5
Console.WriteLine("\nDesafio 1.5");
Console.WriteLine(Desafios.CalcularValorComDescontoFormatado("R$ 6.800,00", "30%") == "R$ 4.760,00");//true

//1.6
Console.WriteLine("\nDesafio 1.6");
Console.WriteLine(Desafios.CalcularDiferencaData("10122020", "25122020") == 15);//true

//1.7
Console.WriteLine("\nDesafio 1.7");
int[] vetor = new int[] { 1, 2, 3, 4, 5 };
var result = Desafios.ObterElementosPares(vetor);
var expected = new int[] { 2, 4 };
Console.WriteLine(Enumerable.SequenceEqual(result, expected));//true

//1.8
Console.WriteLine("\nDesafio 1.8");
string[] vetor18 = new string[] {
    "John Doe",
    "Jane Doe",
    "Alice Jones",
    "Bobby Louis",
    "Lisa Romero"
};

var expected181 = new string[] { "John Doe", "Jane Doe" };
var result181 = Desafios.BuscarPessoa(vetor18, "Doe");
Console.WriteLine(Enumerable.SequenceEqual(result181, expected181));

var expected182 = new string[] { "Alice Jones" };
var result182 = Desafios.BuscarPessoa(vetor18, "Alice");
Console.WriteLine(Enumerable.SequenceEqual(result182, expected182));

var expected183 = new string[] { };
var result183 = Desafios.BuscarPessoa(vetor18, "James");
Console.WriteLine(Enumerable.SequenceEqual(result183, expected183));

//1.9
Console.WriteLine("\nDesafio 1.9");
var expected191 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } };
var result191 = Desafios.TransformarEmMatriz("1,2,3,4,5,6");
Console.WriteLine(verificarIgualdadeMatrizes(result191, expected191));
var expected192 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5 } };
var result192 = Desafios.TransformarEmMatriz("1,2,3,4,5");
Console.WriteLine(verificarIgualdadeMatrizes(result192, expected192));


//1.10
// faltam elementos no vetor2
Console.WriteLine("\nDesafio 1.10");

int[] vetor1 = new int[] { 1, 2, 3, 4, 5 };
int[] vetor2 = new int[] { 1, 2, 5 };
var expected101 = new int[] { 3, 4 };
var result101 = Desafios.ObterElementosFaltantes(vetor1, vetor2); //true 
Console.WriteLine(Enumerable.SequenceEqual(result101, expected101));

// faltam elementos no vetor3
int[] vetor3 = new int[] { 1, 4, 5 };
int[] vetor4 = new int[] { 1, 2, 3, 4, 5 };
var expected102 = new int[] { 2, 3 };
var result102 = Desafios.ObterElementosFaltantes(vetor3, vetor4); //true
Console.WriteLine(Enumerable.SequenceEqual(result102, expected102));

// faltam elementos em ambos vetores
int[] vetor5 = new int[] { 1, 2, 3, 4 };
int[] vetor6 = new int[] { 2, 3, 4, 5 };
var expected103 = new int[] { 1, 5 };
var result103 = Desafios.ObterElementosFaltantes(vetor6, vetor5);//true
Console.WriteLine(Enumerable.SequenceEqual(result103, expected103));

// não faltam items
int[] vetor7 = new int[] { 1, 3, 4, 5 };
int[] vetor8 = new int[] { 1, 3, 4, 5 };
var expected104 = new int[] { };
var result104 = Desafios.ObterElementosFaltantes(vetor7, vetor8); //true
Console.WriteLine(Enumerable.SequenceEqual(result104, expected104));












bool verificarIgualdadeMatrizes(int[][] matriz1, int[][] matriz2)
{
    //Caso as matrizes não seje do mesmo tamanho irá dar erro e retornara falso.
    try
    {
        for (int i = 0; i < matriz1.Length; i++)
        {
            for (int j = 0; j < matriz2[i].Length; j++)
            {
                if (matriz1[i][j] != matriz2[i][j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    catch
    {
        return false;
    }
}
