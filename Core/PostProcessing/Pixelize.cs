using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx.Core.PostProcessing
{
  public class Pixelize : PostProcessingEffect
  {
    public Pixelize(GraphicsDevice device, SpriteBatch spriteBatch) : base(device, spriteBatch)
    {
    }

    public override Texture2D Apply(Texture2D input, GameTime gameTime)
    {
      return base.Apply(input, gameTime);
    }
  }
}
