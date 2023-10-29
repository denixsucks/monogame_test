/****************************************************************************/
// MainGame.cs
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
public class MainGame : Game
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public MainGame()
  {
    Content.RootDirectory = "Content";
    graphics = new GraphicsDeviceManager(this) {
      SynchronizeWithVerticalRetrace = true,
      IsFullScreen = false
    };
    IsFixedTimeStep = false;
    IsMouseVisible = true;
  }

  // -------------------------------------------------------------------------
  public GraphicsDeviceManager graphics;
  public SpriteBatch spriteBatch;

  // -------------------------------------------------------------------------
  FrameCounter frameCounter;
  ImGuiNET.ImGuiRenderer imGuiRenderer;

  // -------------------------------------------------------------------------
  protected override void Initialize()
  {
    frameCounter = new FrameCounter();
#if DEBUG
    {
      imGuiRenderer = new ImGuiNET.ImGuiRenderer(this);
      imGuiRenderer.RebuildFontAtlas();
    }
#endif
    base.Initialize();
  }

  // -------------------------------------------------------------------------
  protected override void LoadContent()
  {
    spriteBatch = new SpriteBatch(GraphicsDevice);
    ContentLoader.loadContent(Content);
    base.LoadContent();
  }

  // -------------------------------------------------------------------------
  protected override void UnloadContent()
  {
    ContentLoader.unloadContent();
    base.UnloadContent();
  }

  // -------------------------------------------------------------------------
  protected override void Update(GameTime gameTime)
  {
    base.Update(gameTime);
  }

  // -------------------------------------------------------------------------
  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.White);

    // Rendering Sprite Batch
    {
      spriteBatch.Begin();
      var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
      frameCounter.Update(deltaTime);
      var fps = string.Format("FPS: {0}", frameCounter.averageFramesPerSecond);
      spriteBatch.DrawString(dxsx.Content.fonts["Font/DebugFont"], fps, new Vector2(1, 1), Color.Black);
      spriteBatch.End();
    }

#if DEBUG
    // Rendering ImGui
    {
      var oldSamplerState = GraphicsDevice.SamplerStates[0];
      GraphicsDevice.SamplerStates[0] = new SamplerState();
      imGuiRenderer.BeforeLayout(gameTime);
      ImGuiNET.ImGui.ShowDemoWindow();
      imGuiRenderer.AfterLayout();
      GraphicsDevice.SamplerStates[0] = oldSamplerState;
    }
#endif
    base.Draw(gameTime);
  }
}
}