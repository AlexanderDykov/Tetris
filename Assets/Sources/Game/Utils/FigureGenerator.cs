using System.Collections.Generic;
using Game.Models;
using UnityEngine;

namespace Game.Utils
{
    public class FigureGenerator : IFigureGenerator
    {
        public List<List<CellInfo>> _figures = new List<List<CellInfo>>();

        public FigureGenerator()
        {
            var L = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(0, 1, CellType.Filled),
                new CellInfo(0, 2, CellType.Filled),
                new CellInfo(1, 2, CellType.Filled),
            };
            
            var J = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(0, 1, CellType.Filled),
                new CellInfo(0, 2, CellType.Filled),
                new CellInfo(-1, 2, CellType.Filled),
            };
            
            var I = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(0, 1, CellType.Filled),
                new CellInfo(0, 2, CellType.Filled),
                new CellInfo(0, 3, CellType.Filled),
            };
            
            var O = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(0, 1, CellType.Filled),
                new CellInfo(1, 0, CellType.Filled),
                new CellInfo(1, 1, CellType.Filled),
            };
            
            var S = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(1, 0, CellType.Filled),
                new CellInfo(0, 1, CellType.Filled),
                new CellInfo(-1, 1, CellType.Filled),
            };
            
            var T = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(1,0, CellType.Filled),
                new CellInfo(2, 0, CellType.Filled),
                new CellInfo(1,1, CellType.Filled),
                new CellInfo(1,2, CellType.Filled),
            };
            
            var Z = new List<CellInfo>()
            {
                new CellInfo(0, 0, CellType.Filled),
                new CellInfo(1, 0, CellType.Filled),
                new CellInfo(1, 1, CellType.Filled),
                new CellInfo(2, 1, CellType.Filled),
            };
            
            _figures.Add(L);
            _figures.Add(J);
            _figures.Add(I);
            _figures.Add(O);
            _figures.Add(S);
            _figures.Add(T);
            _figures.Add(Z);
        }

        public List<CellInfo> GetRandomFigure()
        {
            return _figures[Random.Range(0, _figures.Count)];
        }
    }
}