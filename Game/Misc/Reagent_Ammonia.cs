// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Ammonia : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ammonia";
			this.id = "ammonia";
			this.description = "A caustic substance commonly used in fertilizer or household cleaners.";
			this.reagent_state = 3;
			this.color = "#404030";
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.adjust_nutrient( 1 );

			if ( T.seed != null && !T.dead ) {
				T.health += 0.5;
			}
			return;
		}

	}

}