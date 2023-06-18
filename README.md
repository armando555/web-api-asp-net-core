# web-api-asp-net-core
this is a sample for making a a api over asp.net core
Usefull commands

This command is for creating a reference between two projects 
```bash
dotnet add reference project_path
```

This command is for adding new package from nuget repository to the project
```bash
dotnet add package package_name
```


# Migrations manage
## Notes: don't forget run this command from webApi project and create the database

Create a migration
```bash
dotnet ef migrations add --project ../Infrastructure/ migration_name
```

Run the migration in database
```bash
dotnet ef database update -p ../Infrastructure/
```