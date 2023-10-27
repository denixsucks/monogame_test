﻿using System;

namespace dxsx.Core
{
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
}