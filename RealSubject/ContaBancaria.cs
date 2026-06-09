namespace RealSubject;
using Interface;

// ---------------------------------------------------------
// 2. OBJETO REAL (RealSubject)
//    Aqui fica a lógica de verdade. Mas o cliente nunca
//    acessa essa classe diretamente — passa sempre pelo Proxy.
// ---------------------------------------------------------

public class ContaBancaria : IServicoBancario
{
    private decimal _saldo = 5000m;
    private string _titular;

    public ContaBancaria(string titular)
    {
        _titular = titular;
        Console.WriteLine($"[ContaBancaria] Conta criada para: {titular}");
    }

    public void RealizarTransferencia(string destinatario, decimal valor)
    {
        _saldo -= valor;
        Console.WriteLine($"[ContaBancaria] Transferência de R${valor} para {destinatario} realizada. Saldo restante: R${_saldo}");
    }

    public decimal ConsultarSaldo()
    {
        Console.WriteLine($"[ContaBancaria] Saldo: R${_saldo}");
        return _saldo;
    }
}