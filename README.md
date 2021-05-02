# AgendaDeContatos
1 - Realizar o download do projeto TesteAgenda

2 - com o projeto aberto no visual studio vá na aba -> Ferramentas -> Conectar-se a um banco de dados

3 - Verifique a opção "Fonte de Dados", deve estar em Arquivo de Banco de Dados do Microsoft SQL Server

4 - Clique em Procurar

5 - Acesse a pasta do projeto e Selecione o banco de dados BancoAgenda

6 - Encontre o endereço do servidor em Exibir -> Gerenciador de Servidores ou Tecla de atalho Ctrl+Alt+S

7 - Selecione o servidor BancoAgenda e vá na aba de propriedades

8 - Copie o conteúdo de Cadeia de Conexão

9 - Abra o Script de Conexao, identifique a linha 11
private String _stringConexao = "Data Source=(LocalDB)\\MSSQLLocalDB;(...)";

10 - Altere o conteúdo da linha descrita acima, entre as Aspas (") insira o conteudo copiado em Cadeia de Conexão 
preenchendo com uma barra (\) para que o código consiga interpretar corretamente

Quando copiar por padrão estará com 1 barra assim:
DataSource=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ProjetosC#\TesteAgenda\Banco
Agenda.mdf;Integrated Security=True;Connect Timeout=30

Para que funcione deve ser inserido mais uma barra em todos os campos ficando
assim:
DataSource=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\ProjetosC#\\TesteAgenda\\Ban
coAgenda.mdf;Integrated Security=True;Connect Timeout=30

11 - Verifique a Aba NuGet Packages clicando com o direito no projeto e caso não tenha disponivel instale
System.Data.SqlClient by Microsoft

12 - Após realizar os procedimentos acima execute o projeto.


