// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_CandleBox : Obj_Item_Weapon_Storage_Fancy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_type = "candle";
			this.item_state = "candlebox5";
			this.storage_slots = 5;
			this.throwforce = 2;
			this.slot_flags = 512;
			this.spawn_type = typeof(Obj_Item_Candle);
			this.icon = "icons/obj/candle.dmi";
			this.icon_state = "candlebox5";
		}

		public Obj_Item_Weapon_Storage_Fancy_CandleBox ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}