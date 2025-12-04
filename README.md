# Desafio TOTVS - Live Coding

Este repositório contém um projeto de **desafio de Live Coding**, utilizando .NET 8, Angular 16+ e PostgreSQL, configurado dentro de um **DevContainer** para facilitar o desenvolvimento em qualquer máquina.

---

## Primeiros passos

Siga os passos abaixo para configurar e rodar o projeto localmente:

1. **Iniciando o projeto no codespace (VS Code)**
- Certifique-se de que os **Dev Container** será compilado adequadamente.
- Acompanhe as  execuções no Terminal e na aba Saída",  lá será informado os passos que foram  executados e se houve êxito na  compilação.

- O container já contém:
  - .NET 8
  - Angular CLI 16+
  - Node.js 18
  - PostgreSQL
- As portas configuradas são:
  - Backend: `5000`
  - Frontend: `4200`
  - PostgreSQL: `5432`

4. **Inicialize o backend**
```bash
cd src/backend
dotnet watch run
```

5. **Inicialize o frontend**
```bash
cd src/frontend
npm install
ng s -o
```

6. **Acesse a aplicação**
- Backend (Swagger): `http://localhost:5000/swagger`
- Frontend Angular: `http://localhost:4200`

7. **Consultas ao banco**
- Caso precise realizar alguma consulta ao banco de dados, segue abaixo alguns  exemplos de comandos:
```bash
#acessando o banco de dados (senha postgres)
psql -h localhost -U postgres -d pedidos_db

#consultando dados
SELECT * FROM public."__EFMigrationsHistory";
SELECT * FROM public."Pedidos";

#listando todas as tabelas
\dt
```

8. **Executando comando EF Migration**
Para adicionar um migration execute os comandos abaixo:
```bash
#criando nova migration
dotnet ef migrations add <nome_script>

#removendo migration
dotnet ef migrations remove 2025120481814_InitialCreate

```
---

## Tecnologias

O projeto utiliza as seguintes tecnologias:

- **.NET 8** - Backend e API REST
- **Entity Framework Core** - ORM e Migrations
- **Angular 16+** - Frontend SPA
- **Node.js 18 & NPM** - Ambiente de frontend
- **PostgreSQL** - Banco de dados relacional
- **DevContainer** - Ambiente de desenvolvimento containerizado
- **Docker** - Para isolamento do ambiente

---

## Desafio Live Coding

O objetivo deste projeto é servir como base para um **desafio de Live Coding**, testando:

- Criação de APIs REST com .NET 8
- Mapeamento de entidades com Entity Framework Core
- Uso de Migrations e Seed de dados
- Criação de um frontend Angular simples consumindo a API
- Uso de DevContainer para padronização do ambiente de desenvolvimento
- Boas práticas de clean code e solid

### Case
O projeto é um E-commerce de produtos de tecnologia e informática, onde os usuários podem:

- Visualizar produtos (hardware, periféricos, acessórios, softwares, etc.)
- Adicionar produtos ao carrinho
- Criar pedidos (checkout)
- Consultar seus pedidos
- Realizar ações básicas de CRUD (Create, Read, Update, Delete) em produtos e pedidos

### Resolva os Desafios

1. **Refactoring:**
o projeto possui na controller "Pedidos", há um endpoint para excluir o pedido pelo identificador, porém há problemas de performance boas práticas que precisam ser corrigidas. Refatore a operação considerando: 

   - Aplica plenos um exemplo de Clean Code;
   - Aplicar pelo menos um exemplo de melhoria de performance;
   - Garantir que a remoção de APENAS 1 item seja executada;
   - Garantir que os retornos e status code estejam de acordo com os padrões REST.

2. **Garantindo adequação ao negócio com boas práticas:** na controller "Pedidos", há um endpoint realiza a adição de pedidos de acordo com os itens selecionado pelo comprador e desconto aplicado. Realiza incrementos de implementação para:

   - Aplicar ao menos um princípio SOLID;
   - Calcular o total de pedido, somando os preços do itens selecionados e subtraindo o percentual de desconto aplicado;
   - Layout simples usando CSS puro para demonstração;
   - Componentes básicos de listagem de produtos e pedidos.

3. **BUG encontrado:** Um cliente identificou um erro ao tentar fazer um pedido onde o item Id **6** havia sido selecionado no carrinho. Realize a correção baseando-se nos seguintes critérios:

   - Simule o erro e identifique a causa raiz do problema;
   - Elabore uma solução considerando que a criação de pedido de compor qualquer item selecionado que esteja cadastrado como um produto;
   - Aplique as alterações necessárias via código ou banco, se atendando ao uso de abordagem *code first*;

4. **Aplicando regras de negócio:** O PO necessita que seja criado uma forma de atualizar os dados do pedido. Para isso realize uma implementação com os seguintes critérios:

   - Crie um endpoint para atualizar o Pedido;
   - Caso o pedido não tenha sido encontrado retornar o status code correto;
   - O PO definiu que os pedidos só poderão ser editados caso o pedido ainda esteja "no carrinho";
   - Retorne as mensagem corretas ao usuário de acordo com as regras aplicadas.

### Considerações finais

Atente-se a resolver os problemas conforme o tempo estipulado, porém não se preocupe caso não consiga chegar até o final, o importante é que esclareça o que foi feito. Ao final do desafio algumas perguntas serão realizadas para entendermos melhor como chegou a determinada solução.

# Boa Sorte!

“May the force be with you!”



> **Observação:** Este projeto é um **exemplo de desafio técnico**, focado em testar habilidades de backend, frontend e uso de containers, sem se preocupar com produção ou escalabilidade.
