using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Out:
  /// - modifies <see cref="Component_Skybox_Properties"/> using <see cref="Component_Skybox_LocalRotation_Delta"/>.
  /// </summary>
  public class System_Skybox_LocalRotation_Factor : PsuedoSystem {
    protected void LateUpdate() {
      Components.ForEach<Component_Skybox_Entities, Component_Skybox_Properties, Component_Skybox_LocalRotation_Factor>(
        (i_cEntities, i_cProperties, i_cRotation) => {

          Quaternion i_rotation;
          if (i_cEntities.EntityOrigin == null) {
            // global rotation
            i_rotation = i_cEntities.EntityTarget.transform.rotation;
          } else {
            // relative rotation of current to track
            i_rotation = Quaternion.Inverse(i_cEntities.EntityOrigin.transform.rotation) * i_cEntities.EntityTarget.transform.rotation;
          }

          // scale it
          Vector3 eulers = i_rotation.eulerAngles;
          eulers.Scale(-i_cRotation.Factor);

          i_cProperties.LocalRotation = Quaternion.Inverse(Quaternion.Euler(eulers)); // LocalRotation is inverse of the EntityTarget
        }
      );
    }
  }
}