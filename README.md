# ReelRegistry

A C# console application for managing a movie registry in SQL Server. The application uses ADO.NET for database access and Spectre.Console for its menus and tables.

## Features

- View all movies with their release year and genre.
- Search for movies by genre.
- Add a movie and select an existing genre from the database.
- Remove a selected movie.

## Requirements

- .NET 10 SDK
- SQL Server accessible as `localhost` with Windows authentication
- A database named `ReelRegistryDb`

## Database setup

Create the database and tables manually in SQL Server Management Studio before running the application.

| Table | Columns |
| --- | --- |
| `Genre` | `Id` (int, primary key, identity), `Name` (nvarchar, not null) |
| `Movie` | `Id` (int, primary key, identity), `Title` (nvarchar(100), not null), `ReleaseYear` (int, not null), `GenreId` (int, foreign key, not null) |

Create a foreign key from `Movie.GenreId` to `Genre.Id`. Each movie must reference an existing genre, and multiple movies can share the same genre.

Add genres and sample movies so all features can be tested. The search menu currently contains these genre names: `Action`, `Comedy`, `Drama`, `Horror`, and `Sci-Fi`. Use these names for the corresponding database genres.

### Database relationship

The SQL Server diagram shows the relationship between the `Movie` and `Genre` tables.

![Movie and Genre database relationship](docs/images/database-diagram.png)

### Movie columns

The table definition shows that `GenreId` is a foreign key and does not allow NULL values.

![Movie columns showing GenreId as a non-null foreign key](docs/images/movie-columns.png)

## Project structure

| File or folder | Responsibility |
| --- | --- |
| `Program.cs` | Starts the application |
| `Services/` | Coordinates menu choices and operations |
| `UI/` | Displays menus and tables and collects input |
| `Repositories/` | Reads and changes database records using ADO.NET |
| `Models/` | Represents movies and genres |
| `Data/` | Holds the database connection configuration |

Database access is separated from the user interface. Queries use `SqlConnection`, `SqlCommand`, and `SqlDataReader`. Search, insert, and delete operations use SQL parameters. Connections, commands, and readers are disposed through `using` declarations.

## Manual testing

With sample records in the database:

1. View all movies and check that each row includes its genre name.
2. Search by genre and check that only matching movies are displayed.
3. Add a movie using an existing genre, then view the list to confirm it appears.
4. Remove that movie, then view the list to confirm it is gone.
5. Select Exit to close the application.
