Make a appsettings.json file

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=shop_finder_api;uid=[somerootoruser];pwd=[somepassword]"
  }
}

Make a appsettings.Development.json file
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}

to make a migration
$ dotnet ef migrations add Initial

to update the database with the migration
$ dotnet ef database update

seed data comes from OnModelCreating method