using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Out:
  /// - modifies <see cref="Component_Skybox_Properties"/> using <see cref="Component_Skybox_LocalRotation_Delta"/>.
  /// </summary>
  public class System_Skybox_LocalRotation_Delta : PsuedoSystem {
    // ~ 
    // "scaled rotation" is unreliable
    // quaternions cannot reprsent value ranges beyond a "full" rotation

    // consider a rotation scale of 0.1
    // when a 360 -> 0 turnover happens, information is lost
    // eg, 360 * 0.1 :: 36. 1 == .36. This is a massive jump
    // in order to counteract this loss of data, angles must be driven by the *difference* in rotation of the tracked entity every update

#region Messages

    protected void LateUpdate() {
      Components.ForEach<Component_Skybox_Entities, Component_Skybox_Properties, Component_Skybox_LocalRotation_Delta>(
        (i_cEntities, i_cProperties, i_cRotation) => {

          // get current rotation
          Quaternion i_rotationTrackedCurrent;
          if (i_cEntities.EntityOrigin == null) {
            // global rotation
            i_rotationTrackedCurrent = i_cEntities.EntityTarget.transform.rotation;
          } else {
            // relative rotation of current to track
            i_rotationTrackedCurrent = Quaternion.Inverse(i_cEntities.EntityOrigin.transform.rotation) * i_cEntities.EntityTarget.transform.rotation;
          }

          // get rotation delta. using eulers, as Quaternions cannot properly interpolate at edges
          Vector3 i_rotationTrackedCurrentEulers = i_rotationTrackedCurrent.eulerAngles;
          Vector3 i_rotationTrackedLastEulers = i_cRotation.RotationTrackedLast.eulerAngles;
          Vector3 i_rotationDeltaIncrement = new Vector3(
            Mathf.DeltaAngle(i_rotationTrackedLastEulers.x, i_rotationTrackedCurrentEulers.x),
            Mathf.DeltaAngle(i_rotationTrackedLastEulers.y, i_rotationTrackedCurrentEulers.y),
            Mathf.DeltaAngle(i_rotationTrackedLastEulers.z, i_rotationTrackedCurrentEulers.z)
          );
          i_rotationDeltaIncrement.Scale(-i_cRotation.Factor); // scale the delta

          // apply
          i_cRotation.LocalRotationDelta *= Quaternion.Euler(i_rotationDeltaIncrement); // add to the total delta, using the current delta
          i_cProperties.LocalRotation *= i_cRotation.LocalRotationDelta; // add the total delta

          // cache
          i_cRotation.RotationTrackedLast = i_rotationTrackedCurrent; // cache last
        }
      );
    }

#endregion
  }
}