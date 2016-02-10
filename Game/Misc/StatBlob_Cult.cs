// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class StatBlob_Cult : StatBlob {

		public int runes_written = 0;
		public int runes_fumbled = 0;
		public int runes_nulled = 0;
		public int tomes_created = 0;
		public int converted = 0;
		public bool narsie_summoned = false;
		public int narsie_corpses_fed = 0;
		public int surviving_cultists = 0;
		public int deconverted = 0;

		// Function from file: stat_blob.dm
		public override void writeStats( File file = null ) {
			file.WriteMsg( "CULTSTATS|" + this.runes_written + "|" + this.runes_fumbled + "|" + this.runes_nulled + "|" + this.converted + "|" + this.tomes_created + "|" + this.narsie_summoned + "|" + this.narsie_corpses_fed + "|" + this.surviving_cultists + "|" + this.deconverted );
			return;
		}

		// Function from file: stat_blob.dm
		public override void doPostRoundChecks(  ) {
			Mind M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.ticker.minds, typeof(Mind) )) {
				M = _a;
				

				if ( M.active && M.current is Mob_Living_Carbon && M.special_role == "Cultist" ) {
					this.surviving_cultists++;
				}
			}
			return;
		}

	}

}