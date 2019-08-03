using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime {
  static public class QuaternionUtils {
    static public Vector4 ToVector4(this Quaternion thisQuaternion) => new Vector4(thisQuaternion.x, thisQuaternion.y, thisQuaternion.z, thisQuaternion.w);
  }
}