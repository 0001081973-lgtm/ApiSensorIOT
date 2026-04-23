# 📡 ApiSensoresIOT - Monitoramento de Sensores IoT

Esta é uma Web API desenvolvida em **ASP.NET Core** voltada para o gerenciamento e monitoramento de dispositivos/sensores IoT. A aplicação permite realizar o CRUD completo de sensores, utilizando processamento assíncrono e persistência em banco de dados (SQLite).

---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para configurar e rodar a API em seu ambiente local:

### 📋 Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (Versão 6.0 ou superior recomendada).
* IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/) ou [JetBrains Rider](https://www.jetbrains.com/rider/).
* Ferramenta para testes de API (opcional): [Postman](https://www.postman.com/) ou [Insomnia](https://insomnia.rest/).

### 🛠️ Passo a Passo

1.  **Clonar o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/ApiSensoresIOT.git](https://github.com/seu-usuario/ApiSensoresIOT.git)
    cd ApiSensoresIOT
    ```

2.  **Restaurar dependências:**
    ```bash
    dotnet restore
    ```

3.  **Executar a aplicação:**
    ```bash
    dotnet run
    ```

4.  **Acessar a documentação (Swagger):**
    Com a aplicação rodando, abra o navegador e acesse:
    `https://localhost:5001/swagger` (ou a porta indicada no seu console).

---

## 🛣️ Endpoints da API

A rota base da API é: `/api/Sensor`

### 1. Listar Sensores
Retorna a lista completa de sensores cadastrados para monitoramento geral.
* **Método:** `GET`
* **URL:** `/api/Sensor`
* **Sucesso:** `200 OK`

### 2. Buscar por ID
Retorna os detalhes de um sensor específico através do seu identificador único.
* **Método:** `GET`
* **URL:** `/api/Sensor/{id}`
* **Respostas:** * `200 OK`: Sensor localizado.
    * `404 Not Found`: Sensor não encontrado.

### 3. Cadastrar Sensor
Registra um novo dispositivo IoT no sistema.
* **Método:** `POST`
* **URL:** `/api/Sensor`
* **Corpo da Requisição (JSON):**
    ```json
    {
      "nome": "Sensor de Umidade A1",
      "tipo": "Umidade",
      "localizacao": "Estufa 01"
    }
    ```
* **Respostas:**
    * `201 Created`: Sensor criado com sucesso.
    * `500 Internal Server Error`: Erro ao persistir os dados.

### 4. Atualizar Sensor
Atualiza as informações de um sensor existente.
* **Método:** `PUT`
* **URL:** `/api/Sensor/{id}`
* **Corpo da Requisição (JSON):** Deve conter o `id` idêntico ao da URL.
* **Respostas:**
    * `204 No Content`: Atualização realizada com sucesso.
    * `400 Bad Request`: Inconsistência entre o ID da URL e o do corpo.
    * `500 Internal Server Error`: Erro no processamento.

### 5. Remover Sensor
Exclui permanentemente um sensor do banco de dados.
* **Método:** `DELETE`
* **URL:** `/api/Sensor/{id}`
* **Respostas:**
    * `200 OK`: Confirmação de remoção.
    * `404 Not Found`: Sensor não localizado para exclusão.

---

## 🏗️ Estrutura Técnica e Tecnologias

* **Linguagem:** C#
* **Framework:** ASP.NET Core (Web API)
* **Banco de Dados:** SQLite
* **Padrões de Projeto:**
    * **Injeção de Dependência:** Desacoplamento entre Controller e Service.
    * **Programação Assíncrona:** Uso de `Task` e `await` para escalabilidade.
    * **Swagger/OpenAPI:** Documentação interativa integrada.

---

## ✒️ Autor
* **Bruno Maia** - *Desenvolvedor* - [Seu GitHub](https://github.com/0001081973-lgtm/ApiSensorIOT)
