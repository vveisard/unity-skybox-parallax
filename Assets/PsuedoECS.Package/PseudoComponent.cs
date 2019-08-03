using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.PsuedoECS {

  /// <summary>
  /// PsuedoECS Component.
  /// </summary>
  public abstract class PsuedoComponent : MonoBehaviour {

#region methods / private

#endregion

#region Messages

    virtual protected void Awake() {
      this.ComponentRegister();
    }

    virtual protected void OnDestroy() {
      this.ComponentDeregister();
    }

#endregion

  }
}