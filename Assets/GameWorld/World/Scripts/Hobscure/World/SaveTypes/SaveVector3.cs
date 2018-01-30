using UnityEngine;
using System;


namespace Hobscure.World
{
    [Serializable]
    public class SaveVector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3 vector3 { get { return new Vector3(x, y, z); } }

        public SaveVector3(Vector3 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }
    }
}