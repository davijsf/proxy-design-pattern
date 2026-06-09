namespace Proxy;
using RealSubject;
using Interface;
// ---------------------------------------------------------
// 3. O PROXY
//    Implementa a mesma interface do objeto real.
//    Antes (ou depois) de chamar o objeto real, pode:
//      - Verificar permissões (controle de acesso)
//      - Registrar logs
//      - Validar dados
//      - Criar o objeto real só quando necessário (lazy loading)
// ---------------------------------------------------------

public class ProxyContaBancaria : IServicoBancario
{
    // Guarda uma referência ao objeto real (criado só quando precisar)
    private ContaBancaria? _contaReal;

    private string _usuario;
    private bool _autenticado;

    public ProxyContaBancaria(string usuario, bool autenticado)
    {
        _usuario = usuario;
        _autenticado = autenticado;
    }

    // Método auxiliar: cria o objeto real só quando necessário
    // Isso é chamado de "Lazy Initialization" (inicialização preguiçosa).
    private ContaBancaria ObterContaReal()
    {
        if (_contaReal == null)
        {
            Console.WriteLine("[Proxy] Criando o objeto real agora (lazy loading)...");
            _contaReal = new ContaBancaria(_usuario);
        }
        return _contaReal;
    }

    // O Proxy intercepta a transferência e verifica a permissão antes de agir.
    public void RealizarTransferencia(string destinatario, decimal valor)
    {
         Console.WriteLine($"\n[Proxy] Interceptando pedido de transferência de {_usuario}...");
 
        // Verificação de autenticação (controle de acesso)
        if (!_autenticado)
        {
            Console.WriteLine("[Proxy] BLOQUEADO! Usuário não autenticado. Transferência negada.");
            return;
        }
 
        // Validação de regra de negócio
        if (valor > 10000m)
        {
            Console.WriteLine("[Proxy] BLOQUEADO! Transferências acima de R$10.000 precisam de aprovação extra.");
            return;
        }
 
        // Log antes da ação
        Console.WriteLine($"[Proxy] Permissão concedida. Registrando log: {_usuario} vai transferir R${valor}...");
 
        // Delega para o objeto real
        ObterContaReal().RealizarTransferencia(destinatario, valor);
 
        // Log após a ação
        Console.WriteLine("[Proxy] Operação finalizada. Log salvo.");
    }

     public decimal ConsultarSaldo()
    {
        Console.WriteLine($"\n[Proxy] Interceptando consulta de saldo de {_usuario}...");
 
        if (!_autenticado)
        {
            Console.WriteLine("[Proxy] BLOQUEADO! Acesso negado.");
            return 0;
        }
 
        // Aqui poderia ter um cache: se consultou recentemente, retorna o valor em cache
        Console.WriteLine("[Proxy] Autenticado. Buscando saldo real...");
        return ObterContaReal().ConsultarSaldo();
    }
}