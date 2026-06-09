namespace Interface;

// ---------------------------------------------------------
// 1. INTERFACE COMUM
//    Tanto o Proxy quanto o Objeto Real implementam essa interface.
//    O cliente só conhece essa interface — não sabe se está
//    falando com o proxy ou com o objeto real.
// ---------------------------------------------------------

public interface IServicoBancario
{
    void RealizarTransferencia(string destinatario, decimal valor);
    decimal ConsultarSaldo();
}