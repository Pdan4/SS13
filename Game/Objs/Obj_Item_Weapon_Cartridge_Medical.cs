// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cartridge_Medical : Obj_Item_Weapon_Cartridge {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.access_medical = true;
			this.icon_state = "cart-m";
		}

		public Obj_Item_Weapon_Cartridge_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}