using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Entities involved in Skybox parallaxing.
  /// </summary>
  public class Component_Skybox_Entities : PsuedoComponent {

#region Data

    /// <summary>
    /// Entity which renders the Skybox.
    /// </summary>
    public GameObject EntityRender;

    /// <summary>
    /// Entity whose properties are passed to the Skybox Renderer.
    /// </summary>
    /// <example>
    /// Position: Skybox render will be passed the position of <see cref="EntityTarget"/>.
    /// </example>
    public GameObject EntityTarget;

    /// <summary>
    /// Entity which properties of <see cref="EntityTarget"/> are calculated relative to.
    /// ie, Skybox properties of <see cref="EntityTarget"/> are calculated relative to <see cref="EntityOrigin"/>.
    /// if null, property is measured or relative to 0 (ie, "globally").
    /// </summary>
    /// <example>
    /// _LocalPosition: Skybox Renderer will be passed the position of <see cref="EntityTarget"/>, relative to <see cref="EntityOrigin"/>.
    /// this effectively moves the Skybox render to <see cref="EntityOrigin"/>.
    /// </example>
    public GameObject EntityOrigin;

#endregion
  }
}