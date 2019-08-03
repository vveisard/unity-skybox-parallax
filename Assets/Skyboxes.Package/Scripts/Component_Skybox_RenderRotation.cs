using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// 
  /// </summary>
  public class Component_Skybox_RenderRotation : Component_Skybox_ScaledProperty<Vector3, Vector3> {

    /// <summary>
    /// Last unscaled rotation of the tracked entity.
    /// </summary>
    public Quaternion RotationTrackedUnscaled;

    /// <summary>
    /// Last scaled rotation of the render.
    /// </summary>
    public Vector3 RotationRenderScaled;
  }
}