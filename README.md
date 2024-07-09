# Attendance Master

This is made with React.js as the frontend, with C# (ASP.NET) and MSSQL for the backend.

Frontend is stored in the `client` folder while the backend is stored in the `server` folder.

Add your MSSQL connection string in the [appsettings.json](/Server/appsettings.json) file by changing the `HIDDEN` text

If you want to use another RDBMS (instead of MSSQL) then install the [Entity Framework Core NuGet package](https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli) for it, swap out all references to the MSSQL Entity Framework Core library with yours, and (hopefully) it should be compatable with the rest of the code :)

By the way, if you spot a security error, please create an issue ASAP and I'll get to it.

Made by [Valentina Banner](https://realhuman101.github.io/)
