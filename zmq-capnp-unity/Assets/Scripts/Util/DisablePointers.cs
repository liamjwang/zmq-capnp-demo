using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

namespace DefaultNamespace
{
    public class DisablePointers : MonoBehaviour
    {
        private void Start()
        {
            PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff, Handedness.Left);
            PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff, Handedness.Right);
        }
    }
}