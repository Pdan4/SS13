// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Pipedispenser : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/pipedispenser";
			this.board_type = "machine";
			this.origin_tech = "programming=3;engineering=2;biotech=3;powerstorage=2";
			this.frame_desc = "Requires 2 Matter Bins, 1 Capacitors, 2 Scanning Module, and 2 Manipulators   ";
			this.req_components = new ByTable()
				.Set( "/obj/item/weapon/stock_parts/matter_bin", 2 )
				.Set( "/obj/item/weapon/stock_parts/capacitor", 1 )
				.Set( "/obj/item/weapon/stock_parts/scanning_module", 2 )
				.Set( "/obj/item/weapon/stock_parts/manipulator", 2 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_Pipedispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}