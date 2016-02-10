// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Bag_Ore : Obj_Item_Weapon_Storage_Bag {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot_flags = 2560;
			this.storage_slots = 50;
			this.max_combined_w_class = 200;
			this.max_w_class = 3;
			this.can_hold = new ByTable(new object [] { "/obj/item/weapon/ore" });
			this.icon = "icons/obj/mining.dmi";
			this.icon_state = "satchel";
		}

		public Obj_Item_Weapon_Storage_Bag_Ore ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}