// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cell_Super : Obj_Item_Weapon_Cell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "powerstorage=5";
			this.maxcharge = 20000;
			this.starting_materials = new ByTable().Set( "$iron", 700 ).Set( "$glass", 70 );
			this.icon_state = "scell";
		}

		public Obj_Item_Weapon_Cell_Super ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}