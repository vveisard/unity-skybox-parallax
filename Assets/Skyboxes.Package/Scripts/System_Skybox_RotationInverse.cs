using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {
  public class System_Skybox_RotationInverse : PsuedoSystem {
    protected void LateUpdate() {
      Components.ForEach<Component_Skybox_Entities, Component_Skybox_RotationInverse>(
        (i_cEntities, i_cRotation) => {

          Quaternion i_rotation;
          if (i_cEntities.EntityOrigin == null) {
            // global rotation
            i_rotation = i_cEntities.EntityTarget.transform.rotation;
          } else {
            // relative rotation of current to track
            i_rotation = Quaternion.Inverse(i_cEntities.EntityOrigin.transform.rotation) * i_cEntities.EntityTarget.transform.rotation;
          }

          i_cEntities.EntityRender.GetComponentInChildren<Renderer>().material.SetVector("_LocalRotation", Quaternion.Inverse(i_rotation).eulerAngles);
        }
      );
    }
  }
}