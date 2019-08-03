using System;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime {
  static public class VectorUtils {
    static public Vector3 Scale(this Vector3 thisVector3, Single x, Single y, Single z) =>
      new Vector3(thisVector3.x * x, thisVector3.y * y, thisVector3.z * z);
  }
}