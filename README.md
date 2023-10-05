--------------------------------------------------
Założenia gry
--------------------------------------------------

1. Każdy posiada pięć statków, których wymiary zajmują daną ilość pól (2, 3, 3, 4, 5).
2. Przeciwnikiem jest komputer.
4. Komputer wykonuje ruchy w sposób losowy.
5. Gra kończy się gdy jeden z graczy zbije wszystkie statki (czyli łączna liczba punktów = 17).


--------------------------------------------------
Projekt - ogólne założenia
--------------------------------------------------

Projekt składa się z dwóch aplikacji - aplikacji serwerowej oraz klienckiej

Użytkownik może stworzyć nową grę oraz wczytać już istniejącą, jeśli zna jej id.
Użytkownik może bez problemu zacząć nową grę.

Przebieg gry jest na bieżąco zapisywany w bazie danych.

--------------------------------------------------
Aplikacja po stronie C# - najważniejsze informacje
--------------------------------------------------

Aplikacja składa się z dwóch projektów. 
BattleShipLibrary odpowiada za modele, dostęp do bazy danych i logikę rozgrywki oraz 
BattleshipHappyTeamApi, czyli projekt API, który obsługuje trzy zapytania:

1. Zapytanie GET api/Battleship/game/{id}, które zwraca obiekt GameDataModelApi z danymi gry na podstawie otrzymanego id.   
2. Zapytanie POST api/Battleship/game/, które tworzy nowy obiekt gry, dodaje go do bazy danych, a następnie zwraca dane gry jako obiekt GameDataModelApi.
3. Zapytanie POST api/Battleship/game/{id}, które służy do oddawania strzału przez gracza.

W BattleShipLibrary/Models powstały trzy modele:
1. GameDataModelDto - model używany w providerze.
2. GameDataModelDb - model bazodanowy.
3. GameDataModelApi - model zwracany przez Api.

Dostęp do danych odbywa się przy wykorzystaniu Entity Framework Core.
Złożone dane (np. kolekcje) obiektów dto/db są Serializowane/Deserializowane podczas pracy z bazą danych.


---------------------------------------------------------
Aplikacja po stronie Angular'a - najważniejsze informacje
---------------------------------------------------------

Aplikacja składa się z serwisu api.service, który odpowiada za wysyłanie zapytań HTTP.
  *W app/services/api.service.ts należy podać dla wartości 'private baseUrl' link do API.

Komponentu Render-board, odpowiadającego za pokazywanie planszy gry.

Komponentu głównego app.component, odpowiadającego za pozostałą część logiki aplikacji.

---------------------------------------------------------
Dodatkowe informacje
---------------------------------------------------------

Pliki aplikacji angular znajdują się w folderze BattleshipHappyTeam/AngularClientApp/HappyTeamBattleShipApp.

Głównym projektem aplikacji serwerowej jest projekt BattleshipHappyTeamApi.
