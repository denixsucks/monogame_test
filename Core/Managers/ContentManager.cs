using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace dxsx.Core
{
  public sealed class ContentManager
  {
    ContentManager() {}

    public static ContentManager instance {
      get {
        if (_instance == null)
          _instance = new ContentManager();
        return _instance;
      }
    }

    static ContentManager _instance = null;

  }
}
