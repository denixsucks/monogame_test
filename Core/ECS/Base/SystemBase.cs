/****************************************************************************/
// SystemBase.cs
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

using Arch.Core;
using Microsoft.Xna.Framework.Graphics;

namespace dxsx {

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public abstract class SystemBase<T>
{
  public required World world;
  public abstract void update(in T state);
}

} // End of namespace dxsx