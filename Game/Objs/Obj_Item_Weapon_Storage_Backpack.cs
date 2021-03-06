// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Backpack : Obj_Item_Weapon_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "backpack";
			this.w_class = 4;
			this.slot_flags = 1024;
			this.max_w_class = 3;
			this.max_combined_w_class = 21;
			this.storage_slots = 21;
			this.burn_state = 0;
			this.burntime = 20;
			this.icon_state = "backpack";
		}

		public Obj_Item_Weapon_Storage_Backpack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: backpack.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			GlobalFuncs.playsound( this.loc, "rustle", 50, 1, -5 );
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}