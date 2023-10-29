/****************************************************************************/
// PostProcessing.cs
/****************************************************************************/
// This file is part of:
// SignsOfHeaven
/****************************************************************************/
/* Copyright (c) 2023-PRESENT, Deniz Eryilmaz                               */
/* All Rights Reserved.                                                     */
/*                                                                          */
/* THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,          */
/* EXPRESS OR IMPLIED, IN NO EVENT WILL THE AUTHOR(S) BE HELD LIABLE FOR    */
/* ANY DAMAGES ARISING FROM THE USE OR DISTRIBUTION OF THIS SOFTWARE        */
/*                                                                          */
/* Deniz Eryilmaz <erylmzdnz@gmail.com>                                     */
/****************************************************************************/

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class PostProcessing
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  protected GraphicsDevice graphicsDevice;
  protected SpriteBatch spriteBatch;

  // -------------------------------------------------------------------------
  public PostProcessing(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
  {
    this.graphicsDevice = graphicsDevice;
    this.spriteBatch = spriteBatch;
  }

  // -------------------------------------------------------------------------
  public virtual Texture2D Apply(Texture2D input, GameTime gameTime)
  {
    return input;
  }
}

} // End of namespace dxsx

