// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Vendor : Obj_Item_Weapon_Circuitboard {

		public ByTable names_paths = new ByTable()
											.Set( typeof(Obj_Machinery_Vending_Boozeomat), "Booze-O-Mat" )
											.Set( typeof(Obj_Machinery_Vending_Coffee), "Solar's Best Hot Drinks" )
											.Set( typeof(Obj_Machinery_Vending_Snack), "Getmore Chocolate Corp" )
											.Set( typeof(Obj_Machinery_Vending_Cola), "Robust Softdrinks" )
											.Set( typeof(Obj_Machinery_Vending_Cigarette), "ShadyCigs Deluxe" )
											.Set( typeof(Obj_Machinery_Vending_Autodrobe), "AutoDrobe" )
										;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Vending_Boozeomat);
			this.board_type = "machine";
			this.origin_tech = "programming=1";
			this.req_components = new ByTable().Set( typeof(Obj_Item_Weapon_VendingRefill_Boozeomat), 3 );
		}

		public Obj_Item_Weapon_Circuitboard_Vendor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: constructable_frame.dm
		public void set_type( dynamic typepath = null, dynamic user = null ) {
			this.build_path = typepath;
			this.name = "circuit board (" + this.names_paths[this.build_path] + " Vendor)";
			if (user != null)
				user.WriteMsg( "<span class='notice'>You set the board to " + this.names_paths[this.build_path] + ".</span>" );
			this.req_components = new ByTable().Set( Lang13.FindClass( "/obj/item/weapon/vending_refill/" + String13.SubStr( "" + this.build_path, 24, 0 ) ), 3 );
			return;
		}

		// Function from file: constructable_frame.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Screwdriver ) {
				this.set_type( Rand13.PickFromTable( this.names_paths ), user );
			}
			return null;
		}

	}

}