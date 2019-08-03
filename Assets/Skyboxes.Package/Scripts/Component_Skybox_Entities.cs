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
    /// Entity which is tracked.
    /// </summary>
    public GameObject EntityTrack;

    /// <summary>
    /// Entity which <see cref="EntityTrack"/> property is calculated relative to.
    /// if null, property is measured "globally".
    /// </summary>
    public GameObject EntityTrackOrigin;

#endregion
  }
}