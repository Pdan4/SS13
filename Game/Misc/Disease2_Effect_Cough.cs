// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Cough : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Anima Syndrome";
			this.stage = 2;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Mob_Living_Carbon M = null;

			mob.say( "*cough" );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( mob, 2 ), typeof(Mob_Living_Carbon) )) {
				M = _a;
				
				((Mob_Living_Carbon)mob).spread_disease_to( M );
			}
			return false;
		}

	}

}