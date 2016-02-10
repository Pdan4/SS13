// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Drained : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Drained Feeling";
			this.stage = 1;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			GlobalFuncs.to_chat( mob, "<span class='warning'>You feel drained.</span>" );
			return false;
		}

	}

}