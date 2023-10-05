using BattleShipLibrary.Models;
using Newtonsoft.Json;

namespace BattleShipLibrary.Implementation
{
    public static class ConversionHelper
    {
        public static GameDataModelApi ConvertDtoToApi(GameDataModelDto gameDataDto)
        {
            if (gameDataDto == null)
            {
                return null;
            }

            GameDataModelApi gameDataApi = new GameDataModelApi
            {
                Id = gameDataDto.Id,
                PlayerBoard = gameDataDto.Player1Board,
                PlayerHitBoard = gameDataDto.Player1HitBoard,
                Player1Points = gameDataDto.Player1Points,
                Player2Points = gameDataDto.Player2Points,
                GamePoints = gameDataDto.GamePoints
            };

            return gameDataApi;
        }

        public static GameDataModelDb ConvertToDb(GameDataModelDto gameDataModelDto)
        {
            if (gameDataModelDto == null)
            {
                return null;
            }

            GameDataModelDb gameModelDb = new GameDataModelDb();
            gameModelDb.Id = gameDataModelDto.Id;
            gameModelDb.Player1Points = gameDataModelDto.Player1Points;
            gameModelDb.Player2Points = gameDataModelDto.Player2Points;
            gameModelDb.GamePoints = gameDataModelDto.GamePoints;
            gameModelDb.Player1Board = Serialize(gameDataModelDto.Player1Board);
            gameModelDb.Player2Board = Serialize(gameDataModelDto.Player2Board);
            gameModelDb.Player1HitBoard = Serialize(gameDataModelDto.Player1HitBoard);
            gameModelDb.Player2HitBoard = Serialize(gameDataModelDto.Player2HitBoard);

            return gameModelDb;
        }

        public static GameDataModelDto ConvertToDto(GameDataModelDb gameDataModelDb)
        {
            if (gameDataModelDb == null)
            {
                return null;
            }

            GameDataModelDto gameDataModelDto = new GameDataModelDto();
            gameDataModelDto.Id = gameDataModelDb.Id;
            gameDataModelDto.Player1Points = gameDataModelDb.Player1Points;
            gameDataModelDto.Player2Points = gameDataModelDb.Player2Points;
            gameDataModelDto.GamePoints = gameDataModelDb.GamePoints;
            gameDataModelDto.Player1Board = Deserialize<int[][]>(gameDataModelDb.Player1Board);
            gameDataModelDto.Player2Board = Deserialize<int[][]>(gameDataModelDb.Player2Board);
            gameDataModelDto.Player1HitBoard = Deserialize<int[][]>(gameDataModelDb.Player1HitBoard);
            gameDataModelDto.Player2HitBoard = Deserialize<List<(int, int)>>(gameDataModelDb.Player2HitBoard);

            return gameDataModelDto;
        }

        private static string Serialize<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        private static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
