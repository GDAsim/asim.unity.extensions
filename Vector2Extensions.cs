using UnityEngine;

namespace asim.unity.extensions
{ 
    public static class Vector2Extensions
    {
        public static Vector2 Normalize(Vector2 v)
        {
            double dlength = System.Math.Sqrt(v.x * v.x + v.y * v.y);
            if (dlength > double.Epsilon)
            {
                float flength = (float)dlength;
                v.x /= flength;
                v.y /= flength;
                return v;
            }
            else return Vector2.zero;
        }

        /// <summary>
        /// Set the Length(Magnitude) of the Vector
        /// </summary>
        public static Vector2 SetMagnitude(this Vector2 v, float value)
        {
            return Normalize(v) * value;
        }

        /// <summary>
        /// Restrict the length(magitude) of a vector
        /// </summary>
        public static Vector2 ClampMagitude(this Vector2 v,float min,float max)
        {
            float length = v.magnitude;
            if(length < min)
            {
                return Normalize(v) * min;
            }
            else if (v.magnitude > max)
            {
                return Normalize(v) * max;
            }
            return v;
        }

        /// <summary>
        /// Create Directional Vector From Angle couter-clockwise starting using Vector2(1,0)
        /// </summary>
        public static Vector2 fromAngle(float angleRad)
        {
            return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        /// <summary>
        /// Returns a vector rotated in radians couter-clockwise
        /// </summary>
        public static Vector2 Rotate(this Vector2 v, float radians)
        {
            return new Vector2(Mathf.Cos(radians) * v.x - Mathf.Sin(radians) * v.y, Mathf.Sin(radians) * v.x + Mathf.Cos(radians) * v.y);
        }
    }
}
