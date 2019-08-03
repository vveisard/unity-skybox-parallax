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

          // get relative rotation
          Quaternion i_rotation;
          if (i_cEntities.EntityOrigin == null) {
            // rotation of target, relative to nothing
            i_rotation = i_cEntities.EntityTarget.transform.rotation;
          } else {
            // rotation of target, relative to origin
            i_rotation = Quaternion.Inverse(i_cEntities.EntityOrigin.transform.rotation) * i_cEntities.EntityTarget.transform.rotation;
          }

          // scale it
          Vector3 eulers = i_rotation.eulerAngles;
          eulers = eulers.Scale(-i_cRotation.FactorX, -i_cRotation.FactorY, -i_cRotation.FactorZ);

          // get the inverse rotation. ie, the rotation that makes the Skybox render global rotation == Quaternion.Identity
          i_rotation = Quaternion.Inverse(Quaternion.Euler(eulers));

          i_cProperties.LocalRotation = i_rotation;
        }
      );
    }
  }
}