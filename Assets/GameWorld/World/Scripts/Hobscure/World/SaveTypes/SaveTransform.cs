using UnityEngine;
using System;

namespace Hobscure.World { 
    [Serializable]
    public class SaveTransform {
        public float x;
        public float y;
        public float z;

        public float rX;
        public float rY;
        public float rZ;

        public SaveVector3 position { get { return new SaveVector3(new Vector3(x, y, z)); } }
        public SaveVector3 rotation { get { return new SaveVector3(new Vector3(rX, rY, rZ)); } }

        public SaveTransform(Transform pos)
        {
            this.x = pos.position.x;
            this.y = pos.position.y;
            this.z = pos.position.z;

            this.rX = pos.eulerAngles.x;
            this.rY = pos.eulerAngles.y;
            this.rZ = pos.eulerAngles.z;
        }

    }
}