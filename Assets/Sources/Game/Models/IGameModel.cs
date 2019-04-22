using System.Collections.Generic;

namespace Game.Models
{
    public interface IGameModel
    {
        int Score { get; set; }
        bool IsFirstLaunch { get; set; }
        
        List<List<CellInfo>> Cells { get; set; }
    }
}