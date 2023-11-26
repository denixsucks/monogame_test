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
using System.Collections.Generic;
using Arch.Core;

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

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  List<SystemBase<GameTime>> systems = new List<SystemBase<GameTime>>();

  // -------------------------------------------------------------------------
  public GraphicsDeviceManager graphics;
  public SpriteBatch spriteBatch;

  // -------------------------------------------------------------------------
  ImGuiNET.ImGuiRenderer imGuiRenderer;
  World world;

  // -------------------------------------------------------------------------
  protected override void Initialize()
  {
#if DEBUG
    {
      imGuiRenderer = new ImGuiNET.ImGuiRenderer(this);
      imGuiRenderer.RebuildFontAtlas();
    }
#endif

    world = World.Create(); // Crates world

    // Adding Systems
    systems.Add(new InputManager() {world = world});
    systems.Add(new FrameCounter() {world = world});

    // Creates Entities in world
    world.Create(
      new Transform { position = Vector3.Zero, rotation = Vector3.Zero, scale = Vector3.One}
    );

    var entity = new Entity();
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
    foreach (var system in systems) {
      system.update(gameTime);
    }

    base.Update(gameTime);
  }

  // -------------------------------------------------------------------------
  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.White);
    // Draw Models
    {
    }

    // Rendering Sprite Batch
    {
      spriteBatch.Begin();
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