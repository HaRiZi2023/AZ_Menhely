

## Table of Contents

- [Installation](#installation)
- [Swagger](#swagger)
- [History](#history)

## Installation

1. Composer telepítés
   
   `composer install`
   
2. Environment másolása:
   
   `cp .env.example .env`

3. Artisan telepítés:

   `php artisan install`

4. App key generálása:

   `php artisan generate:key`

5. Fejlesztői szerver indítása:

   `php artisan serve`

6. Swagger dokumentáció újragenerálása

   `php artisan l5-swagger:generate`

## Swagger

- /api/documentation oldalon elérhető a swagger UI
- Swagger dokumentáció /storage/api-docs/api-docs.json fájlban érhető el.

## History 

Version | Name    | Date     | Changes
     0.1| Cser    |2024-02-20| Backend mappa és readme elkészítése
     0.2| Szebeni |2024-03-03| Javítva Seedig
        | Szebeni |2024-03-03| Controllerek elkészítve
        | Szebeni |2024-03-03| TC elkezdve hiányos még nem működik!
     0.3| Szebeni |2024-03-05| Controllerek elkészítése 
        | Szebeni |2024-03-05| Controller javítva TS nem működik 
     0.4| Szebeni |2024-03-09| User kivételével migration, seed, location_hu, controller, routes, models, Thunder Client kész. TC exportálva.
     0.5| Szebeni |2024-03-17| .vs mappa törlése backend mappájából
     0.6| Cser    |2024-03-17| Spinnerek/GPS koordináták cimmé/újabb adatbázis próba sikertelenül
     0.7| Cser    |2024-03-19| Androidhoz szükséges módosítások. Felhasználói regisztráció/Bejelentkezés és az állatfelvétel backend
        | Cser    |2024-03-19| UserSeeder
     0.8| Cser    |2024-03-25| Found Tábla Androidhoz igazítva  
     0.9| Cser    |2024-03-26| backend visszaállírása az eredetire founds táblában 
    0.10| Cser    |2024-03-30| Fényképezéshez BLOB határok elvéve
    0.11| Szebeni |2024-04-10| 1. Guest, Worker -migráció módosítás- softdeletes, 
        | Szebeni |2024-04-10| 2. Adoption, Guest, Worker request készítés, 
        | Szebeni |2024-04-10| 3. Worker faktori - módosítás -permission
    0.12| Szebeni |2024-04-10| Worker model - hash
    0.13| Cser    |2024-04-10| User-AuthController Felhasználó autentikáció
    0.14| Cser    |2024-04-12| AuthController/Login method frissítése
    0.15| Cser    |2024-04-13| FoundController javítása
