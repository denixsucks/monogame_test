using System.ComponentModel;
using System.Diagnostics;
using dxsx.Core.PostProcessing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dxsx.Core
{
  public class MainGame : Game
  {
    GraphicsDeviceManager graphicsDeviceManager;
    SpriteBatch spriteBatch;
    SpriteFont font;
    Camera mainCamera;
    Debug.FrameCounter frameCounter;

    public MainGame()
    {
      graphicsDeviceManager = new GraphicsDeviceManager(this);
      graphicsDeviceManager.SynchronizeWithVerticalRetrace = true;
      graphicsDeviceManager.IsFullScreen = false;
      IsFixedTimeStep = false;
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
    }

    protected override void Initialize()
    {
      // TODO: Add your initialization logic here
      mainCamera = new Camera();
      Camera.CameraSettings cameraSettings = new Camera.CameraSettings(60f, 1f, 1000f);
      frameCounter = new Debug.FrameCounter();
      mainCamera.initializeCamera(cameraSettings, GraphicsDevice);
      base.Initialize();
    }

    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);
      font = Content.Load<SpriteFont>("DebugFont");
      // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
      InputManager.processInput(mainCamera);
      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.White);
      // GraphicsDevice.SetVertexBuffer(vertexBuffer);
      RasterizerState rasterizerState = new RasterizerState();
      rasterizerState.CullMode = CullMode.None;
      GraphicsDevice.RasterizerState = rasterizerState;
      {
        spriteBatch.Begin();
        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        frameCounter.Update(deltaTime);
        var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
        spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.Black);
        spriteBatch.End();
      }
      base.Draw(gameTime);
    }
  }
}