using System;

using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Parameters for modifying the _LocalRotation property of the Skybox Renderer.
  /// </summary>
  public class Component_Skybox_LocalRotation_Delta : PsuedoComponent {

#region Data

    public Vector3 Factor;

    /// <summary>
    /// Last unscaled rotation of the tracked entity.
    /// </summary>
    [HideInInspector]
    public Quaternion RotationTrackedLast = Quaternion.identity;

    /// <summary>
    /// Total amount of RotationDifference.
    /// </summary>
    [HideInInspector]
    public Quaternion LocalRotationDelta = Quaternion.identity;

#endregion
  }
}