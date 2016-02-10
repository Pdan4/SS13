// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_FlashPowder : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flash powder";
			this.id = "flash_powder";
			this.required_reagents = new ByTable().Set( "aluminum", 1 ).Set( "potassium", 1 ).Set( "sulfur", 1 );
			this.result_amount = null;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			dynamic location = null;
			Effect_Effect_System_SparkSpread s = null;
			int eye_safety = 0;
			Mob_Living_Carbon M = null;

			location = GlobalFuncs.get_turf( holder.my_atom );
			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 2, 1, location );
			s.start();
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/phasein.ogg", 25, 1 );
			eye_safety = 0;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ), typeof(Mob_Living_Carbon) )) {
				M = _a;
				

				if ( M is Mob_Living_Carbon ) {
					eye_safety = M.eyecheck();
				}

				if ( Map13.GetDistance( M, location ) <= 3 ) {
					
					if ( eye_safety < 1 ) {
						Icon13.Flick( "e_flash", M.flash );
						M.Weaken( 15 );
					}
				} else if ( Map13.GetDistance( M, location ) <= 5 ) {
					
					if ( eye_safety < 1 ) {
						Icon13.Flick( "e_flash", M.flash );
						M.Stun( 5 );
					}
				}
			}
			return;
		}

	}

}