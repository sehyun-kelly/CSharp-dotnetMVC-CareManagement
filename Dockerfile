FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out


#for elastik beanstalk
EXPOSE 80 
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.0
WORKDIR /App
COPY --from=build-env /App/out .
#ENTRYPOINT ["dotnet", "CareManagement.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CareManagement.dll