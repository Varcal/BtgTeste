using BTGTeste.Dominio.Entidades;

namespace BtgTeste.App
{
    internal class Program
    {
        static CaixaEletronico caixa = new CaixaEletronico();
        
        static void Main(string[] args)
        {
            CarregarMenu();
        }


        static void CarregarMenu()
        {
            var menu = 0;

            while (menu != 9)
            {
                Console.WriteLine("1 - Carregar Notas");
                Console.WriteLine("2 - Efetuar Saque");
                Console.WriteLine("3 - Verificar Notas disponíveis");
                Console.WriteLine("9 - Sair");

                int.TryParse(Console.ReadLine(), out menu);

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Qual a quantidade de notas de 100?");
                        int.TryParse(Console.ReadLine(), out int qtdNota100);
                        Console.WriteLine("Qual a quantidade de notas de 50?");
                        int.TryParse(Console.ReadLine(), out int qtdNota50);
                        Console.WriteLine("Qual a quantidade de notas de 20?");
                        int.TryParse(Console.ReadLine(), out int qtdNota20);
                        Console.WriteLine("Qual a quantidade de notas de 10?");
                        int.TryParse(Console.ReadLine(), out int qtdNota10);
                        caixa.CarregarNotas(qtdNota100, qtdNota50, qtdNota20, qtdNota10);
                        break;
                    case 2:
                        Console.WriteLine("Digie o valor do saque:");
                        int.TryParse(Console.ReadLine(), out int valor);
                        caixa.Sacar(valor);
                        break;
                    case 3:
                        Console.WriteLine($"Notas disponíveis {string.Join(", ", caixa.NotasDisponivies())}");
                        break;
                    case 9:
                        Console.WriteLine("Operação finalizada");
                        return;
                  default: Console.WriteLine("Menu não encontrado");
                        break;
                        
                }
            }
        }
    }


}