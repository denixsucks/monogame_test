using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx.Core
{
  public class MainGame : Game
  {
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

    public GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;

    Camera mainCamera;
    Debug.FrameCounter frameCounter;
    ImGuiNET.ImGuiRenderer imGuiRenderer;

    protected override void Initialize()
    {
      frameCounter = new Debug.FrameCounter();

      {
        imGuiRenderer = new ImGuiNET.ImGuiRenderer(this);
        imGuiRenderer.RebuildFontAtlas();
      }

      // will move to Scene class
      {
        mainCamera = new Camera();
        Camera.CameraSettings cameraSettings = new Camera.CameraSettings(60f, 1f, 1000f);
        mainCamera.initializeCamera(cameraSettings, GraphicsDevice);
      }
      base.Initialize();
    }

    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);
      ContentLoader.loadContent(Content);
      base.LoadContent();
    }

    protected override void UnloadContent()
    {
      ContentLoader.unloadContent();
      base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
      InputManager.processInput(mainCamera);
      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.White);

      // Rendering Sprite Batch
      {
        spriteBatch.Begin();
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        frameCounter.Update(deltaTime);
        var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
        spriteBatch.DrawString(Core.Content.fonts["Font/DebugFont"], fps, new Vector2(1, 1), Color.Black);
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