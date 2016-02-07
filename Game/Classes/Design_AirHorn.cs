// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AirHorn : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Air Horn";
			this.desc = "Damn son, where'd you find this?";
			this.id = "air_horn";
			this.req_tech = new ByTable().Set( "materials", 2 ).Set( "engineering", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 4000 ).Set( "$bananium", 1000 );
			this.build_path = typeof(Obj_Item_Weapon_Bikehorn_Airhorn);
			this.category = new ByTable(new object [] { "Equipment" });
		}

	}

}