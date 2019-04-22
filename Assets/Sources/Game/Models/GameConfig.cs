namespace Game.Models
{
    public class GameConfig : IGameConfig
    {
        private float _cellSize = 1;
        
        public int FieldWidth {
            get
            {
                return 10;
            }
        }
        public int FieldHeight {
            get
            {
                return 10;
            }
        }
        
        public float CellSize {
            get { return _cellSize; }
            set { _cellSize = value; }
        }
    }
}