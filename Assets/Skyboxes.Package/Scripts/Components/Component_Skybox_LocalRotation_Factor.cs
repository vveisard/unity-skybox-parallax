using System;

using SINeDUSTRIES.Unity.Runtime.PsuedoECS;

using UnityEngine;

namespace SINeDUSTRIES.Unity.Runtime.Skybox {
  public class Component_Skybox_LocalRotation_Factor : PsuedoComponent {

    [Range(-1, 1)]
    public Int32 FactorX;

    [Range(-1, 1)]
    public Int32 FactorY;

    [Range(-1, 1)]
    public Int32 FactorZ;
  }
}