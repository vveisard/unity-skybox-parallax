using System;
using System.Collections.Generic;

namespace SINeDUSTRIES.Collections {
  /// <summary>
  /// <see cref="EqualityComparer"/> for <see cref="System.Type"/> which uses <see cref="System.Type.TypeHandle"/>.
  /// </summary>
  public class EqualityComparer_Type_TypeHandle : IEqualityComparer<Type> {
    public bool Equals(Type x, Type y) =>
    x.TypeHandle.Value.ToInt32() == y.TypeHandle.Value.ToInt32();

    public int GetHashCode(Type obj) =>
    obj.TypeHandle.Value.ToInt32();
  }
}