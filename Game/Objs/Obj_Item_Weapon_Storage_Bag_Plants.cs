// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Bag_Plants : Obj_Item_Weapon_Storage_Bag {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.storage_slots = 50;
			this.max_combined_w_class = 200;
			this.max_w_class = 3;
			this.w_class = 1;
			this.can_hold = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown), typeof(Obj_Item_Seeds), typeof(Obj_Item_Weapon_Grown) });
			this.burn_state = 0;
			this.icon = "icons/obj/hydroponics/equipment.dmi";
			this.icon_state = "plantbag";
		}

		public Obj_Item_Weapon_Storage_Bag_Plants ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}