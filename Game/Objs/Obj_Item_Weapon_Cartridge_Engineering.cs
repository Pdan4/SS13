// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cartridge_Engineering : Obj_Item_Weapon_Cartridge {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.access_engine = true;
			this.bot_access_flags = 4;
			this.icon_state = "cart-e";
		}

		public Obj_Item_Weapon_Cartridge_Engineering ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}