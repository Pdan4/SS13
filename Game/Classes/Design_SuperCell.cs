// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SuperCell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Super-Capacity Power Cell";
			this.desc = "A power cell that holds 20000 units of energy.";
			this.id = "super_cell";
			this.req_tech = new ByTable().Set( "powerstorage", 3 ).Set( "materials", 2 );
			this.reliability = 75;
			this.build_type = 18;
			this.materials = new ByTable().Set( "$metal", 700 ).Set( "$glass", 70 );
			this.construction_time = 100;
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Cell_Super);
			this.category = new ByTable(new object [] { "Misc", "Power Designs" });
		}

	}

}