using System.Collections.Generic;

namespace Game.Models
{
    public sealed class GameModel : IGameModel
    {
        private bool _isFirstLaunch = true;
        public int Score { get; set; }
        
        public bool IsFirstLaunch {
            get { return _isFirstLaunch; }
            set { _isFirstLaunch = value; }
        }

        public List<List<CellInfo>> Cells { get; set; }
    }
}