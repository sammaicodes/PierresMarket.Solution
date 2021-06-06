# Pierre's Market

####  A Project Exploring Basic Many-to-Many Relationships With MVC C# and User-Authentication, Entity, and MySQL Workbench

#### By _**Sammai Gutierrez**_

## Technologies Used

* _GitHub_
* _VS Code_
* _ASP .NET Core MVC_
* _C#_
* _GitBash_
* _MySQL Workbench
* _Entity Framework_

## Description

_In brief, this project allows a user to add indefinite treats and add many flavors assigned to it. Flavors can also have many treats assigned to it . The user is able to add & delete one from each other and/or entirely from the app, and/or see its details._

## Pre-requisites

* _C#/.NET 5_
* _VS Code or another text editor of choice_
* _Internet browser_
* _An account with GitHub_
* _MySQL Workbench_
* _A command line interface (Terminal or GitBash) to run and interact with the application._

## Installation Instruction
1.  
    * _Clone the repository with command `$ git clone gitHub-URL-repository`_
    * _Open the repository on your computer in your text editor._
    * _Navigate to the PierresMarket folder & create a file called `appsettings.json`._
    * _Once inside `appsettings.json`, write the following code:_
        * _`{
              "ConnectionStrings": {
              "DefaultConnection": "Server=localhost;Port=3306;database=[NAME YOUR DATABASE HERE];uid=[MySQL USER-NAME HERE];pwd=[MySQL PASSWORD HERE];"
              }
            }`_
        * _Fill in the required info. (database name, MySQL user-name & password) without the squared brackets._
    * _Navigate to the PierresMarket folder and run the command `$dotnet ef database update`
    * _Still in the PierresMarket folder, run the command `$dotnet build`_
    * _To begin using the MVC application, run the command `$dotnet run`_
    * _Visit the app via the browser: 'localhost:5000/'_

## Known Bugs

* _Nothing yet_

## License

_MIT &copy; 2021 Sammai Gutierrez_
