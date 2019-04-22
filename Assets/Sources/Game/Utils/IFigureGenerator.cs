using System.Collections.Generic;
using Game.Models;

namespace Game.Utils
{
    public interface IFigureGenerator
    {
        List<CellInfo> GetRandomFigure();
    }
}