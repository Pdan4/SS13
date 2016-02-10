// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Anobattery : Obj_Item_Weapon {

		public dynamic battery_effect = null;
		public double capacity = 200;
		public double stored_charge = 0;
		public string effect_id = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/xenoarchaeology.dmi";
			this.icon_state = "anobattery0";
		}

		// Function from file: ano_device_battery.dm
		public Obj_Item_Weapon_Anobattery ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.battery_effect = new ArtifactEffect();
			return;
		}

		// Function from file: ano_device_battery.dm
		public void UpdateSprite(  ) {
			double p = 0;

			p = this.stored_charge / this.capacity * 100;
			p = Num13.MinInt( ((int)( p )), 100 );
			this.icon_state = "anobattery" + Num13.Round( p, 25 );
			return;
		}

	}

}