// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Tile_Sepia : Obj_Item_Stack_Tile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "floor tile";
			this.force = 6;
			this.materials = new ByTable().Set( "$metal", 500 );
			this.throwforce = 10;
			this.flags = 64;
			this.turf_type = typeof(Tile_Simulated_Floor_Sepia);
			this.icon_state = "tile-sepia";
		}

		public Obj_Item_Stack_Tile_Sepia ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}