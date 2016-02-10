// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Phosphorus : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Phosphorus";
			this.id = "phosphorus";
			this.description = "A chemical element, the backbone of biological energy carriers.";
			this.color = "#832828";
			this.custom_metabolism = 0.01;
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.adjust_nutrient( 0.1 );
			T.adjust_water( -0.5 );
			T.weedlevel -= 2;
			return;
		}

	}

}