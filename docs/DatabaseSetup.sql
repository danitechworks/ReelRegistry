CREATE DATABASE ReelRegistryDb;
GO

USE ReelRegistryDb;
GO

CREATE TABLE dbo.Genre
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE dbo.Movie
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    ReleaseYear INT NOT NULL,
    GenreId INT NOT NULL,

    CONSTRAINT FK_Movie_Genre
        FOREIGN KEY (GenreId)
        REFERENCES dbo.Genre(Id)
);
GO

INSERT INTO dbo.Genre (Name)
VALUES
    (N'Action'),
    (N'Comedy'),
    (N'Drama'),
    (N'Horror'),
    (N'Sci-Fi');
GO

INSERT INTO dbo.Movie (Title, ReleaseYear, GenreId)
SELECT seed.Title, seed.ReleaseYear, genre.Id
FROM
(
    VALUES
        (N'Alien', 1979, N'Sci-Fi'),
        (N'The Matrix', 1999, N'Sci-Fi'),
        (N'The Shining', 1980, N'Horror'),
        (N'Låt den rätte komma in', 2008, N'Horror'),
        (N'Die Hard', 1988, N'Action'),
        (N'Jägarna', 1996, N'Action'),
        (N'Groundhog Day', 1993, N'Comedy'),
        (N'Hundraåringen som klev ut genom fönstret och försvann',
         2013, N'Comedy'),
        (N'The Shawshank Redemption', 1994, N'Drama'),
        (N'En man som heter Ove', 2015, N'Drama')
) AS seed (Title, ReleaseYear, GenreName)
INNER JOIN dbo.Genre AS genre
    ON genre.Name = seed.GenreName;
GO