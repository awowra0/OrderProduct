# OrderProduct
WebAPI project created with .NET 10.  

## Features
CRUD for orders and products  
Relation many-to-many between orders and products  
Entity Framework Core  
SQL Server  
Asynchronous operations  
Swagger

## CI/CD
Workflow dotnet.yml runs after every push to main branch and does the following:  
  checkout code - clones entire repository  
  setup environment - installs .NET 10  
  restore dependencies - fetches NuGet packages  
  compilation - builds an application  
  test - runs all tests and stops pipeline after any failure  
  publish - generates binary files and creates an artifact
