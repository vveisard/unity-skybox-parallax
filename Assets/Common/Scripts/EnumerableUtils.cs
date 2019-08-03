using System;
using System.Collections.Generic;

namespace SINeDUSTRIES.Collections {
  static public class EnumerableUtils {
    static public void ForEach<T>(this IEnumerable<T> thisEnumerable, Action<T> action) {
      foreach (T i in thisEnumerable) {
        action(i);
      }
    }
  }
}