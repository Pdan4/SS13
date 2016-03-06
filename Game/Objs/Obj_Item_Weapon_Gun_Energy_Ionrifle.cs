// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Ionrifle : Obj_Item_Weapon_Gun_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=2;magnets=4";
			this.can_flashlight = true;
			this.w_class = 5;
			this.slot_flags = 1024;
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Ion) });
			this.ammo_x_offset = 3;
			this.flight_x_offset = 17;
			this.flight_y_offset = 9;
			this.icon_state = "ionrifle";
		}

		public Obj_Item_Weapon_Gun_Energy_Ionrifle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override double emp_act( int severity = 0 ) {
			return 0;
		}

	}

}