
Initialize a local sqlite storage for strategy configurations.

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```


Run the app:
```
dotnet run
```
