using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// Modifies Rotation of Skybox.
  /// </summary>
  public class System_Skybox_Rotation : System_Skybox_ScaledProperty<Component_Skybox_Rotation, Vector3, Vector3> {
#region methods / concrete

    protected override Vector3 propertyDetermine(GameObject entityTracked) =>
    entityTracked.transform.eulerAngles;

    protected override Vector3 propertyDetermineRelative(GameObject entityTracked, GameObject entityTrackedOrigin) =>
    Quaternion.FromToRotation(entityTracked.transform.forward, entityTrackedOrigin.transform.forward).eulerAngles; // relative eulerAngles

    protected override Vector3 propertyScale(Vector3 property, Vector3 factor) {
      property.Scale(factor);
      return property;
    }

    protected override void propertySet(GameObject render, Vector3 property) {
      render.GetComponentInChildren<Renderer>().material.SetVector("_Rotation", property);
    }

#endregion
  }
}