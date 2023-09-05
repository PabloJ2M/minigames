using Unity.Mathematics;

namespace UnityEngine
{
    public static class mathf
    {
        //x axis
        public static readonly float3 right = new(1, 0, 0);
        public static readonly float3 left = new(-1, 0, 0);

        //y axis
        public static readonly float3 up = new(0, 1, 0);
        public static readonly float3 down = new(0, -1, 0);

        //z axis
        public static readonly float3 forward = new(0, 0, 1);
        public static readonly float3 back = new(0, 0, -1);

        public static readonly float3 none = new(float.MaxValue, float.MaxValue, float.MaxValue);
        public static bool Compare(float3 a, float3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
    }
    public static class MathExtension
    {
        public static bool Compare(this float3 direction, float3 other)
        {
            direction = math.round(direction);
            float3 absolute = math.abs(direction);

            bool uniqueDir = other.Equals(absolute);
            return uniqueDir || absolute.x == other.x || absolute.z == other.z;
        }

        public static Color SetColorValue(Color target, float alpha)
        {
            float3 colors;
            Color.RGBToHSV(target, out colors.x, out colors.y, out colors.z); colors.z = alpha;
            return Color.HSVToRGB(colors.x, colors.y, colors.z);
        }
        public static float GetColorValue(Color current)
        {
            float3 colors;
            Color.RGBToHSV(current, out colors.x, out colors.y, out colors.z);
            return colors.z;
        }
    }
}