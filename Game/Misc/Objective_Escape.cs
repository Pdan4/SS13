// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Escape : Objective {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.explanation_text = "Escape on the shuttle or an escape pod alive and free.";
		}

		public Objective_Escape ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override dynamic check_completion(  ) {
			dynamic location = null;
			Mob_Living_Silicon_Robot H = null;
			Mob_Living_Silicon_Robot C = null;
			Ent_Static check_area = null;

			
			if ( this.blocked ) {
				return 0;
			}

			if ( ((dynamic)this.owner).current is Mob_Living_Silicon ) {
				return 0;
			}

			if ( ((dynamic)this.owner).current is Mob_Living_Carbon_Brain || ((dynamic)this.owner).current is Mob_Living_SimpleAnimal_Borer ) {
				return 0;
			}

			if ( GlobalVars.emergency_shuttle.location < 2 ) {
				return 0;
			}

			if ( !Lang13.Bool( ((dynamic)this.owner).current ) || Convert.ToInt32( ((dynamic)this.owner).current.stat ) == 2 ) {
				return 0;
			}
			location = GlobalFuncs.get_turf( ((dynamic)this.owner).current.loc );

			if ( !Lang13.Bool( location ) ) {
				return 0;
			}

			if ( location is Tile_Simulated_Shuttle_Floor4 ) {
				
				if ( ((dynamic)this.owner).current is Mob_Living_Carbon_Human ) {
					H = ((dynamic)this.owner).current;

					if ( !H.restrained() ) {
						return 1;
					}
				} else if ( ((dynamic)this.owner).current is Mob_Living_Carbon ) {
					C = ((dynamic)this.owner).current;

					if ( !Lang13.Bool( ((dynamic)C).handcuffed ) ) {
						return 1;
					}
				}
				return 0;
			}
			check_area = location.loc;

			if ( check_area is Zone_Shuttle_Escape_Centcom ) {
				return 1;
			}

			if ( check_area is Zone_Shuttle_EscapePod1_Centcom ) {
				return 1;
			}

			if ( check_area is Zone_Shuttle_EscapePod2_Centcom ) {
				return 1;
			}

			if ( check_area is Zone_Shuttle_EscapePod3_Centcom ) {
				return 1;
			}

			if ( check_area is Zone_Shuttle_EscapePod5_Centcom ) {
				return 1;
			} else {
				return 0;
			}
		}

	}

}