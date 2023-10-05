namespace BattleShipLibrary.Models
{
    public class GameDataModelDto
    {
        public Guid Id { get; set; }
        public int[][] Player1Board { get; set; }
        public int[][] Player1HitBoard { get; set; }
        public int[][] Player2Board { get; set; }
        public List<(int, int)> Player2HitBoard { get; set; }
        public int Player1Points { get; set; }
        public int Player2Points { get; set; }
        public int GamePoints { get; set; }
    }
}
