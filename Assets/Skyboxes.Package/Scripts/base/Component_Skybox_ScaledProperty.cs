using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Data for modifying a property of a Skybox, using the property of "tracked" entity.
  /// </summary>
  public abstract class Component_Skybox_ScaledProperty<TProperty, TFactor> : PsuedoComponent {

#region Data

    /// <summary>
    /// Factor by which the property is modified.
    /// </summary>
    public TFactor Factor;

#endregion
  }
}