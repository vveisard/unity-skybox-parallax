using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {
  /// <summary>
  /// <see cref="Component_Skybox_Property"/>.
  /// </summary>
  public abstract class System_Skybox_ScaledProperty<TComponentScaledProperty, TProperty, TFactor> : PsuedoSystem
  where TComponentScaledProperty : Component_Skybox_ScaledProperty<TProperty, TFactor> {
#region methods / properties

    protected abstract TProperty propertyDetermine(GameObject entityTracked);

    abstract protected TProperty propertyDetermineRelative(GameObject entityTracked, GameObject entityTrackedOrigin);

    abstract protected TProperty propertyScale(TProperty property, TFactor scaleFactor);

    abstract protected void propertySet(GameObject entityRender, TProperty property);

#endregion

#region messages

    protected void LateUpdate() {

      Components.ForEach<Component_Skybox_Entities>(
        (c_skyboxEntities) => {

          TComponentScaledProperty renderScaledProperty = c_skyboxEntities.EntityRender.GetComponentInChildren<TComponentScaledProperty>();

          if (renderScaledProperty != null) {
            TProperty i_property;
            if (c_skyboxEntities.EntityTrackOrigin == null) {
              // origin does not exist
              // calculate property globally
              i_property = propertyDetermine(c_skyboxEntities.EntityTrack);
            } else {
              // origin exists
              // calculate property relative to origin
              i_property = propertyDetermineRelative(c_skyboxEntities.EntityTrack, c_skyboxEntities.EntityTrackOrigin);
            }

            i_property = this.propertyScale(i_property, c_skyboxEntities.EntityRender.GetComponentInChildren<TComponentScaledProperty>().Factor); // scale property by the factor

            this.propertySet(c_skyboxEntities.EntityRender, i_property); // assign property
          }
        }
      );
    }
  }

#endregion
}