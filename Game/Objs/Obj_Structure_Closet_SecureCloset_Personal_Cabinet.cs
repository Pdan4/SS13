// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Personal_Cabinet : Obj_Structure_Closet_SecureCloset_Personal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.burn_state = 0;
			this.burntime = 20;
			this.icon_state = "cabinet";
		}

		// Function from file: personal.dm
		public Obj_Structure_Closet_SecureCloset_Personal_Cabinet ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_Weapon_Storage_Backpack_Satchel_Withwallet( this );
			new Obj_Item_Device_Radio_Headset( this );
			return;
		}

	}

}