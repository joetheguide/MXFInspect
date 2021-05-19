<<<<<<< HEAD:MXF/Metadata/SMPTE ST2067-50 MXFACESPictureSubDescriptor.cs
﻿//
=======
﻿#region license
//
>>>>>>> f648080fd25ab4e8cff46fc6497f5b00050113ea:MXF/Metadata/InterchangeObjects/Tracks/MXFStaticTrack.cs
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
<<<<<<< HEAD:MXF/Metadata/SMPTE ST2067-50 MXFACESPictureSubDescriptor.cs

namespace Myriadbits.MXF
{
	public class ACESPictureSubDescriptor : MXFInterchangeObject
	{
		public ACESPictureSubDescriptor(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "ACESPictureSubDescriptor")
		{
=======
#endregion

namespace Myriadbits.MXF
{
	public class MXFStaticTrack : MXFGenericTrack
	{
		public MXFStaticTrack(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV)
		{
			this.MetaDataName = "Static Track";
>>>>>>> f648080fd25ab4e8cff46fc6497f5b00050113ea:MXF/Metadata/InterchangeObjects/Tracks/MXFStaticTrack.cs
		}

		/// <summary>
		/// Overridden method to process local tags
		/// </summary>
		/// <param name="localTag"></param>
		protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
		{
			return base.ParseLocalTag(reader, localTag); 
		}
<<<<<<< HEAD:MXF/Metadata/SMPTE ST2067-50 MXFACESPictureSubDescriptor.cs

=======
>>>>>>> f648080fd25ab4e8cff46fc6497f5b00050113ea:MXF/Metadata/InterchangeObjects/Tracks/MXFStaticTrack.cs
	}
}
