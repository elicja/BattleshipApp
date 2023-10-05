using BattleShipLibrary.Implementation;
using BattleShipLibrary.Interface;
using BattleShipLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipLibrary.Data
{
    public class DataAccess : IDataAccess
    {
        private DataContext _db;

        public DataAccess(DataContext db)
        {
            _db = db;
        }

        public GameDataModelDto Get(Guid id)
        {
            GameDataModelDb gameDataModelDb = _db.GameDataModelsDb.FirstOrDefault(x => x.Id == id);
            _db.Entry(gameDataModelDb).State = EntityState.Detached;

            GameDataModelDto gameDataModelDto = ConversionHelper.ConvertToDto(gameDataModelDb);

            return gameDataModelDto;
        }

        public void Create(GameDataModelDto gameDataModelDto)
        {
            GameDataModelDb gameDataModelDb = ConversionHelper.ConvertToDb(gameDataModelDto);

            _db.GameDataModelsDb.Add(gameDataModelDb);
            _db.SaveChanges();
        }

        public void Update(GameDataModelDto gameDataModelDto)
        {
            GameDataModelDb gameDataModelDb = ConversionHelper.ConvertToDb(gameDataModelDto);

            _db.GameDataModelsDb.Update(gameDataModelDb);
            _db.SaveChanges();
        }
    }
}
