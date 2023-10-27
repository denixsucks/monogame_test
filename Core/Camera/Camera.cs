using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx.Core
{
  public class Camera {

    public class CameraSettings
    {
      public float fieldOfView;
      public float nearClipPlane;
      public float farClipPlane;

      public CameraSettings(float fieldOfView, float nearClipPlane, float farClipPlane)
      {
        this.fieldOfView = MathHelper.ToRadians(fieldOfView);
        this.nearClipPlane = nearClipPlane;
        this.farClipPlane = farClipPlane;
      }
    }

    public Vector3 cameraPosition;
    public Vector3 cameraTarget;

    Matrix projectionMatrix;
    Matrix viewMatrix;
    Matrix worldMatrix;

    public static void updateCameraPosition(Camera camera, Vector3 delta)
    {
      camera.cameraPosition += delta;
      camera.cameraTarget += delta;
    }

    public void initializeCamera(CameraSettings settings, GraphicsDevice graphicsDevice)
    {
      projectionMatrix = Matrix.CreatePerspectiveFieldOfView(settings.fieldOfView, graphicsDevice.DisplayMode.AspectRatio, settings.nearClipPlane, settings.farClipPlane);
      viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
      worldMatrix = Matrix.CreateWorld(cameraTarget, Vector3.Forward, Vector3.Up);
    }
  }
}