// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Large : Obj_Item_Weapon_Storage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "largebox";
			this.w_class = 42;
			this.foldable = typeof(Obj_Item_Stack_Sheet_Cardboard);
			this.foldable_amount = 4;
			this.starting_materials = new ByTable().Set( "$cardboard", 15000 );
			this.storage_slots = 21;
			this.max_combined_w_class = 42;
			this.autoignition_temperature = 530;
			this.fire_fuel = 3;
			this.icon_state = "largebox";
		}

		public Obj_Item_Weapon_Storage_Box_Large ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}