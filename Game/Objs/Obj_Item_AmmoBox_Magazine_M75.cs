// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_M75 : Obj_Item_AmmoBox_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Caseless_A75);
			this.caliber = "75";
			this.multiple_sprites = 2;
			this.max_ammo = 8;
			this.icon_state = "75";
		}

		public Obj_Item_AmmoBox_Magazine_M75 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}