// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Wand_Door : Obj_Item_Weapon_Gun_Magic_Wand {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic_Door);
			this.fire_sound = "sound/magic/Staff_Door.ogg";
			this.max_charges = 20;
			this.no_den_usage = true;
			this.icon_state = "doorwand";
		}

		public Obj_Item_Weapon_Gun_Magic_Wand_Door ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wand.dm
		public override void zap_self( dynamic user = null ) {
			return;
		}

	}

}