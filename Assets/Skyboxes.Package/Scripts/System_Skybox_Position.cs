using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {

  /// <summary>
  /// <see cref="Component_Skybox_Property"/>.
  /// </summary>
  public class System_Skybox_Position : System_Skybox_ScaledProperty<Component_Skybox_Position, Vector3, Vector3> {
#region methods / concrete

    protected override Vector3 propertyDetermine(GameObject entityTracked) =>
    entityTracked.transform.position;

    protected override Vector3 propertyDetermineRelative(GameObject entityTracked, GameObject entityTrackedOrigin) =>
    entityTracked.transform.position - entityTrackedOrigin.transform.position;

    protected override Vector3 propertyScale(Vector3 property, Vector3 factor) {
      property.Scale(factor);
      return property;
    }

    protected override void propertySet(GameObject render, Vector3 property) {
      Debug.Log($"meep {property}");
      render.GetComponentInChildren<Renderer>().material.SetVector("_Position", property);
    }

#endregion
  }
}