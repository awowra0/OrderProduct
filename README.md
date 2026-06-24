# OrderProduct
WebAPI project created with .NET 10.  

## Features
-  CRUD for orders and products  
-  Relation many-to-many between orders and products  
-  Entity Framework Core  
-  SQL Server via Azure  
-  Asynchronous operations  
-  Swagger  
-  CI/CD workflow  
-  Azure services  

## CI/CD
Workflow dotnet.yml runs after every push to main branch and does the following:  
-  checkout code - clones entire repository  
-  setup environment - installs .NET 10  
-  restore dependencies - fetches NuGet packages  
-  compilation - builds an application  
-  test - runs all tests and stops pipeline after any failure  
-  publish - generates binary files  
-  artifact - creates an artifact  

-  download artifact - prepares generated artifact  
-  deploy - publishes new version of the application to Azure  

## Usage
Main page access:  
-  https://orderproduct-project.azurewebsites.net/  
  
Swagger:  
-  https://orderproduct-project.azurewebsites.net/swagger  
  
GET Endpoints:  
-  https://orderproduct-project.azurewebsites.net/api/product
-  https://orderproduct-project.azurewebsites.net/api/product/{id}
-  https://orderproduct-project.azurewebsites.net/api/order
-  https://orderproduct-project.azurewebsites.net/api/order/{id}

## Used Azure services
-  Azure Resource Group  
-  Azure SQL Database  
-  Azure SQL Server  
-  Azure App Service  

## Configuration
-  Azure App Service - ConnectionStrings__DefaultConnection  
-  Github Secret Action - AZURE_WEBAPP_PUBLISH_PROFILE
