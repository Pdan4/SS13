// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Coin_Mythril : Obj_Item_Weapon_Coin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cmineral = "mythril";
			this.value = 400;
			this.icon_state = "coin_mythril_heads";
		}

		public Obj_Item_Weapon_Coin_Mythril ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}