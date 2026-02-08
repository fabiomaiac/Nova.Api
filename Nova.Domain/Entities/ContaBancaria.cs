namespace Nova.Domain;

public class ContaBancaria
{
    public int NumeroConta { get; private set; }
    public string Titular { get; private set; } = string.Empty;
    public decimal Saldo { get; private set; }

    protected ContaBancaria() { }

    public ContaBancaria(int numeroConta, string titular, decimal saldoInicial)
{
    if (numeroConta <= 0)
        throw new Exception("Número da conta inválido");

    if (string.IsNullOrWhiteSpace(titular))
        throw new Exception("Titular inválido");

    if (saldoInicial < 0)
        throw new Exception("Saldo inicial não pode ser negativo");

    NumeroConta = numeroConta;
    Titular = titular;
    Saldo = saldoInicial;
}


    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor do depósito deve ser maior que zero");

        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor do saque deve ser maior que zero");

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente");

        Saldo -= valor;
    }
}
