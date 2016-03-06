// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RcdAmmo : Obj_Item_Weapon {

		public int ammoamt = 40;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "rcdammo";
			this.origin_tech = "materials=3";
			this.materials = new ByTable().Set( "$metal", 3000 ).Set( "$glass", 2000 );
			this.icon = "icons/obj/ammo.dmi";
			this.icon_state = "rcd";
		}

		public Obj_Item_Weapon_RcdAmmo ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}