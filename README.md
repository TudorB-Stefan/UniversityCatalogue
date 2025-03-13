# University Catalogue
Managing university data efficiently is a complex task, often requiring integration across multiple entities such as students, professors, courses, and attendance records. 
This project was built to create a structured and well-organized backend system that simplifies university management through a robust API.
This project addresses the need for a digitalized and systematic way to:
+ Keep track of students, courses, and their relationships.
+ Assign and manage teachers, including their roles and responsibilities.
+ Record student grades and their progression through academic years.
+ Monitor student attendance efficiently.

By implementing this API, universities or educational institutions can manage their administrative tasks more effectively.

## Technologies Used

ASP.NET Core Web API
Entity Framework Core (for ORM and database interactions)
SQL Server (for data storage)
Repository & Specification Patterns (for scalable and maintainable code)

## Instalation

Clone this repository:
```git clone https://github.com/TudorB-Stefan/UniversityCatalogue```

Navigate to the project directory and install dependencies:
```cd UniversityCatalog```
```dotnet restore```

Configure the database in `appsettings.json`.

Apply migrations:
```dotnet ef database update```

Run the application:
```dotnet run```

Access the API via Scalar.
