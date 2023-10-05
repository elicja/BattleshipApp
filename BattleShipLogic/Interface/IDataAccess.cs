using BattleShipLibrary.Models;

namespace BattleShipLibrary.Interface
{
    public interface IDataAccess
    {
        void Create(GameDataModelDto gameDataModelDto);
        GameDataModelDto Get(Guid id);
        void Update(GameDataModelDto gameDataModelDto);
    }
}
