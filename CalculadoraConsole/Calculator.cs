// Classe responsável pela lógica de cálculo da calculadora
// Encapsula as operações matemáticas suportadas

namespace CalculadoraConsole;

/// <summary>
/// Classe que realiza as operações matemáticas básicas da calculadora.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Executa o cálculo entre dois números com base na operação fornecida.
    /// </summary>
    /// <param name="primeiroNumero">Primeiro operando.</param>
    /// <param name="operacao">Operação a ser realizada: +, -, * ou /.</param>
    /// <param name="segundoNumero">Segundo operando.</param>
    /// <returns>Resultado da operação matemática.</returns>
    /// <exception cref="DivideByZeroException">Lançada quando há tentativa de divisão por zero.</exception>
    /// <exception cref="ArgumentException">Lançada quando a operação informada é inválida.</exception>
    public double Calcular(double primeiroNumero, char operacao, double segundoNumero)
    {
        switch (operacao)
        {
            case '+':
                // Soma os dois números
                return Somar(primeiroNumero, segundoNumero);

            case '-':
                // Subtrai o segundo número do primeiro
                return Subtrair(primeiroNumero, segundoNumero);

            case '*':
                // Multiplica os dois números
                return Multiplicar(primeiroNumero, segundoNumero);

            case '/':
                // Divide o primeiro pelo segundo, com proteção contra divisão por zero
                return Dividir(primeiroNumero, segundoNumero);

            default:
                // Operação não reconhecida
                throw new ArgumentException($"Operação '{operacao}' não é suportada. Use +, -, * ou /.");
        }
    }

    /// <summary>
    /// Realiza a adição de dois números.
    /// </summary>
    /// <param name="a">Primeiro número.</param>
    /// <param name="b">Segundo número.</param>
    /// <returns>Soma de a e b.</returns>
    public double Somar(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Realiza a subtração entre dois números.
    /// </summary>
    /// <param name="a">Número do qual se subtrai.</param>
    /// <param name="b">Número a ser subtraído.</param>
    /// <returns>Diferença entre a e b.</returns>
    public double Subtrair(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Realiza a multiplicação de dois números.
    /// </summary>
    /// <param name="a">Primeiro número.</param>
    /// <param name="b">Segundo número.</param>
    /// <returns>Produto de a e b.</returns>
    public double Multiplicar(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Realiza a divisão entre dois números com validação de divisão por zero.
    /// </summary>
    /// <param name="a">Dividendo.</param>
    /// <param name="b">Divisor.</param>
    /// <returns>Quociente de a dividido por b.</returns>
    /// <exception cref="DivideByZeroException">Lançada quando b é igual a zero.</exception>
    public double Dividir(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Divisão por zero não é permitida.");
        }
        return a / b;
    }
}
