using BattleShipLibrary.Data;
using BattleShipLibrary.Interface;
using BattleShipLibrary.Models;

namespace BattleShipLibrary.Implementation
{
    public class BattleShipProvider : IBattleShipProvider
    {
        Random _random;
        IDataAccess _dataAccess;

        public BattleShipProvider(IDataAccess dataAccess)
        {
            _random = new Random();
            _dataAccess = dataAccess;
        }


        public GameDataModelApi GetData(Guid id)
        {
            GameDataModelDto gameDataDto = _dataAccess.Get(id);

            GameDataModelApi gameDataApi = ConversionHelper.ConvertDtoToApi(gameDataDto);

            return gameDataApi;
        }

        public void MakeATurn(Guid id, int x, int y)
        {
            GameDataModelDto gameDataDto = _dataAccess.Get(id);

            if(gameDataDto==null)
            {
                return;
            }

            if (Shot(gameDataDto.Player2Board, x, y))
            {
                gameDataDto.Player1Points++;

                gameDataDto.Player1HitBoard[x][y] = -1;

                if (gameDataDto.Player1Points == gameDataDto.GamePoints)
                {
                    _dataAccess.Update(gameDataDto);
                    return;
                }
            }
            else
            {
                gameDataDto.Player1HitBoard[x][y] = 5;
            }

            //Computer turn
            int fieldId = _random.Next(gameDataDto.Player2HitBoard.Count());
            (int, int) field = gameDataDto.Player2HitBoard[fieldId];

            if (Shot(gameDataDto.Player1Board, field.Item1, field.Item2))
            {
                gameDataDto.Player2Points++;
            }
            else
            {
                gameDataDto.Player1Board[field.Item1][field.Item2] = 5;
            }

            gameDataDto.Player2HitBoard.RemoveAt(fieldId);

            _dataAccess.Update(gameDataDto);
        }

        private bool Shot(int[][] board, int x, int y)
        {
            if (board[x][y] == 1)
            {
                board[x][y] = -1;

                return true;
            }

            return false;
        }

        #region BoardGeneration

        /// <summary>
        /// Creates new game model with gameDataDto
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="gamePoints"></param>
        public GameDataModelApi Create(int boardSize, int gamePoints)
        {
            GameDataModelDto gameModelDto = new GameDataModelDto();
            Guid guid = Guid.NewGuid();

            gameModelDto.Id = guid;

            gameModelDto.Player1Board = CreatePlayerBoard(boardSize);
            gameModelDto.Player1HitBoard = GenerateClearBoard(boardSize);

            gameModelDto.Player2Board = CreatePlayerBoard(boardSize);
            gameModelDto.Player2HitBoard = GetComputerHitBoard(boardSize);

            gameModelDto.Player2Points = 0;
            gameModelDto.Player1Points = 0;
            gameModelDto.GamePoints = gamePoints;

            _dataAccess.Create(gameModelDto);

            return ConversionHelper.ConvertDtoToApi(gameModelDto);
        }

        private int[][] GenerateClearBoard(int boardSize)
        {
            int[][] board = new int[boardSize][];

            for (int i = 0; i < boardSize; i++)
            {
                board[i] = new int[boardSize];

                for (int j = 0; j < boardSize; j++)
                {
                    board[i][j] = 0;
                }
            }

            return board;
        }

        private List<(int, int)> GetComputerHitBoard(int boardSize)
        {
            List<(int, int)> computerPointsToHit = new List<(int, int)>();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    computerPointsToHit.Add(new(i, j));
                }
            }

            return computerPointsToHit;
        }

        private bool CanShipBePlaced(int[][] board, int startRow, int startCol, int shipSize, bool isShipVertical)
        {
            int x1, x2, y1, y2;

            x1 = startRow > 0 ? startRow - 1 : startRow;
            y1 = startCol > 0 ? startCol - 1 : startCol;

            if (isShipVertical)
            {
                x2 = startRow + shipSize < board.Length - 1 ? startRow + shipSize + 1 : startRow + shipSize;
                y2 = startCol < board.Length - 1 ? startCol + 1 : startCol;
            }
            else
            {
                x2 = startRow < board.Length - 1 ? startRow + 1 : startRow;
                y2 = startCol + shipSize < board.Length - 1 ? startCol + shipSize + 1 : startCol + shipSize;
            }

            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    if (board[x][y] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void PlaceShip(int[][] board, int shipSize)
        {
            bool isPlaced = false;

            while (!isPlaced)
            {
                bool isShipVertical = _random.Next(2) == 0 ? false : true;

                int row = 0;
                int col = 0;

                if (isShipVertical)
                {
                    row = _random.Next(board.Length - 1 - shipSize);
                    col = _random.Next(board.Length);

                    if (CanShipBePlaced(board, row, col, shipSize, isShipVertical))
                    {
                        for (int i = row; i < row + shipSize; i++)
                        {
                            board[i][col] = 1;
                        }

                        isPlaced = true;
                    }
                }
                else
                {
                    row = _random.Next(board.Length);
                    col = _random.Next(board.Length - 1 - shipSize);

                    if (CanShipBePlaced(board, row, col, shipSize, isShipVertical))
                    {
                        for (int i = col; i < col + shipSize; i++)
                        {
                            board[row][i] = 1;
                        }

                        isPlaced = true;
                    }
                }
            }
        }

        private int[][] CreatePlayerBoard(int boardSize)
        {
            int[][] board = GenerateClearBoard(boardSize);

            PlaceShip(board, 5);
            PlaceShip(board, 4);
            PlaceShip(board, 3);
            PlaceShip(board, 3);
            PlaceShip(board, 2);

            return board;
        }

        #endregion
    }
}
