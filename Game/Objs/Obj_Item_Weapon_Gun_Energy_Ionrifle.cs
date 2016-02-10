// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Ionrifle : Obj_Item_Weapon_Gun_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.inhand_states = new ByTable().Set( "left_hand", "icons/mob/in-hand/left/guninhands_left.dmi" ).Set( "right_hand", "icons/mob/in-hand/right/guninhands_right.dmi" );
			this.fire_sound = "sound/weapons/ion.ogg";
			this.origin_tech = "combat=2;magnets=4";
			this.w_class = 4;
			this.slot_flags = 1024;
			this.projectile_type = "/obj/item/projectile/ion";
			this.icon_state = "ionrifle";
		}

		public Obj_Item_Weapon_Gun_Energy_Ionrifle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( severity <= 2 ) {
				((Obj_Item_Weapon_Cell)this.power_supply).use( Num13.Floor( Convert.ToDouble( this.power_supply.maxcharge / severity ) ) );
				this.update_icon();
			} else {
				return null;
			}
			return null;
		}

	}

}