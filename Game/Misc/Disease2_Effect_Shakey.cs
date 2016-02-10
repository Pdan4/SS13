// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Shakey : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "World Shaking Syndrome";
			this.stage = 3;
			this.maxm = 3;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			GlobalFuncs.shake_camera( mob, ( multiplier ?1:0) * 5 );
			return false;
		}

	}

}