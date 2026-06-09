using Proxy;
using Interface;
using RealSubject;
// ---------------------------------------------------------
// 4. CLIENTE
//    Só conhece a interface IServicoBancario.
//    Não sabe (e não precisa saber) que está usando um Proxy.
// ---------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("  TESTE 1: Usuário NÃO autenticado");
        Console.WriteLine("======================================");
 
        // O cliente cria o proxy passando os dados de acesso
        IServicoBancario contaNaoAutenticada = new ProxyContaBancaria("Carlos", autenticado: false);
 
        // O proxy bloqueia tudo porque o usuário não está autenticado
        contaNaoAutenticada.ConsultarSaldo();
        contaNaoAutenticada.RealizarTransferencia("Maria", 500m);
 
 
        Console.WriteLine("\n======================================");
        Console.WriteLine("  TESTE 2: Usuário autenticado");
        Console.WriteLine("======================================");
 
        IServicoBancario contaAutenticada = new ProxyContaBancaria("Ana", autenticado: true);
 
        // O proxy permite e delega ao objeto real
        contaAutenticada.ConsultarSaldo();
        contaAutenticada.RealizarTransferencia("João", 200m);
 
 
        Console.WriteLine("\n======================================");
        Console.WriteLine("  TESTE 3: Transferência acima do limite");
        Console.WriteLine("======================================");
 
        IServicoBancario contaLimite = new ProxyContaBancaria("Pedro", autenticado: true);
 
        // O proxy bloqueia por regra de negócio (valor acima do permitido)
        contaLimite.RealizarTransferencia("Empresa XYZ", 15000m);
 
        Console.WriteLine("\nFim dos testes.");
    }
}