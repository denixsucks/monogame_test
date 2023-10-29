/****************************************************************************/
// GraphicSettings.cs
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class GraphicSettings
{
  // -------------------------------------------------------------------------
  ushort[] widths = new ushort[] { 3840, 2560, 2560, 1920, 1366, 1280, 1280 };
  ushort[] heights = new ushort[] { 2160, 1440, 1080, 1080, 768, 1024, 720 };

  // -------------------------------------------------------------------------
  void changeResolution(byte newResolution, GraphicsDeviceManager graphics)
  {
    if (newResolution >= 0 && newResolution < widths.Length) {
      graphics.PreferredBackBufferWidth = widths[newResolution];
      graphics.PreferredBackBufferHeight = heights[newResolution];
      graphics.ApplyChanges();
    }
  }
}

} // End of namespace dxsx

