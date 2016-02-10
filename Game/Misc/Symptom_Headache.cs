// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Symptom_Headache : Symptom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Headache";
			this.stealth = -1;
			this.resistance = 4;
			this.stage_speed = 2;
			this.level = 1;
		}

		// Function from file: vgstation13.dme
		public override void Activate( Disease_Advance A = null ) {
			dynamic M = null;

			base.Activate( A );

			if ( Rand13.PercentChance( GlobalVars.SYMPTOM_ACTIVATION_PROB ) ) {
				M = A.affected_mob;
				GlobalFuncs.to_chat( M, "<span class='notice'>" + Rand13.Pick(new object [] { "Your head hurts.", "Your head starts pounding." }) + "</span>" );
			}
			return;
		}

	}

}