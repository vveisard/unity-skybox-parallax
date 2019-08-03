using System;

using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Parameters for modifying the _Rotation property of the Skybox Renderer.
  /// </summary>
  public class Component_Skybox_RotationDelta : PsuedoComponent {

#region Data

    /// <summary>
    /// Last unscaled rotation of the tracked entity.
    /// </summary>
    public Quaternion RotationLast = Quaternion.identity;

    /// <summary>
    /// Last scaled rotation of the render.
    /// </summary>
    public Quaternion RotationDeltaTotal = Quaternion.identity;

    public Vector3 Factor;

#endregion
  }
}