// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_Rapidregeneration : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Rapid Regeneration";
			this.desc = "We evolve the ability to rapidly regenerate, negating the need for stasis.";
			this.helptext = "Heals a moderate amount of damage every tick.";
			this.genomecost = 8;
			this.verbpath = typeof(Mob).GetMethod( "changeling_rapidregen" );
		}

	}

}