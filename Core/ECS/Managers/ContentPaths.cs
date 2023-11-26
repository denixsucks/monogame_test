/****************************************************************************/
// ContentPaths.cs
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
using Microsoft.Xna.Framework.Graphics;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class Content
{
  // -------------------------------------------------------------------------
  // Fonts
  public static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont> {
    {"Font/DebugFont", null},
  };

  // Models
  public static Dictionary<string, Model> models = new Dictionary<string, Model> {
    {"Font/DebugFont", null},
  };
}

} // End of namespace dxsx