Car Management Application
Aplicație web pentru gestionarea mașinilor, proprietarilor, service-urilor și asigurărilor, dezvoltată folosind ASP.NET Core.
Funcționalități
Gestionare Mașini

Adăugare și editare mașini
Asociere cu proprietari
Vizualizare istoric service și asigurări

Gestionare Proprietari

Înregistrare proprietari noi
Editare informații proprietari
Vizualizare flotă auto asociată

Service-uri

Programare service-uri
Înregistrare intervenții
Istoric complet al service-urilor pentru fiecare mașină

Asigurări

Gestionare polițe de asigurare
Urmărire date de expirare
Diferite tipuri de asigurări (RCA, CASCO, Carte Verde)

Tehnologii Utilizate

ASP.NET Core 8.0
Entity Framework Core
SQLite Database
Bootstrap 5
JavaScript/jQuery

Instalare

Clonează repository-ul:

bashCopygit clone https://github.com/yourusername/car-management.git

Navighează în directorul proiectului:

bashCopycd car-management

Restaurează pachetele NuGet:

bashCopydotnet restore

Aplică migrările pentru baza de date:

bashCopydotnet ef database update

Rulează aplicația:

bashCopydotnet run
Structura Bazei de Date
Aplicația folosește următoarele entități principale:

Cars (Mașini)
Owners (Proprietari)
Services (Service-uri)
Insurance (Asigurări)
