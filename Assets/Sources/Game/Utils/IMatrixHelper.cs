using UnityEngine;

namespace Game.Utils
{
    public interface IMatrixHelper
    {
        Vector3 GetPosition(Vector2 startCoord, float x, float y);
        Vector2 GetSizeDelta();
        Vector2 GetStart(int width, int height);
    }
}