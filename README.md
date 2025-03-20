# skeleton_dotnet

## Update Migrations

Inside root folder, 1 level with .sln file, run this command.
Also, set connection string to your database.


```shell
dotnet ef database update --project Skeleton\Skeleton.csproj --startup-project Skeleton.MasterApi\Skeleton.MasterApi.csproj --context Skeleton.Infrastructure.Data.ApplicationDbContext --configuration Debug 20250320071206_Initial
```

This migration use SQL Server 2019 when generated.