// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Coin_Plasma : Obj_Item_Weapon_Coin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.material = "$plasma";
			this.credits = 0.1;
			this.melt_temperature = 2283.14990234375;
			this.icon_state = "coin_plasma";
		}

		public Obj_Item_Weapon_Coin_Plasma ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}