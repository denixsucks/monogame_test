/****************************************************************************/
// FrameCounter.cs
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

using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class FrameCounter : SystemBase<GameTime>
{
  // -------------------------------------------------------------------------
  public long totalFrames { get; private set; }
  public float totalSeconds { get; private set; }
  public float averageFramesPerSecond { get; private set; }
  public float currentFramesPerSecond { get; private set; }

  // -------------------------------------------------------------------------
  public const int maximumSamples = 100;

  // -------------------------------------------------------------------------
  Queue<float> sampleBuffer = new();

  // -------------------------------------------------------------------------
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override void update(in GameTime gameTime)
  {
    float deltaTime = (float) gameTime.ElapsedGameTime.TotalMilliseconds;
    currentFramesPerSecond = 1.0f / deltaTime;

    sampleBuffer.Enqueue(currentFramesPerSecond);

    if (sampleBuffer.Count > maximumSamples) {
      sampleBuffer.Dequeue();
      averageFramesPerSecond = sampleBuffer.Average(i => i);
    }
    else {
      averageFramesPerSecond = currentFramesPerSecond;
    }

    totalFrames++;
    totalSeconds += deltaTime;
  }

  // -------------------------------------------------------------------------
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void draw(SpriteBatch spriteBatch)
  {
    var fps = string.Format("FPS: {0}", averageFramesPerSecond);
    spriteBatch.DrawString(dxsx.Content.fonts["Font/DebugFont"], fps, new Vector2(1, 1), Color.Black);
  }
}

} // End of namespace dxsx

