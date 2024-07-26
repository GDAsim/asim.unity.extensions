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

        //====================================================================================================
        //====================================================================================================

        /// <summary>
        /// http://answers.unity3d.com/questions/131624/vector3-comparison.html#answer-131672
        /// Returns true if vector are equal with a angle error margin
        /// </summary>
        public static bool ApproxEqual(this Vector3 v1, Vector3 v2, float angleError = 0.001f)
        {
            //if they aren't the same length, don't bother checking the rest.
            if (!Mathf.Approximately(v1.magnitude, v2.magnitude))
                return false;

            var cosAngleError = Mathf.Cos(angleError * Mathf.Deg2Rad);

            //A value between -1 and 1 corresponding to the angle.
            //The dot product of normalized Vectors is equal to the cosine of the angle between them.
            //So the closer they are, the closer the value will be to 1. Opposite Vectors will be -1
            //and orthogonal Vectors will be 0.
            var cosAngle = Vector3.Dot(v1.normalized, v2.normalized);

            //If angle is greater, that means that the angle between the two vectors is less than the error allowed.
            return cosAngle >= cosAngleError;
        }

        //====================================================================================================
        //====================================================================================================
    }
}
