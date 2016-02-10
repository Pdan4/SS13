// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Personal_Cabinet : Obj_Structure_Closet_SecureCloset_Personal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "cabinetdetective";
			this.icon_locked = "cabinetdetective_locked";
			this.icon_opened = "cabinetdetective_open";
			this.icon_broken = "cabinetdetective_broken";
			this.icon_off = "cabinetdetective_broken";
			this.icon_state = "cabinetdetective_locked";
		}

		// Function from file: personal.dm
		public Obj_Structure_Closet_SecureCloset_Personal_Cabinet ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 4, (Task13.Closure)(() => {
				this.contents = new ByTable();
				new Obj_Item_Weapon_Storage_Backpack_Satchel_Withwallet( this );
				new Obj_Item_Device_Radio_Headset(  );
				return;
			}));
			return;
		}

		// Function from file: personal.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.broken ) {
				this.icon_state = this.icon_broken;
			} else if ( !this.opened ) {
				
				if ( this.locked ) {
					this.icon_state = this.icon_locked;
				} else {
					this.icon_state = this.icon_closed;
				}
			} else {
				this.icon_state = this.icon_opened;
			}
			return null;
		}

	}

}