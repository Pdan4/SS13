// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoStorage_Box_BMG50 : Obj_Item_AmmoStorage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=4";
			this.ammo_type = "/obj/item/ammo_casing/BMG50";
			this.max_ammo = 8;
			this.multiple_sprites = true;
			this.icon_state = "50BMG";
		}

		public Obj_Item_AmmoStorage_Box_BMG50 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}