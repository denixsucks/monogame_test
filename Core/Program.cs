﻿/****************************************************************************/
// Program.cs
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

using System;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public static class Program
{
  [STAThread]
  static void Main()
  {
    using (var game = new MainGame()) {
      game.Run();
    }
  }
}

} // End of namespace dxsx

