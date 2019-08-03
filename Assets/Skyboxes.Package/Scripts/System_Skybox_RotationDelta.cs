using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Modifies Rotation of Skybox renders.
  /// </summary>
  public class System_Skybox_RotationDelta : PsuedoSystem {
    // ~ 
    // "scaled rotation" is unreliable
    // quaternions cannot reprsent value ranges beyond a "full" rotation

    // consider a rotation scale of 0.1
    // when a 360 -> 0 turnover happens, information is lost
    // eg, 360 * 0.1 :: 36. 1 == .36. This is a massive jump
    // in order to counteract this loss of data, angles must be driven by the *difference* in rotation of the tracked entity every update

#region Messages

    protected void Start() {
      // Components.ForEach<Component_Skybox_RenderRotation>(
      //   (i_RenderRotation) => {
      //     i_RenderRotation.RotationRenderScaled = Quaternion.Euler(i_RenderRotation.GetComponentInChildren<Renderer>().material.GetVector("_Rotation"));
      //   }
      // );
    }

    protected void LateUpdate() {
      Components.ForEach<Component_Skybox_Entities, Component_Skybox_RotationDelta>(
        (i_cEntities, i_cRotation) => {

          // get the rotation which, when applied to the rotation of the render, will be the identity
          Quaternion i_rotationCurrent;
          if (i_cEntities.EntityOrigin == null) {
            // global rotation
            i_rotationCurrent = i_cEntities.EntityTarget.transform.rotation;
          } else {
            // relative rotation of current to track
            i_rotationCurrent = Quaternion.Inverse(i_cEntities.EntityOrigin.transform.rotation) * i_cEntities.EntityTarget.transform.rotation;
          }
          i_rotationCurrent = Quaternion.Inverse(i_rotationCurrent);

          // get rotation delta. using eulers, as Quaternions cannot properly interpolate at edges
          Vector3 i_rotationCurrentEulers = i_rotationCurrent.eulerAngles;
          Vector3 i_rotationLastEulers = i_cRotation.RotationLast.eulerAngles;
          Vector3 i_rotationDeltaIncrement = new Vector3(
            Mathf.DeltaAngle(i_rotationLastEulers.x, i_rotationCurrentEulers.x),
            Mathf.DeltaAngle(i_rotationLastEulers.y, i_rotationCurrentEulers.y),
            Mathf.DeltaAngle(i_rotationLastEulers.z, i_rotationCurrentEulers.z)
          );
          i_rotationDeltaIncrement.Scale(i_cRotation.Factor); // scale the delta

          Debug.Log($"Delta {i_rotationDeltaIncrement}");

          // apply
          i_cRotation.RotationDeltaTotal *= Quaternion.Euler(i_rotationDeltaIncrement); // add to the total delta, using the current delta
          i_cRotation.RotationLast = i_rotationCurrent;

          i_cEntities
            .EntityRender
            .GetComponentInChildren<Renderer>()
            .material
            .SetVector(
              "_LocalRotation",
              (i_rotationCurrent * i_cRotation.RotationDeltaTotal).eulerAngles
            );
        }
      );
    }

#endregion
  }
}