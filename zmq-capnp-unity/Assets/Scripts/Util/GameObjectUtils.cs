using UnityEngine;

namespace Util
{
    static internal class GameObjectUtils
    {
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            T comp = go.GetComponent<T>();
            if (!comp)
                comp = go.AddComponent<T>();
            return comp;
        }
    }
}