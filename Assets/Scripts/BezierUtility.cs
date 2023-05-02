using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public static class BezierUtility
    {

        public static float FindPathLength(Vector3[] points)
        {
            var curveLength = 0f;
            for (var i = 0; i < points.Length - 1; i++)
            {
                curveLength += Vector3.Distance(points[i], points[i + 1]);
            }
            
            return curveLength;
        }

        public static Vector3[] GetBeizerPointList(int segmentNum,List<Vector3> p)
        {
            Vector3[] path = new Vector3[segmentNum];
            for (int i = 1; i <= segmentNum; i++)
            {
                float t = i / (float)segmentNum;
                Vector3 pixel = BezierPoint(t, p);
                path[i - 1] = pixel;
            }
            return path;
        }

        public static Vector3 BezierPoint(float t, List<Vector3> p)
        {
            if (p.Count < 2)
                return p[0];
            List<Vector3> newP = new List<Vector3>();
            for (int i = 0; i < p.Count - 1; i++)
            {
                Vector3 p0p1 = (1 - t) * p[i] + t * p[i + 1];
                newP.Add(p0p1);
            }
            return BezierPoint(t, newP);
        }
    }
}