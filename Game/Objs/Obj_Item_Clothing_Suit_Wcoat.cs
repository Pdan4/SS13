// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Wcoat : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "wcoat";
			this.blood_overlay_type = "armor";
			this.body_parts_covered = 6;
			this.icon_state = "vest";
		}

		public Obj_Item_Clothing_Suit_Wcoat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}