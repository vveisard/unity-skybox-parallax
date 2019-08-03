using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Modifies Rotation of Skybox renders.
  /// </summary>
  public class System_Skybox_Rotation : PsuedoSystem {
#region Messages

    protected void LateUpdate() {
      Components.ForEach<Component_Skybox_Entities>(
        (i_cEntities) => {
          if (i_cEntities.EntityRender.gameObject.TryGetComponent(out Component_Skybox_RenderRotation i_cRotation)) {
            // ~ 
            // "scaled rotation" implies a loss of data
            // consider a rotation scale of 0.1
            // when a 360 -> 0 turnover happens, information is lost
            // eg, 360 * 0.1 :: 36. 1 == .36. This is a massive jump
            // in order to counteract this loss of data, angles must be driven by the *difference* in rotation of the tracked entity

            // get unscaled
            Quaternion rotationLast = i_cRotation.RotationTrackedUnscaled;
            Quaternion rotationCurrent = i_cEntities.EntityTrack.transform.rotation;
            Vector3 rotationLast_Eulers = rotationLast.eulerAngles;
            Vector3 rotationCurrent_Eulers = i_cEntities.EntityTrack.transform.eulerAngles;
            // TODO: use relative rotation

            // get difference
            Vector3 eulerAnglesDelta = new Vector3(
              Mathf.DeltaAngle(rotationLast_Eulers.x, rotationCurrent_Eulers.x),
              Mathf.DeltaAngle(rotationLast_Eulers.y, rotationCurrent_Eulers.y),
              Mathf.DeltaAngle(rotationLast_Eulers.z, rotationCurrent_Eulers.z)
            );
            eulerAnglesDelta.Scale(i_cRotation.Scale);

            // apply
            i_cRotation.RotationTrackedUnscaled = rotationCurrent;
            i_cRotation.RotationRenderScaled += eulerAnglesDelta;
            i_cRotation.GetComponentInChildren<Renderer>().material.SetVector("_Rotation", i_cRotation.RotationRenderScaled);
          }
        }
      );
    }

#endregion
  }
}