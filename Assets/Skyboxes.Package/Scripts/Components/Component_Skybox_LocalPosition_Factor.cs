using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Parameters for modifying the _LocalPosition property of the Skybox Renderer.
  /// </summary>
  public class Component_Skybox_LocalPosition_Factor : PsuedoComponent {

#region Data

    /// <summary>
    /// Factor to scale localPosition by.
    /// </summary>
    public Vector3 Factor;

#endregion

  }
}