/****************************************************************************/
// InputManager.cs
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

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public sealed class InputManager
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  InputManager() {}

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public static InputManager instance {
    get {
      if (_instance == null)
        _instance = new InputManager();
      return _instance;
    }
  }

  // -------------------------------------------------------------------------
  static InputManager _instance = null;
  static float movementSpeed = 0.1f;

  // -------------------------------------------------------------------------
  static Dictionary<Keys, Vector3> keyMappings = new Dictionary<Keys, Vector3> {
    { Keys.Left, new Vector3(-0.1f, 0, 0) },
    { Keys.Right, new Vector3(0.1f, 0, 0) },
    { Keys.Up, new Vector3(0, -0.1f, 0) },
    { Keys.Down, new Vector3(0, 0.1f, 0) },
    { Keys.OemPlus, new Vector3(0, 0, 0.1f) },
    { Keys.OemMinus, new Vector3(0, 0, -0.1f) }
  };

  // -------------------------------------------------------------------------
  public static void processInput(Camera camera)
  {
    KeyboardState keyState = Keyboard.GetState();
    foreach (var keyMapping in keyMappings) {
      if (keyState.IsKeyDown(keyMapping.Key)) {
        Camera.updateCameraPosition(camera, keyMapping.Value * movementSpeed);
      }
    }
  }
}

} // End of namespace dxsx
