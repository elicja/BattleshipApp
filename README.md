--------------------------------------------------
Assumptions of the game
--------------------------------------------------

1. Everyone has five ships, the dimensions of which occupy a given number of fields (2, 3, 3, 4, 5).
2. The opponent is a computer.
4. The computer moves randomly.
5. The game ends when one of the players captures all ships (i.e. total number of points = 17).


--------------------------------------------------
Project - general assumptions
--------------------------------------------------

The project consists of two applications - a server application and a client application.

The user can create a new game and load an existing one if he knows its id.
The user can start a new game without any problems.

The course of the game is continuously saved in the database.

--------------------------------------------------
C# application - the most important information
--------------------------------------------------

The application consists of two projects.
BattleShipLibrary is responsible for models, database access and gameplay logic and
BattleshipHappyTeamApi, an API project that supports three queries:

1. GET api/Battleship/game/{id} query, which returns a GameDataModelApi object with game data based on the received id.   
2. POST api/Battleship/game/ query, which creates a new game object, adds it to the database and then returns the game data as a GameDataModelApi object.
3. POST api/Battleship/game/{id} query, which is used for the player to take a shot.

Three models were created in BattleShipLibrary/Models:
1. GameDataModelDto - model used in the provider.
2. GameDataModelDb - database model.
3. GameDataModelApi - model returned by Api.

Data is accessed by using Entity Framework Core.
Complex data (e.g. collections) of dto/db objects are serialized/deserialized while working with the database.

---------------------------------------------------------
Angular application - the most important information
---------------------------------------------------------

The application consists of the api.service website, which is responsible for sending HTTP requests.
  *In app/services/api.service.ts you must provide a link to the API for the 'private baseUrl' value.

The Render-board component, responsible for showing the game board.

The main component app.component, responsible for the rest of the application logic.

---------------------------------------------------------
Additional information
---------------------------------------------------------

The angular application files are located in the BattleshipHappyTeam/AngularClientApp/HappyTeamBattleShipApp folder.

The main project of the server application is the BattleshipHappyTeamApi project.
