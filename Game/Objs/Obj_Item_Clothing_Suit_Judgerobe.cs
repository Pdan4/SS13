// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Judgerobe : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "judge";
			this.flags = 8448;
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Weapon_Storage_Fancy_Cigarettes), typeof(Obj_Item_Weapon_Spacecash) });
			this.icon_state = "judge";
		}

		public Obj_Item_Clothing_Suit_Judgerobe ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}