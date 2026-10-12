# SmallBiz

Zintegrowany system zarządzania małym przedsiębiorstwem — aplikacja webowa w technologii .NET, wzorowana na programie Small Business firmy Simplex. Projekt semestralny, rozwijany etapami.

> **Status:** wersja rozwojowa 0.1 — działa rejestracja i logowanie użytkowników, baza danych zawiera tabelę kontrahentów. Ekrany modułów są w przygotowaniu. Szczegóły: [dokumentacja projektu](docs/dokumentacja.md).

## Funkcje (docelowo)

- kartoteki kontrahentów (odbiorców i dostawców) oraz towarów i usług,
- faktury VAT z automatycznym wyliczaniem wartości netto, VAT i brutto oraz numeracją dokumentów,
- magazyn: stany towarów, przyjęcia (PZ) i wydania (WZ),
- kasa, bank i rozrachunki z kontrahentami,
- zamówienia, raporty, użytkownicy i role.

Moduły są ze sobą powiązane — np. wystawienie faktury zmniejsza stan magazynu i tworzy należność od klienta.

## Technologie

- .NET 10, ASP.NET Core Blazor Web App (tryb Interactive Server)
- Entity Framework Core 10 (Code First, migracje)
- Microsoft SQL Server (LocalDB)
- ASP.NET Core Identity
- Bootstrap 5

## Struktura repozytorium

```
Smallbiz.slnx            plik rozwiązania
src/Smallbiz.Domain/     model biznesowy (encje)
src/Smallbiz.Web/        aplikacja Blazor: interfejs, dostęp do danych, logowanie
docs/                    dokumentacja projektu
```

## Uruchomienie

Wymagania: Windows, .NET 10 SDK, SQL Server Express LocalDB (składnik instalowany przez Visual Studio Installer), narzędzie `dotnet-ef`.

```bash
dotnet tool install --global dotnet-ef
git clone https://github.com/bodzio28/smallbiz.git
cd smallbiz
dotnet ef database update --project src/Smallbiz.Web
dotnet run --project src/Smallbiz.Web
```

Aplikacja uruchamia się pod adresem `http://localhost:5268`. Polecenie `dotnet ef database update` tworzy bazę `Smallbiz` z pustymi tabelami na podstawie migracji. Po rejestracji konto potwierdza się linkiem wyświetlonym na stronie (aplikacja nie wysyła jeszcze e-maili).

Szczegółowa instrukcja i rozwiązania typowych problemów: [dokumentacja, rozdział 6](docs/dokumentacja.md#6-instalacja-i-uruchomienie).

## Autor

Bogdan Emodi, Piotr Czarnocki, Karol Jurewicz — projekt na przedmiot Dynamiczna analiza oprogramowania.
