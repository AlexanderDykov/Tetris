using UnityEngine;

namespace Game.Utils
{
    public class MatrixHelper : IMatrixHelper
    {
        private const float CellSize = 65f;
        private const float Padding = 1.2f;
        
        public Vector3 GetPosition(Vector2 startCoord, float x, float y)
        {
            return new Vector3(startCoord.x + x * CellSize + CellSize / 2 + Padding,
                startCoord.y - y * CellSize - CellSize / 2 + Padding);
        }

        public Vector2 GetSizeDelta()
        {
            return new Vector2(CellSize - Padding, CellSize - Padding);
        }

        public Vector2 GetStart(int width, int height)
        {
            return new Vector2(-(CellSize+Padding)*width/2,(CellSize+Padding)*height/2);
        }
    }
}