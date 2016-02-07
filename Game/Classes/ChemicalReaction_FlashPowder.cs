// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_FlashPowder : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flash powder";
			this.id = "flash_powder";
			this.result = "flash_powder";
			this.required_reagents = new ByTable().Set( "aluminium", 1 ).Set( "potassium", 1 ).Set( "sulfur", 1 );
			this.result_amount = 3;
		}

		// Function from file: pyrotechnics.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic location = null;
			EffectSystem_SparkSpread s = null;
			Mob_Living_Carbon C = null;

			
			if ( Lang13.Bool( holder.has_reagent( "stabilizing_agent" ) ) ) {
				return;
			}
			location = GlobalFuncs.get_turf( holder.my_atom );
			s = new EffectSystem_SparkSpread();
			s.set_up( 2, 1, location );
			s.start();

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( ( created_volume ??0) / 10, location ), typeof(Mob_Living_Carbon) )) {
				C = _a;
				

				if ( C.flash_eyes() ) {
					
					if ( Map13.GetDistance( C, location ) < 4 ) {
						C.Weaken( 5 );
					} else {
						C.Stun( 5 );
					}
				}
			}
			holder.remove_reagent( "flash_powder", created_volume );
			return;
		}

	}

}