## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new type -o project_name```
* ```dotnet sln solution_name.sln add ./project_name/project_name.csproj```
* ```dotnet new gitignore```

## Adicionando Dependências entre os Projetos

* ```dotnet add ./project_name/project_name.csproj reference ./project_name/project_name.csproj```

## Executando o Projeto

* ```dotnet run --project project_name```