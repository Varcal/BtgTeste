namespace BTGTeste.Dominio.Entidades
{
    public class CaixaEletronico
    {

        private readonly Dictionary<ENota, int> notasDisponiveis = new Dictionary<ENota, int>()
        {
            {ENota.Nota100, 0},  {ENota.Nota50, 0}, {ENota.Nota20, 0}, {ENota.Nota10, 0}
        };

        public void CarregarNotas(int qtdeNota100, int qtdeNota50, int qtdeNota20, int qtdeNota10)
        {
            notasDisponiveis[ENota.Nota100] = qtdeNota100;
            notasDisponiveis[ENota.Nota50] = qtdeNota50;
            notasDisponiveis[ENota.Nota20] = qtdeNota20;
            notasDisponiveis[ENota.Nota10] = qtdeNota10;
        }

        public void Sacar(int valor)
        {
            var notasSacadas = new Dictionary<int, int>();

            var valorSaque = valor;
            var notasOrdenadas = new List<ENota>(notasDisponiveis.Keys).OrderByDescending(n => n);

            foreach (ENota eNota in notasOrdenadas)
            {
                var nota = (int)eNota;
                var quantidadeNotas = valor / nota;
                if (quantidadeNotas > 0)
                {
                    if (quantidadeNotas <= notasDisponiveis[eNota])
                    {
                        notasSacadas.Add(nota, quantidadeNotas);
                        notasDisponiveis[eNota] -= quantidadeNotas;
                        valor -= quantidadeNotas * nota;
                    }
                    else
                    {
                        notasSacadas.Add(nota, quantidadeNotas);
                        valor -= notasDisponiveis[eNota] * nota;
                        notasDisponiveis[eNota] = 0;
                    }
                }
                if (valor == 0)
                {
                    Console.WriteLine($"Para o valor: {valorSaque} - Notas entregues: {string.Join(", ", notasSacadas)}");
                    return;
                }
            }

            Console.WriteLine($"Notas disponíveis {string.Join(", ", notasDisponiveis)}");
            Console.WriteLine($"Não é possível efetuar o saque do valor {valorSaque} solicitado com as notas disponíveis");
        }

        public Dictionary<ENota, int> NotasDisponivies() => notasDisponiveis;

    }
}