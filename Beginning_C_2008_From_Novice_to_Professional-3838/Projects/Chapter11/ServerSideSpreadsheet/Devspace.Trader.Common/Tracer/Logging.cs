#region devspace.com Copyright (c) 2005, Christian Gross
// one line to give the library's name and an idea of what it does.
// Copyright (C) 2005  Christian Gross devspace.com (christianhgross@yahoo.ca)
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
#endregion

using System;
using System.Diagnostics;

namespace Devspace.Trader.Common.Tracer {
     public class Logging {
         public static void Debug( string message) {
             //System.Diagnostics.Debug.Write( "Debug - " + message);
             Console.Write( "Debug - " + message);
         }
         public static void Info( string message) {
             //System.Diagnostics.Debug.Write( "Info - " + message);
             Console.Write( "Info - " + message);
         }
         public static void Warn( string message) {
             //System.Diagnostics.Debug.Write( "Warn - " + message);
             Console.Write( "Warn - " + message);
         }
         public static void Error( string message) {
             //System.Diagnostics.Debug.Write( "Error - " + message);
             Console.Write( "Error - " + message);
         }
         public static void Fatal( string message) {
             //System.Diagnostics.Debug.Write( "Fatal - " + message);
             Console.Write( "Fatal - " + message);
         }
     }
}


