namespace BattleShipLibrary.Models
{
    public class GameDataModelApi
    {
        public Guid Id { get; set; }
        public int[][] PlayerBoard { get; set; }
        public int[][] PlayerHitBoard { get; set; }
        public int Player1Points { get; set; }
        public int Player2Points { get; set; }
        public int GamePoints { get; set; }
    }
}
