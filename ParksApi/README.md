# _Parks Api_

#### By: _**Lucas Mollerstuen**_

![My Remote Image](https://user-images.githubusercontent.com/115112679/213813408-5c9d1630-4a2e-40c5-befc-408b3a8810cc.png)

#### _Files, Code, and setup with comments for using Identity and Roles to add to projects._

## Technologies Used



* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)_
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL](https://dev.mysql.com/)
* [Entity Framework Core 6.0.0](https://docs.microsoft.com/en-us/ef/core/)
* [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio)
* [Postman](postman.com)


### Description
An API that functions as a State and National archive for parks and recreational areas. It utilizes RESTful principles, version control, pagination, and has simi integrated authentication to keep the API Read-Only for all users except administrators. The user is able to see the in-use version of the API when using Postman or Swagger.

## Setup/Installation Requirements

* _Clone the repository to your desktop from: https://github.com/oz-mollerstuen/ParksApi.Solution.git_
* _Create appsettings.json file in ASPNETIdentityRoles folder_

```
{
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=[USERNAME];pwd=[PASSWORD];"
    }
  }

```
* _run dotnet commands below in _ParksApi_
```
dotnet restore
```
```
dotnet ef database update
```
```
dotnet watch run
```
 #### Launch the API
  1) Navigate to ParksApi.Solution/TravelApi directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/ParksApi.Solution/ParksApi`).
  2) Run the command `dotnet run` to have access to the API in Postman or browser.

------------------------------

## API Documentation
Explore the API endpoints in Postman or a browser using Swagger. You will not be able to utilize authentication in a browser.

### Using Swagger Documentation 
To explore the Parks-Api with swagger, launch the project using `dotnet watch run` with the Terminal or Powershell.

### Endpoints
Base URL: `https://localhost:5001`

#### HTTP Request Structure
```
GET /api/{component}
PUT /api/{component}
DELETE /api/{component}/{id}
GET /api/{component}/{id}
POST /api/{component}/{id}
```

#### Example Query

```
https://localhost:7213/api/Parkrec/2

```

#### Sample JSON Response
``` 
{
  "parkrecId": 2,
  "name": "Champoeg",
  "tipes": null
}
```

#### Example Query

```
https://localhost:7213/api/Tipe/3

```
#### Sample JSON Response
``` 
{
  "tipeId": 3,
  "summary": "State Park",
  "rating": 8,
  "parkrecId": 2
}
```

## Known Bugs

* _Branch "Further" will not run_


# Branch "Further" was created as a further exploration into Authentication using a token based system:

### Research done using:
* [Microsoft](https://learn.microsoft.com/en-us/dotnet/api/system.identitymodel.tokens.securitytokenhandler.validatetoken?view=netframework-4.8.1)_
* [DotNet Tutorials](https://dotnettutorials.net/lesson/token-based-authentication-web-api/)
* [StackOverflow](https://stackoverflow.com/questions/44808800/how-do-i-manually-validate-a-jwt-asp-net-core)
* [Dev](https://dev.to/moe23/refresh-jwt-with-refresh-tokens-in-asp-net-core-5-rest-api-step-by-step-3en5)

### While "Further" has yet to work in such a small amount of time I know that I will get it there soon, and will, hopefully, be using it in my next project.  

## License

_Copyright (c) 2023 Lucas Mollerstuen_

_Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
