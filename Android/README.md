# Android README

## WIKI oldal

Látogasd meg a [Projekt Wiki](https://github.com/HaRiZi2023/AZ_Menhely/wiki) weboldalt
vagy az [AZ Menhely Android Wiki](https://github.com/HaRiZi2023/AZ_Menhely/wiki/Android) weboldalt.

## Információ

### Applikáció célja

- Az applikáció célja, hogy gyors, egyszerű és könnyen kezelhető lehetőséget nyújtson azon felhasználók számára, akik a mindennapi életük során szeretnék bejelenteni talált vagy éppen elveszett állatot.

### Applikáció működése

<img width="499" alt="Folyamat" src="https://github.com/HaRiZi2023/AZ_Menhely/assets/127030468/69e310b8-a6b4-433a-8e83-fffa5d8e3a8f">

### Applikáció felépítése

* [Javadoc](https://github.com/HaRiZi2023/AZ_Menhely/Android/AnimalRescue/doc/index.html)

### Kockázatok és kihívások

* A mobilalkalmazás és a szerveroldali komponens (adatbázis) közötti kapcsolatok
* GPS-koordináták olvasása
* Kép készítése funkció (kamera engedélyezés, konvertálás)
* A felhasználó ellenőrzése bejelentkezéskor(autentikáció)
* A tanulmányok során nem tanult, vagy csak érintett témakörök használata az alkalmazás fejlesztése során, alkalmazott funkciók, tervezési elemek és egyéb megoldások.

### Mérföldkövek

* Az első sikeres adatkapcsolat (Backend(adatbázis)<->Android), új felhasználó regisztrációja
* Az első sikeres elveszett/talált állat bejelentése (A legördülő menükkel és kézi cím bevitellel)
* Sikeres képkészítés és konvertálása base64String-é és ezen adatok küldése az adatbázisba hiba nélkül
* Helymeghatározási, cím adatok létrehozása GPS-koordináták segítségével
* Jól müködő felhasználói autentikáció
* A végleges, új és a modern kornak megfelelő dinamikus dizájn elkészítése

### Fejlesztési lehetőségek
Véleményem szerint egy projekt fejlesztése során nincs olyan, hogy kész. 
Mindig lesznek fejlesztési ötletek, újítások, frissítések. 
Az A-Z menhely projektben is számtalan lehetőség van, melyekre az idő szűke miatt került sor.

* Elfelejtett jelszó - jelszó emlékeztető email funkció
* Maradjak bejelentkezve funkció
* Kétlépcsős hitelesítés

## Felhasználói kézikönyv

* [Felhasználói kézikönyv](https://github.com/HaRiZi2023/AZ_Menhely/blob/main/Android/users_manual_handbook.pdf)

## Teszt jegyzőkönyv

* [Tesztprotokoll](https://github.com/HaRiZi2023/AZ_Menhely/blob/main/Android/testprotocol.pdf)

## History 
Az Android applikáció fejlesztése során készült változások/változtatások nyomonkövetése.

-     Version | Name    | Date    |  Changes
1.     0.1| Cser    |2024-02-20| Initial Commit: Android Design, Activitys, Layouts, Resources
          | Cser    |2024-02-20| Első próba, valami már megvan.
          | Cser    |2024-02-20| Readme hozzáadása az Android mappához
          | Cser    |2024-02-20| A projektmappák elkészítése a bennük lévő readme fájlokkal egyetemben.
2.     0.2| Cser    |2024-03-16| Teszt és Backend kapcsolat
3.     0.3| Cser    |2024-03-17| Spinnerek/GPS koordináták cimmé/újabb adatbázis próba sikertelenül
          | Cser    |2024-03-17| Design Version 2.0
4.     0.4| Cser    |2024-03-18| Regisztráció és bejelentkezés működik/Állatfelvételnél az app elhasal/kidob - backend és android hiba is lehet
5.     0.5| Cser    |2024-03-19| Androidhoz szükséges módosítások. Felhasználói regisztráció/Bejelentkezés és az állatfelvétel backend
          | Cser    |2024-03-19| Startpage/ProgressBar ID's/
          | Cser    |2024-03-19| #2 - Startpage/ProgressBar ID's
6.     0.6| Cser    |2024-03-25| Talált keres oldal sikeres adatküldés
7.     0.7| Cser    |2024-03-25| Animal class tulajdonságainak átnevezése a backendnek megfelelően
8.     0.8| Cser    |2024-03-30| Design/Regisztrációnál email és jelszó feltételek/fénykép  
9.     0.9| Cser    |2024-03-31| GPS koordinálása sikeresen fut  
10.     0.10| Cser    |2024-04-02| Háttér módósítés és LostOrFindActivity vissza gomb
11.     1.0| Cser    |2024-04-07| TextInputEditText-ek és TextInputLayout-ok rendberakása. 
           | Cser    |2024-04-07| Jelszó validáció/ Mező kitöltöttség ellenőrzések/
           | Cser    |2024-04-07| Design csiszolása
12.     1.1| Cser    |2024-04-08| Classok refactorálása main oldal validálás, jelszó ellenőrzés?!
13.     1.2| Cser    |2024-04-10| Register újra jó POST ("http://10.0.2.2:8000/api/register")
14.     1.3| Cser    |2024-04-12| Login/Register/Animal store - dokumentálás elkezdése
           | Cser    |2024-04-12| MainActivity Toast javítása
15.     1.4| Cser    |2024-04-13| Application Icon
16.     1.5| Cser    |2024-04-21| Hiba üzenetek javítása (email cím, backend)
           | Cser    |2024-04-21| Üres string (NULL) küldése ha nem készül kép
17.     1.6| Cser    |2024-04-27| Role tulajdonság hozzáadása
           | Cser    |2024-04-27| Javadoc
           | Cser    |2024-04-27| Javadoc dependecy törlése mert errort okoz a build során



