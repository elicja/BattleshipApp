using BattleShipLibrary.Models;

namespace BattleShipLibrary.Interface
{
    public interface IBattleShipProvider
    {
        GameDataModelApi Create(int boardSize, int gamePoints);
        GameDataModelApi GetData(Guid id);
        void MakeATurn(Guid id, int x, int y);
    }
}
