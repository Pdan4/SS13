// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoStorage_Magazine_Mc9mm : Obj_Item_AmmoStorage_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=2";
			this.ammo_type = "/obj/item/ammo_casing/c9mm";
			this.max_ammo = 8;
			this.sprite_modulo = 8;
			this.multiple_sprites = true;
			this.icon_state = "9x19p";
		}

		public Obj_Item_AmmoStorage_Magazine_Mc9mm ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}