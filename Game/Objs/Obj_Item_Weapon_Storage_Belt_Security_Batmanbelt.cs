// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Belt_Security_Batmanbelt : Obj_Item_Weapon_Storage_Belt_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bmbelt";
			this.icon_state = "bmbelt";
		}

		// Function from file: belt.dm
		public Obj_Item_Weapon_Storage_Belt_Security_Batmanbelt ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.can_hold.Or( "/obj/item/weapon/gun/hookshot" );
			return;
		}

	}

}