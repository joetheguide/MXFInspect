#region license
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

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Myriadbits.MXF
{
	public class MXFValidatorEssenceDescriptors : MXFValidator
	{
				
		/// <summary>
		/// Check if EssenceDescriptors are present
		/// </summary>
		/// <param name="this.File"></param>
		/// <param name="results"></param>
		public override void OnExecuteTest(ref List<MXFValidationResult> results)
	{
		MXFValidationResult valResult = new MXFValidationResult("Essence Descriptors");
		results.Add(valResult);
		valResult.Category = "Essence Descriptors";

		Stopwatch sw = Stopwatch.StartNew();

			long pec = 0;
			long pedc = 0;
			long sec = 0;
			long sedc = 0;
			long dec = 0;
			long dedc = 0;

			for (int n = 0; n < this.File.Partitions.Count(); n++)
		{
			pec += this.File.Partitions[n].CountPictureEssences();
            pedc += this.File.Partitions[n].CountPictureEssenceDescriptors();
			sec += this.File.Partitions[n].CountSoundEssences();
			sedc += this.File.Partitions[n].CountSoundEssenceDescriptors();
			dec += this.File.Partitions[n].CountDataEssences();
			dedc += this.File.Partitions[n].CountDataEssenceDescriptors();
		}

			long ec = pec + sec + dec;
			long edc = pedc + sedc + dedc;


		//valResult.SetInfo(string.Format("Picture Essence Elements:{0}, Picture Essence Descriptors: {1}, Sound Essence Elements:{2}, Sound Essence Descriptors: {3}, Data Essence Elements:{0}, Data Essence Descriptors: {1}", pec, pedc, sec, sedc, dec, dedc));


		if (ec == 0)
		{
			valResult.SetError(string.Format("Error! No Essence Elements found."));
			return;
		}

		if (edc == 0)
		{
			valResult.SetError(string.Format("Error! No Essence Descriptors found."));
			return;
		}

		if (pec > 0)
		{
			if (pedc == 0)
            {
				valResult.SetError(string.Format("Error! No Picture Essence Descriptors for the {0} Picture Essence Elements found.", pec));
			}
			valResult.SetInfo(string.Format("{0} Picture Essence Descriptors for the {1} Picture Essence Elements found.", pedc, pec));
		}

		if (sec > 0)
		{
			if (sedc == 0)
			{
					valResult.SetError(string.Format("Error! No Sound Essence Descriptors for the {0} Sound Essence Elements found.", sec));
			}
			valResult.SetInfo(string.Format("{0} Sound Essence Descriptors for the {1} Sound Essence Elements found.", sedc, sec));
		}

		if (dec > 0)
		{
			if (dedc == 0)
			{
				valResult.SetError(string.Format("Error! No Data Essence Descriptors for the {0} Data Essence Elements found.", dec));
			}
			valResult.SetInfo(string.Format("{0} Data Essence Descriptors for the {1} Data Essence Elements found.", dedc, dec));
		}

		valResult.SetSuccess(string.Format("{0} Essence Elements and {1} corresponding Essence Descriptors were found", ec, edc));

		LogInfo("Validation completed in {0} msec", sw.ElapsedMilliseconds);
	}



}
}
