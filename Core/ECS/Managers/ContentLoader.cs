/****************************************************************************/
// ContentLoader.cs
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

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public sealed class ContentLoader
{
  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  ContentLoader() {}

  // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  public static ContentLoader instance {
    get {
      if (_instance == null) _instance = new ContentLoader();
      return _instance;
    }
  }

  // -------------------------------------------------------------------------
  static ContentLoader _instance = null;

  // -------------------------------------------------------------------------
  public static void loadContent(ContentManager manager)
  {
    loadFonts(manager);
    loadModels(manager);
  }

  // -------------------------------------------------------------------------
  public static void unloadContent()
  {

  }

  // -------------------------------------------------------------------------
  public static void loadModels(ContentManager manager)
  {
    foreach(var model in Content.models)
      Content.models[model.Key] = manager.Load<Model>(model.Key);
  }

  // -------------------------------------------------------------------------
  static void loadFonts(ContentManager manager)
  {
    foreach(var font in Content.fonts)
      Content.fonts[font.Key] = manager.Load<SpriteFont>(font.Key);
  }
}

} // End of namespace dxsx
