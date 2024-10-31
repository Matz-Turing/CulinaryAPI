# Descrição da API de Receitas

<img src="https://user-images.githubusercontent.com/74038190/212284115-f47cd8ff-2ffb-4b04-b5bf-4d1c14c0247f.gif" width="1000">

## Visão Geral

Esta API foi desenvolvida para gerenciar receitas culinárias, permitindo operações básicas como listar, criar e obter detalhes de receitas específicas. Utilizamos a arquitetura ASP.NET Core com Entity Framework Core para a construção da API e integração com um banco de dados hospedado no Somee.

## Ferramentas Utilizadas

- **.NET 8**: A versão mais recente do framework .NET foi utilizada para construir a API.
- **Swagger**: Ferramenta integrada para documentação e testes de API, facilitando a visualização dos endpoints e suas funcionalidades.
- **Visual Studio Code**: Editor de código leve e versátil, utilizado para o desenvolvimento da aplicação.
- **Somee**: Plataforma de hospedagem utilizada para armazenar o banco de dados SQL.

## Estrutura da API

A API possui um controlador `ReceitasController` que gerencia as operações relacionadas às receitas. Abaixo estão os principais endpoints disponíveis:

- **GET /api/Receitas**: Retorna uma lista de todas as receitas, incluindo suas categorias.
- **GET /api/Receitas/{id}**: Retorna detalhes de uma receita específica com base no seu ID.
- **POST /api/Receitas**: Cria uma nova receita no banco de dados.

## Construção da API

### 1. Criar projeto Web API

Iniciamos a construção da API criando um novo projeto do tipo Web API utilizando o Visual Studio Code. Isso forneceu a estrutura básica necessária para desenvolver nossa aplicação, incluindo arquivos de configuração e bibliotecas padrão.

### 2. Criar classes Models

Criamos as classes modelo `Receita` e `Categoria`, que representam as tabelas do nosso banco de dados. Essas classes contêm propriedades que mapeiam os campos do banco de dados, permitindo que o Entity Framework Core faça a correspondência entre objetos C# e registros no banco de dados.

```csharp
public class Receita
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int TempoPreparo { get; set; }
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Receita> Receitas { get; set; }
}
```

### 3. Criar classe DataContext para mapeamento do banco de dados

Criamos uma classe `DataContext` que herda de `DbContext`, a qual serve como o contexto principal para interagir com o banco de dados. Essa classe contém propriedades do tipo `DbSet` para cada modelo que criamos, permitindo que o Entity Framework Core gerencie as operações de leitura e gravação.

```csharp
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
```

### 4. Criar relacionamentos (Migrações e scripts)

Definimos os relacionamentos entre as tabelas usando anotações de dados nas classes modelo e configurando as migrações com o Entity Framework Core. Após isso, executamos comandos para gerar e aplicar as migrações, criando as tabelas correspondentes no banco de dados. Utilizamos scripts SQL para inicializar o banco de dados com dados de exemplo, garantindo que tivéssemos informações disponíveis para testar nossa API.

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Criar Controllers para testar a API

Implementamos o controlador `ReceitasController`, que gerencia as operações relacionadas às receitas. Os métodos HTTP (GET, POST) foram criados para permitir a interação com a API, permitindo que os usuários listem todas as receitas, obtenham detalhes de uma receita específica e criem novas receitas.

```csharp
[ApiController]
[Route("api/[controller]")]
public class ReceitasController : ControllerBase
```

### 6. Gerar documentação da API no Swagger

Integramos o Swagger à nossa aplicação para fornecer documentação interativa da API. Ao iniciar a aplicação, uma interface Swagger é gerada automaticamente, permitindo que os desenvolvedores visualizem os endpoints disponíveis e testem as funcionalidades da API diretamente do navegador.

## Testando a API

Para testar a API, siga os passos abaixo:

1. **Inicie a API**:
   - Execute a aplicação localmente utilizando o comando `dotnet run` no terminal. A API será iniciada, e você verá a URL local (ex: `http://localhost:5021`).

2. **Acesse o Swagger**:
   - Abra seu navegador e navegue até a URL do Swagger: `http://localhost:5021/swagger/index.html`. Aqui, você poderá visualizar todos os endpoints disponíveis.

3. **Realize Requisições**:
   - Utilize os métodos GET e POST disponíveis para interagir com a API.
   - Por exemplo, para obter todas as receitas, clique no método GET `/api/Receitas`, clique em "Try it out" e depois em "Execute".

4. **Verifique as Respostas**:
   - As respostas das requisições aparecerão na parte inferior da interface do Swagger, onde você poderá ver os dados retornados pela API.

5. **Testes com o Somee**:
   - Caso tenha o banco de dados hospedado no Somee, certifique-se de que a configuração de conexão está correta no seu projeto para permitir operações remotas.

## Conclusão

Esta API de Receitas é um projeto básico, ideal para entender os fundamentos do desenvolvimento de APIs RESTful com ASP.NET Core. Com a integração do Swagger, o processo de testes e documentação fica mais fácil e acessível. Sinta-se à vontade para contribuir ou modificar o projeto conforme suas necessidades!

## Créditos

Desenvolvido por Mateus S.  
GitHub: [Matz-Turing](https://github.com/Matz-Turing)
