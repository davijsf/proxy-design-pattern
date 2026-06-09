# Proxy Design Pattern
## O que é um Proxy?

**Imagine que você quer mandar uma mensagem para alguém, mas não quer revelar seu endereço. Você pede para um amigo mandar a carta por você. Esse amigo é o <ins>Proxy</ins> — ele fica no meio, entre você e o destinatário.**

> No mundo da programação, um <ins>Proxy</ins> é exatamente isso: um objeto que fica na frente de outro, interceptando e controlando o acesso a ele. Você não fala diretamente com o objeto real — você fala com o <ins>Proxy</ins>, e ele decide o que fazer.

### Três exemplos simples
> 1. O porteiro do prédio — Você quer visitar alguém no prédio. O porteiro (proxy) te para, verifica se você pode entrar, e só aí te deixa passar. Ele controla o acesso.

> 2. O tradutor — Você não fala inglês, então um tradutor (proxy) fica entre você e o americano. Tudo que você fala, ele traduz antes de chegar lá.

> 3. O garçom — Você quer pedir comida, mas não vai direto à cozinha. O garçom (proxy) anota seu pedido, leva à cozinha, e traz a resposta de volta.

---

## Proxy no Mundo Real: Conta Bancária

### Cenário

Imagine uma **conta bancária** onde você quer:
- ✅ Controlar quem pode acessar (autenticação)
- ✅ Limitar transferências acima de um valor (R$ 10.000)
- ✅ Criar o objeto da conta só quando necessário (lazy loading)
- ✅ Registrar logs de todas as operações

O **Proxy** vai ser o intermediário que faz tudo isso antes de chamar a conta real!

---

## Estrutura do Projeto
```
Proxy/
│
├── Interface/
│ └── IServicoBancario.cs # Interface que define os métodos
│
├── RealSubject/
│ └── ContaBancaria.cs # Objeto real (conta bancária verdadeira)
│
├── Proxy/
│ └── ProxyContaBancaria.cs # O proxy que controla o acesso
│
└── Program.cs # Exemplo de uso
```
