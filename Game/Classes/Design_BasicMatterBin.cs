// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BasicMatterBin : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Basic Matter Bin";
			this.desc = "A stock part used in the construction of various devices.";
			this.id = "basic_matter_bin";
			this.req_tech = new ByTable().Set( "materials", 1 );
			this.build_type = 6;
			this.materials = new ByTable().Set( "$metal", 80 );
			this.build_path = typeof(Obj_Item_Weapon_StockParts_MatterBin);
			this.category = new ByTable(new object [] { "Stock Parts", "Machinery", "initial" });
		}

	}

}