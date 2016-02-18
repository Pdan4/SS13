// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Symptom_Heal_Longevity : Symptom_Heal {

		public int longevity = 30;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Longevity";
			this.stealth = 3;
			this.resistance = 4;
			this.stage_speed = 4;
			this.transmittable = 4;
			this.level = 3;
		}

		// Function from file: heal.dm
		public override void Start( Disease_Advance A = null ) {
			this.longevity = Rand13.Int( Convert.ToInt32( Lang13.Initial( this, "longevity" ) - 5 ), Convert.ToInt32( Lang13.Initial( this, "longevity" ) + 5 ) );
			return;
		}

		// Function from file: heal.dm
		public override bool Heal( dynamic M = null, Disease_Advance A = null ) {
			this.longevity -= 1;

			if ( !( this.longevity != 0 ) ) {
				A.cure();
			}
			return false;
		}

	}

}