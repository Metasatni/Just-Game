using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Just_Game_Remaster;

public static class EnumerableExtensions {

  public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) {
    return collection?.Any() != true;
  }


}
