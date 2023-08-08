# Listagem de Pessoas - Teste Esig Group.

### Projeto desenvolvido utilizando as tecnologias: Asp.Net Web Forms, Banco de Dados Oracle, Bootstrap e SweetAlert2. 

O sistema consiste em uma tela de login, que ao entrar no sistema apresenta uma listagem de pessoas com seus respectivos dados, uma coluna cargo e uma coluna salário, que por sua vez será calculada seguindo as orientações do teste, por uma procedure no banco de dados. 

### Para rodar o projeto localmente em sua máquina, por favor, siga as seguintes instruções:

### Instale os Softwares
- `Visual Studio 2019;`
- `Oracle Database;`
- `SQL Developer;`
- `Oracle Developer Tools;` 

### Configure seu Banco de Dados
- `Configure sua conexão conforme o arquivo Web.config;`
- `Crie as seguintes tabelas: Pessoa, Cargo, Vencimentos, Cargo_Vencimentos;`
- `Importe para as tabelas seus respectivos dados;`
- `Crie uma outra tabela Pessoa_Salario, ela será populada pela Procedure calcula_salarios;`
- `Crie uma tabela Usuarios com os campos: ID, NOME, USUARIO, SENHA e a popule com pelo menos um usuario para que possa realizar o login`;

Para executar o projeto, clone-o e certifique-se de configurar a string de conexão ao banco de dados Oracle no arquivo de configuração.
Por fim, compile o projeto no Visual Studio.
