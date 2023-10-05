namespace BattleShipLibrary.Models
{
    public class GameDataModelDb
    {
        public Guid Id { get; set; }
        public string Player1Board { get; set; }
        public string Player1HitBoard { get; set; }
        public string Player2Board { get; set; }
        public string Player2HitBoard { get; set; }
        public int Player1Points { get; set; }
        public int Player2Points { get; set; }
        public int GamePoints { get; set; }
    }
}
