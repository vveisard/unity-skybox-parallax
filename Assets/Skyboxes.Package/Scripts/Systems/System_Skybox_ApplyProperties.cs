using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Applies properties to a skybox render.
  /// </summary>
  public class System_Skybox_ApplyProperties : PsuedoSystem {
    protected void LateUpdate() {
      Components.ForEach<Component_Skybox_Entities, Component_Skybox_Properties>(
        (i_cEntities, i_cProperties) => {
          i_cEntities.EntityRender.GetComponentInChildren<Renderer>().material.SetVector("_LocalPosition", i_cProperties.LocalPosition);
          i_cEntities.EntityRender.GetComponentInChildren<Renderer>().material.SetVector("_LocalRotation", i_cProperties.LocalRotation.eulerAngles);
          i_cEntities.EntityRender.GetComponentInChildren<Renderer>().material.SetVector("_LocalScale", i_cProperties.LocalScale);
        }
      );
    }
  }
}