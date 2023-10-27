using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dxsx.Core
{
  public sealed class ContentLoader
  {
    ContentLoader() {

    }

    public static ContentLoader instance {
      get {
        if (_instance == null)
          _instance = new ContentLoader();
        return _instance;
      }
    }

    static ContentLoader _instance = null;

    public static void loadContent(ContentManager manager)
    {
      loadFonts(manager);
    }

    public static void unloadContent()
    {

    }

    static void loadFonts(ContentManager manager)
    {
      foreach(var font in Content.fonts)
        Content.fonts[font.Key] = manager.Load<SpriteFont>(font.Key);
    }
  }
}
