// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BluespaceMatterBin : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bluespace Matter Bin";
			this.desc = "A stock part used in the construction of various devices.";
			this.id = "bluespace_matter_bin";
			this.req_tech = new ByTable().Set( "materials", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 160 ).Set( "$diamond", 200 );
			this.reliability = 75;
			this.build_path = typeof(Obj_Item_Weapon_StockParts_MatterBin_Bluespace);
			this.category = new ByTable(new object [] { "Stock Parts" });
		}

	}

}