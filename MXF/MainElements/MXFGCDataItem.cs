﻿#region license
//
// MXF - Myriadbits .NET MXF library. 
// Read MXF Files.
// Copyright (C) 2015 Myriadbits, Jochem Bakker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// For more information, contact me at: info@myriadbits.com
//
#endregion

using System;
using System.Collections.Generic;

namespace Myriadbits.MXF
{	
	public class MXFGCDataItem : MXFEssenceElement
	{
		private static Dictionary<int, string> m_itemTypes = new Dictionary<int, string>();

		public MXFGCDataItem(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV)
		{
			long nofPackets = headerKLV.Length;
			switch (headerKLV.Key[14])
            {
				case 0x0b: //TimedTextDataElement
					this.AddChild(new MXFTimedTextDataElement(reader, headerKLV.Length));
					break;
				default:
					for (int n = 0; n < nofPackets; n++)
					{
						MXFANCPacket newpacket = new MXFANCPacket(reader);
						this.AddChild(newpacket);
					}
					break;
			}

		}

		public override string ToString()
		{
			if (this.Children != null)
				return string.Format("Generic Container Data Item [packets {0}]", this.Children.Count);
			return string.Format("Generic Container Data Item [packets 0]");
		}
	}
}
