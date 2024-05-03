# Backend README

## WIKI oldal

Látogasd meg a [Projekt Wiki](https://github.com/HaRiZi2023/AZ_Menhely/wiki) weboldalt
vagy az [AZ Menhely Backend Wiki](https://github.com/HaRiZi2023/AZ_Menhely/wiki/Backend) weboldalt.

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

   `php artisan key:generate`

5. Fejlesztői szerver indítása:

   `php artisan serve`

6. Swagger dokumentáció újragenerálása

   `php artisan l5-swagger:generate`

## Swagger

- /api/documentation oldalon elérhető a swagger UI
- Swagger dokumentáció /storage/api-docs/api-docs.json fájlban érhető el.

## History 

- Version | Name    | Date     | Changes
1.     0.1| Cser    |2024-02-20| Backend mappa és readme elkészítése
2.     0.2| Szebeni |2024-03-03| Javítva Seedig
          | Szebeni |2024-03-03| Controllerek elkészítve
          | Szebeni |2024-03-03| TC elkezdve hiányos még nem működik!
3.     0.3| Szebeni |2024-03-05| Controllerek elkészítése 
          | Szebeni |2024-03-05| Controller javítva TS nem működik 
4.     0.4| Szebeni |2024-03-09| User kivételével migration, seed, location_hu, controller, routes, models, Thunder Client 
                                 kész. TC exportálva.
5.     0.5| Szebeni |2024-03-17| .vs mappa törlése backend mappájából
6.     0.6| Cser    |2024-03-17| Spinnerek/GPS koordináták cimmé/újabb adatbázis próba sikertelenül
7.     0.7| Cser    |2024-03-19| Androidhoz szükséges módosítások. Felhasználói regisztráció/Bejelentkezés és az 
                                 állatfelvétel backend
          | Cser    |2024-03-19| UserSeeder
8.     0.8| Cser    |2024-03-25| Found Tábla Androidhoz igazítva  
9.     0.9| Cser    |2024-03-26| backend visszaállírása az eredetire founds táblában 
10.     0.10| Cser    |2024-03-30| Fényképezéshez BLOB határok elvéve
11.     0.11| Szebeni |2024-04-10| 1. Guest, Worker -migráció módosítás- softdeletes, 
            | Szebeni |2024-04-10| 2. Adoption, Guest, Worker request készítés, 
            | Szebeni |2024-04-10| 3. Worker faktori - módosítás -permission
12.     0.12| Szebeni |2024-04-10| Worker model - hash
13.     0.13| Cser    |2024-04-10| User-AuthController Felhasználó autentikáció
14.     0.14| Cser    |2024-04-12| AuthController/Login method frissítése
15.     0.15| Cser    |2024-04-13| FoundController javítása
16.     0.16| Szebeni |2024-04-14| Sok minden
17.     0.17| Szebeni |2024-04-16| Chip
            | Szebeni |2024-04-16| Worker, Login
            | Szebeni |2024-04-16| chip, guest, login
            | Szebeni |2024-04-16| choice, guest
18.     0.18| Szebeni |2024-04-17| login
            | Szebeni |2024-04-17| chip, found, choice
19.     0.19| Szebeni |2024-04-19| képek
            | Szebeni |2024-04-19| found, kép félkész
20.     0.20| Szebeni |2024-04-20| Adoption, guest, user
            | Szebeni |2024-04-20| Adoption, guest, choice
21.     0.21| Szebeni |2024-04-21| Guest
            | Szebeni |2024-04-21| Found, adpotion kép ok
            | Szebeni |2024-04-21| adatbázisba base64 képek, choice, found, guest, routes, képek mappába
22.     0.22| Szebeni |2024-04-24| hiba keresés
23.     0.23| Cser    |2024-04-25| AuthController message update
            | Cser    |2024-04-25| FoundController store->storeFound; api routes update
24.     0.24| Cser    |2024-04-27| Add RoleEnum, Role oszlop, tulajdonság, rules
            | Cser    |2024-04-27| UserFactory módosítása a role tulajdonsággal seedhez
25.     0.25| Szebeni |2024-04-27| javítás
26.     0.26| Cser    |2024-04-27| Unique email role-hoz kötve
            | Cser    |2024-04-27| Unique kiszedve az else ágból
27.     0.27| Szebeni |2024-04-27| JAvítások user worker egybeolvasztás után
            | Szebeni |2024-04-27| Javítások
28.     0.28| Cser    |2024-04-28| Swagger AuthController, FoundController
