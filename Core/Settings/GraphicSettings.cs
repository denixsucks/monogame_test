using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx.Core.Settings
{
  public class GraphicSettings : Settings
  {
    ushort[] widths = new ushort[] { 3840, 2560, 2560, 1920, 1366, 1280, 1280 };
    ushort[] heights = new ushort[] { 2160, 1440, 1080, 1080, 768, 1024, 720 };

    void changeResolution(byte newResolution, GraphicsDeviceManager graphics)
    {
      if (newResolution >= 0 && newResolution < widths.Length) {
        graphics.PreferredBackBufferWidth = widths[newResolution];
        graphics.PreferredBackBufferHeight = heights[newResolution];
        graphics.ApplyChanges();
      }
    }
  }
}
