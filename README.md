# Webdev BE Project 001

Tech: .NET 7 + EF (code first)

## How to run

- in VS -> Package Manager Console -> `Add-Migration InitialCreate` -> `Update-Database`
- in VS -> Terminal -> locate to where can see `Program.cs` -> `dotnet run seeddata`

## Reference

- <https://www.youtube.com/watch?v=_8nLSsK5NDo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0>

## Explain

### Program entry point

- DI and all three A

### Controllers

- why use `DTO`: not returns all the DB + limit data that client send
- `IActionResult`:
- `ModelState`:

### Models

- `namespace`:
- `IClt` vs `IList`
  - `IClt` can only be shown, read

### Config

- `appsettings.json`:
  - contains conn string here

### Seeding

- `Add-Migration InitialCreate` -> `Update-Database` -> `dotnet run seeddata` at the location of `Program.cs`

## Notes

- update ops can't update relationships, only update core fields

<details>
<summary>How to get a connection string</summary>

1. VS -> Search bar -> SQL Server Object Explorer -> click icon Add SQL Server
2. Go to SQL Server Manga Studio -> Props -> get the Name (e.g. DESKTOP-123ABC)
3. After establish conn in VS, Props the desired DB -> Find the ConnStr in there

</details>
