FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
EXPOSE 80

COPY ./publish /app/

ENTRYPOINT ["dotnet", "BackOffice.Admin.API.dll"]