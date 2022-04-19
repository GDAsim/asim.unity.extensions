using UnityEngine;

namespace asim.unity.extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 Normalize(Vector3 v)
        {
            double dlength = System.Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            if (dlength > double.Epsilon)
            {
                float flength = (float)dlength;
                v.x /= flength;
                v.y /= flength;
                v.z /= flength;
                return v;
            }
            else return Vector3.zero;
        }

        /// <summary>
        /// Set the Length(Magnitude) of the Vector
        /// </summary>
        public static Vector3 SetMagnitude(this Vector3 v, float value)
        {
            return Normalize(v) * value;
        }

        /// <summary>
        /// Restrict the length(magitude) of a vector
        /// </summary>
        public static Vector3 ClampMagitude(this Vector3 v, float min, float max)
        {
            float length = v.magnitude;
            if (length < min)
            {
                return Normalize(v) * min;
            }
            else if (v.magnitude > max)
            {
                return Normalize(v) * max;
            }
            return v;
        }
    }
}
