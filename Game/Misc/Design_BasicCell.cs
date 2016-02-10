// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BasicCell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Basic Power Cell";
			this.desc = "A basic power cell that holds 1000 units of energy";
			this.id = "basic_cell";
			this.req_tech = new ByTable().Set( "powerstorage", 1 );
			this.build_type = 54;
			this.materials = new ByTable().Set( "$iron", 700 ).Set( "$glass", 50 );
			this.build_path = typeof(Obj_Item_Weapon_Cell);
			this.category = "Engineering";
		}

	}

}