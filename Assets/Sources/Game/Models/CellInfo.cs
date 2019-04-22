using System;
using UnityEngine;

namespace Game.Models
{
    public enum CellType
    {
        Empty,
        Filled
    }

    public class CellInfo
    {
        public int Row;
        public int Column;
        public CellType CellType;

        public CellInfo(int x, int y, CellType cellType = CellType.Empty)
        {
            Row = x;
            Column = y;
            CellType = cellType;
        }

        public Vector2 Position
        {
            get { return new Vector2(Row, Column); }
        }
        
        public override string ToString()
        {
            return String.Format("CellInfo :{0}x{1}", Row, Column);
        }
    }
}