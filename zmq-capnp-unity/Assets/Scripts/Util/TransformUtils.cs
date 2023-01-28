using UnityEngine;

namespace Util
{
    public static class TransformUtils
    {
        public static Matrix4x4 GetMatrix(this Transform transform, Space space = Space.World, bool includeScale = false)
        {
            if (space == Space.World)
            {
                // Warning! LossyScale is not accurate if scale is non-uniform.
                return Matrix4x4.TRS(transform.position, transform.rotation, includeScale ? transform.lossyScale : Vector3.one);
            }
            else
            {
                return Matrix4x4.TRS(transform.localPosition, transform.localRotation, includeScale ? transform.localScale : Vector3.one);
            }
        }
        
        public static Quaternion GetRotation(this Matrix4x4 transform)
        {
            return transform.rotation;
        }
    
        
        public static void SetMatrix(this Transform transform, Matrix4x4 matrix, Space space = Space.World)
        {
            if (space == Space.World)
            {
                transform.position = matrix.GetPosition();
                transform.rotation = matrix.rotation;
            }
            else
            {
                transform.localPosition = matrix.GetPosition();
                transform.localRotation = matrix.rotation;
            }
        }
    }
}