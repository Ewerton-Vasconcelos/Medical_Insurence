# Medical_Insurence API

API RESTful desenvolvida com ASP.NET Core para o gerenciamento de beneficiários e atendimentos médicos. Utiliza MySQL como banco de dados e Dapper para consultas ao mesmo.

---

## Tecnologias

- ASP.NET Core 7/8
- MySQL
- Dapper
- Swagger
- Entity Framework Core (para migrations)
- Visual Studio ou VS Code

---

## Requisitos

- .NET SDK instalado
- MySQL Server rodando localmente
- Ferramenta como Postman ou Swagger para testar os endpoints

---

## Clonando o repositório

```bash
git clone https://github.com/Ewerton-Vasconcelos/Medical_Insurence.git
cd Medical_Insurence
```

---

## Configuração

1. **Crie o banco de dados MySQL**:

```sql
CREATE DATABASE medicalinsurence;
```

2. **Atualize a string de conexão em `appsettings.json`**:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost; port=3306; database=medicalinsurence; user=root; password=sua_senha"
}
```

3. **Execute as migrations (se necessário):**

```bash
dotnet ef database update --context MedDbContext
```

---

## Executando o projeto

```bash
dotnet run
```

Acesse via navegador: [http://localhost:3000/swagger](http://localhost:3000/swagger)

---

## Pacotes utilizados

```bash
dotnet add package Microsoft.AspNeCore.OpenApi --version 8.0.2
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.2
dotnet add package Pomelo.EntityFrameworkCore.MySql.Json.Microsoft --version 8.0.2
dotnet add package Dapper --version 2.1.35
dotnet add package Swashbuckle.AspNetCore --version 7.3.2
dotnet add package Swashbuckle.AspNetCore.Swagger --version 7.3.2
dotnet add package Swashbuckle.AspNetCore.SwaggerGen --version 7.3.2
dotnet add package Swashbuckle.AspNetCore.SwaggerUI --version 7.3.2
```

---

## Endpoints disponíveis

| Método | Rota                               | Descrição                                              |
| ------ | ---------------------------------- | ------------------------------------------------------ |
| POST   | /api/Beneficiary/AddBeneficiary    | Adiciona um novo beneficiário                          |
| GET    | /api/Beneficiary/AllBeneficiaries  | Retorna todos os beneficiários                         |
| GET    | /api/Beneficiary/FirstSql          | Beneficiários ativos com ≥ 3 atendimentos em 12 meses  |
| GET    | /api/Beneficiary/SecondSql         | Tipos de atendimentos por beneficiários                |
| GET    | /api/Beneficiary/ThirdSql          | Top 5 beneficiários com mais atendimentos              |
| GET    | /api/Beneficiary/AverageAgeBenef   | Idade média dos beneficiários ativos                   |
| GET    | /api/Beneficiary/NotAtendEighteen  | Beneficiários que não se consultam há 18 meses         |
| GET    | /api/Report/QtdTypeAtend           | Quantidade total de atendimentos por tipo              |
| GET    | /api/Report/AvgAtendBenef          | Média de atendimentos por beneficiário ativo           |
| GET    | /api/Report/BenefNotAtend          | Beneficiários sem atendimento nos últimos 12 meses     |
| POST   | /api/LogicQuestions/CalculedScore  | Recebe lista de atendimentos e retorna pontuação total |
| POST   | /api/LogicQuestions/ValidationCard | Valida número de carteirinha no formato XXX-YYYYYY     |
| POST   | /api/LogicQuestions/DateSixMonth   | Verifica se intervalo entre exames é maior que 6 meses |
| POST   | /api/PatientCare/AddPatientCare    | Adiciona um atendimento ao beneficiário                |

---

## Licença

Este projeto não possui licença.
