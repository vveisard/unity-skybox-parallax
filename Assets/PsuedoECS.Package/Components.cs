using System;
using System.Collections.Generic;
using System.Linq;

using SINeDUSTRIES.Collections;

namespace SINeDUSTRIES.Unity.Runtime.PsuedoECS {

  /// <summary>
  /// The single PsuedoECS "world".
  /// </summary>
  static public class Components {

#region Components

    static public void ComponentRegister(this PsuedoComponent thisComponent) {
      // get else add to type dictionary
      if (!Components.componentType_to_Components.TryGetValue(thisComponent.GetType(), out ISet<PsuedoComponent> componentsAdd)) {
        componentsAdd = new HashSet<PsuedoComponent>();
        Components.componentType_to_Components.Add(thisComponent.GetType(), componentsAdd);
      }

      componentsAdd.Add(thisComponent);
    }

    static public void ComponentDeregister(this PsuedoComponent thisComponent) =>
      Components.componentType_to_Components[thisComponent.GetType()].Remove(thisComponent);

    /// <summary>
    /// Try to get all <see cref="PsuedoComponent"/> of type <typeparamref name="TComponent"/>.
    /// </summary>
    static public Boolean ComponentsGetTry<TComponent>(out IEnumerable<TComponent> components) where TComponent : PsuedoComponent {
      if (Components.componentType_to_Components.TryGetValue(typeof(TComponent), out ISet<PsuedoComponent> componentsSet)) {
        components = componentsSet.Cast<TComponent>();
        return true;
      } else {
        components = Enumerable.Empty<TComponent>();
        return false;
      }
    }

    static public IEnumerable<TComponent> ComponentsGet<TComponent>()
    where TComponent : PsuedoComponent =>
      Components.componentType_to_Components[typeof(TComponent)].Cast<TComponent>();

#endregion

#region Components / ForEach

    // There is no concept of "archtypes", nor querying. Therefore, the "least shared Component" should be used.
    // Ref is not used, because PsuedoComponents are passed by reference.

    /// <summary>
    /// Invoke an option upon each <see cref="PsuedoComponent"/>.
    /// </summary>
    static public void ForEach<TComponent0>(Action<TComponent0> action)
    where TComponent0 : PsuedoComponent {
      if (Components.ComponentsGetTry<TComponent0>(out IEnumerable<TComponent0> components0)) {
        components0.ForEach(action);
      }
    }

    static public void ForEach<TComponent0, TComponent1>(Action<TComponent0, TComponent1> action)
    where TComponent0 : PsuedoComponent
    where TComponent1 : PsuedoComponent {
      if (Components.ComponentsGetTry<TComponent0>(out IEnumerable<TComponent0> components0)) {
        components0.ForEach(
          iComponent0 => {

            if (iComponent0.gameObject.TryGetComponent(out TComponent1 iComponent1)) {
              action(iComponent0, iComponent1);
            }
          }
        );
      }
    }

    static public void ForEach<TComponent0, TComponent1, TComponent2>(Action<TComponent0, TComponent1, TComponent2> action)
    where TComponent0 : PsuedoComponent
    where TComponent1 : PsuedoComponent
    where TComponent2 : PsuedoComponent {
      if (Components.ComponentsGetTry<TComponent0>(out IEnumerable<TComponent0> components0)) {
        components0.ForEach(
          iComponent0 => {

            if (iComponent0.gameObject.TryGetComponent(out TComponent1 iComponent1)
              && iComponent1.gameObject.TryGetComponent(out TComponent2 iComponent2)
            ) {
              action(iComponent0, iComponent1, iComponent2);
            }
          }
        );
      }
    }

    static public void ForEach<TComponent0, TComponent1, TComponent2, TComponent3>(Action<TComponent0, TComponent1, TComponent2, TComponent3> action)
    where TComponent0 : PsuedoComponent
    where TComponent1 : PsuedoComponent
    where TComponent2 : PsuedoComponent
    where TComponent3 : PsuedoComponent {
      if (Components.ComponentsGetTry<TComponent0>(out IEnumerable<TComponent0> components0)) {
        components0.ForEach(
          iComponent0 => {

            if (iComponent0.gameObject.TryGetComponent(out TComponent1 iComponent1)
              && iComponent1.gameObject.TryGetComponent(out TComponent2 iComponent2)
              && iComponent2.gameObject.TryGetComponent(out TComponent3 iComponent3)
            ) {
              action(iComponent0, iComponent1, iComponent2, iComponent3);
            }
          }
        );
      }
    }

#endregion

#region fields

    /// <summary>
    /// All of the <see cref="PsuedoComponent"/> in the "universe".
    /// key: type of <see cref="PsuedoComponent"/>
    /// value: all <see cref="PsuedoComponent"/> of that type.
    /// </summary>
    static private IDictionary<Type, ISet<PsuedoComponent>> componentType_to_Components = new Dictionary<Type, ISet<PsuedoComponent>>(new EqualityComparer_Type_TypeHandle());

#endregion
  }
}