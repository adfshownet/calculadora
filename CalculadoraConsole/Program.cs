// Ponto de entrada da aplicação Calculadora Console
// Responsável pelo loop de interface com o usuário

namespace CalculadoraConsole;

class Program
{
    /// <summary>
    /// Método principal que controla o loop de interface com o usuário.
    /// </summary>
    static void Main(string[] args)
    {
        // Instancia a calculadora que contém a lógica de cálculo
        var calculadora = new Calculator();

        bool continuar = true;

        // Loop principal: continua até o usuário escolher sair
        while (continuar)
        {
            ExibirCabecalho();

            // Leitura e validação do primeiro número
            double primeiroNumero;
            if (!LerNumero("Digite o primeiro número: ", out primeiroNumero))
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                PausarELimpar();
                continue;
            }

            // Leitura e validação da operação
            char operacao;
            if (!LerOperacao("Escolha a operação (+, -, *, /): ", out operacao))
            {
                Console.WriteLine("Operação inválida. Use +, -, * ou /.");
                PausarELimpar();
                continue;
            }

            // Leitura e validação do segundo número
            double segundoNumero;
            if (!LerNumero("Digite o segundo número: ", out segundoNumero))
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                PausarELimpar();
                continue;
            }

            // Executa o cálculo e exibe o resultado
            try
            {
                double resultado = calculadora.Calcular(primeiroNumero, operacao, segundoNumero);
                Console.WriteLine($"Resultado: {primeiroNumero} {operacao} {segundoNumero} = {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            // Pergunta se deseja continuar
            Console.Write("\nDeseja fazer outro cálculo? (s/n): ");
            string? resposta = Console.ReadLine();
            continuar = resposta?.Trim().ToLower() == "s";

            Console.Clear();
        }

        Console.WriteLine("Obrigado por usar a Calculadora C# .NET. Até logo!");
    }

    /// <summary>
    /// Exibe o cabeçalho estilizado da aplicação.
    /// </summary>
    static void ExibirCabecalho()
    {
        Console.WriteLine("=============================");
        Console.WriteLine("     CALCULADORA C# .NET     ");
        Console.WriteLine("=============================");
    }

    /// <summary>
    /// Lê e valida um número digitado pelo usuário.
    /// Retorna true se a leitura for bem-sucedida, false caso contrário.
    /// </summary>
    /// <param name="mensagem">Mensagem exibida ao usuário.</param>
    /// <param name="numero">Número lido (out parameter).</param>
    static bool LerNumero(string mensagem, out double numero)
    {
        Console.Write(mensagem);
        string? entrada = Console.ReadLine();
        // Tenta converter a entrada para double
        return double.TryParse(entrada?.Replace('.', ','), out numero)
            || double.TryParse(entrada, out numero);
    }

    /// <summary>
    /// Lê e valida a operação escolhida pelo usuário.
    /// Retorna true se a operação for válida, false caso contrário.
    /// </summary>
    /// <param name="mensagem">Mensagem exibida ao usuário.</param>
    /// <param name="operacao">Operação lida (out parameter).</param>
    static bool LerOperacao(string mensagem, out char operacao)
    {
        Console.Write(mensagem);
        string? entrada = Console.ReadLine()?.Trim();

        // Verifica se a entrada contém exatamente um caractere válido
        if (entrada?.Length == 1 && "+-*/".Contains(entrada[0]))
        {
            operacao = entrada[0];
            return true;
        }

        operacao = '\0';
        return false;
    }

    /// <summary>
    /// Pausa a execução aguardando confirmação do usuário e limpa o console.
    /// </summary>
    static void PausarELimpar()
    {
        Console.WriteLine("Pressione Enter para tentar novamente...");
        Console.ReadLine();
        Console.Clear();
    }
}
