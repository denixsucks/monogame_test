/****************************************************************************/
// Renderer.cs
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

namespace dxsx
{

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public class Renderer
{
  public static void drawModel(Model model, Vector3 worldPosition)
  {
    foreach (var mesh in model.Meshes) {
      foreach (BasicEffect effect in mesh.Effects) {
        effect.EnableDefaultLighting();
        effect.PreferPerPixelLighting = true;
        effect.World = Matrix.CreateTranslation(worldPosition);
      }
      mesh.Draw();
    }
  }
}

} // End of namespace dxsx