## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new type -o project_name```
* ```dotnet sln solution_name.sln add ./project_name/project_name.csproj```
* ```dotnet new gitignore```

## Adicionando Dependências entre os Projetos

* ```dotnet add ./project_name/project_name.csproj reference ./project_name/project_name.csproj```

## Executando um Projeto

* ```dotnet run --project project_name```

## Executando o Container do SqlServer *"Mac OS"*

* ```docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Strong@pass' -p 1433:1433 --name mssql-mediator -d mcr.microsoft.com/azure-sql-edge```

## Migrations

* ```dotnet tool update --global dotnet-ef```
* ```dotnet ef migrations add initial --project project_name```
* ```dotnet ef database update --project project_name --connection "connection_string"```
