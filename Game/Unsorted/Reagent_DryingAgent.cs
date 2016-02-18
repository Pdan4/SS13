// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_DryingAgent : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Drying agent";
			this.id = "drying_agent";
			this.description = "Can be used to dry things.";
			this.color = "#A70FFF";
		}

		// Function from file: other_reagents.dm
		public override bool reaction_obj( dynamic O = null, double? volume = null ) {
			dynamic t_loc = null;

			
			if ( O.type == typeof(Obj_Item_Clothing_Shoes_Galoshes) ) {
				t_loc = GlobalFuncs.get_turf( O );
				GlobalFuncs.qdel( O );
				new Obj_Item_Clothing_Shoes_Galoshes_Dry( t_loc );
			}
			return false;
		}

		// Function from file: other_reagents.dm
		public override void reaction_turf( dynamic T = null, double? volume = null ) {
			
			if ( T is Tile_Simulated && Lang13.Bool( T.wet ) ) {
				((Tile_Simulated)T).MakeDry( 1 );
			}
			return;
		}

	}

}