// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Deaf : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hard of Hearing Syndrome";
			this.stage = 3;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			mob.ear_deaf += 20;
			return false;
		}

	}

}