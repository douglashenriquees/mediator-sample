## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new type -o project_name```
* ```dotnet sln solution_name.sln add ./project_name/project_name.csproj```
* ```dotnet new gitignore```

## Adicionando Dependências entre os Projetos

* ```dotnet add ./project_name/project_name.csproj reference ./project_name/project_name.csproj```

## Executando o Projeto

* ```dotnet run --project project_name```

## Executando o Container do SqlServer

* ```docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=strongpass" -p 1433:1433 -d --name my-mssql mcr.microsoft.com/mssql/server:2022-latest```
* ```docker exec -it my-mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P strongpass```