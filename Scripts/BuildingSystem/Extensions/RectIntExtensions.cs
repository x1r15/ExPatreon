using UnityEngine;

namespace Extensions
{
    public static class RectIntExtensions
    {
        public delegate void RectAction(Vector3Int coords);

        public delegate bool RectActionBool(Vector3Int coords);
        
        public static void Iterate(this RectInt rect, Vector3Int coords, RectAction action)
        {
            for (var x = rect.x; x < rect.xMax; x++)
            {
                for (var y = rect.y; y < rect.yMax; y++)
                {
                    action(coords + new Vector3Int(x, y, 0));
                }
            }
        }
        
        public static bool Iterate(this RectInt rect, Vector3Int coords, RectActionBool action)
        {
            for (var x = rect.x; x < rect.xMax; x++)
            {
                for (var y = rect.y; y < rect.yMax; y++)
                {
                    if (action(coords + new Vector3Int(x, y, 0)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}