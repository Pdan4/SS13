// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Block : Objective {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.explanation_text = "Do not allow any organic lifeforms to escape on the shuttle alive.";
		}

		public Objective_Block ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override dynamic check_completion(  ) {
			dynamic shuttle = null;
			ByTable protected_mobs = null;
			Mob_Living player = null;

			
			if ( this.blocked ) {
				return 0;
			}

			if ( !( ((dynamic)this.owner).current is Mob_Living_Silicon ) ) {
				return 0;
			}

			if ( GlobalVars.emergency_shuttle.location < 2 ) {
				return 0;
			}

			if ( !Lang13.Bool( ((dynamic)this.owner).current ) ) {
				return 0;
			}
			shuttle = Lang13.FindObj( typeof(Zone_Shuttle_Escape_Centcom) );
			protected_mobs = new ByTable(new object [] { typeof(Mob_Living_Silicon_Ai), typeof(Mob_Living_Silicon_Pai), typeof(Mob_Living_Silicon_Robot), typeof(Mob_Living_Silicon_Robot_Mommi) });

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living) )) {
				player = _a;
				
				Interface13.Stat( null, protected_mobs.Contains( player.type ) );

				if ( player is Mob_Living ) {
					continue;
				}

				if ( player.mind != null ) {
					
					if ( player.stat != 2 ) {
						Interface13.Stat( null, shuttle.Contains( GlobalFuncs.get_turf( player ) ) );

						if ( false ) {
							return 0;
						}
					}
				}
			}
			return 1;
		}

	}

}