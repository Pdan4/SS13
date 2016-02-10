// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_EggIncubator : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/egg_incubator";
			this.board_type = "machine";
			this.origin_tech = "biotech=3";
			this.frame_desc = "Requires 1 Matter Bin and 2 Capacitors   ";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/matter_bin", 1 ).Set( "/obj/item/weapon/stock_parts/capacitor", 2 );
		}

		public Obj_Item_Weapon_Circuitboard_EggIncubator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}