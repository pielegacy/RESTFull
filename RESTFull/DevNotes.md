# RESTFull Backend Developer Notes

## How to Run
To run this solution you need to have `.NET Core` installed, [use this link to install it](https://go.microsoft.com/fwlink/?linkid=843448). .NET Core is the same as your typical
.NET framework but it runs cross platform and everything can easily be done from the command line. The process for running a .NET Core application for the first time is very simple, all you need to is run the following commands in your projects directory with the .csproj file (use
powershell or command prompt)

```bash
dotnet restore
dotnet ef database update
dotnet watch run
```

Restore gets all the packages needed for the app and adds them to your directory, the database command will configure you a database for the project and run will run the server. Once this is
done you will only need to run `dotnet watch run` when you reopen your command prompt as this
will reload the project when a file is modified.

If specified in the commits, you may need to run restore and update if I have made any major changes.

## General Notes
- Development Tools (From My Experience)
    - You don't need VS but if you are using VS use VS2017 with .NET Core tools installed
    - I use [Visual Studio Code](https://code.visualstudio.com/) with the following extensions installed
        - C#
        - VS Code .csproj
- `Db.cs`
    - The Database object, use this to interact with the database.
    - Most efficient way to work with it is to do a `using` statement
        - `using (Db db = new Db()) { ... }`
    - Add `DbSet`'s to the Db object to add more tables
    - Directly message Billson over slack if you wish to do a database migration

## How to work with Models & Controllers

