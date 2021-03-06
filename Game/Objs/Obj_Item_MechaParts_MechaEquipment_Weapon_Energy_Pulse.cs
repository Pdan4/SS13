// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Energy_Pulse : Obj_Item_MechaParts_MechaEquipment_Weapon_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.equip_cooldown = 30;
			this.energy_drain = 120;
			this.origin_tech = "materials=3;combat=6;powerstorage=4";
			this.projectile = typeof(Obj_Item_Projectile_Beam_Pulse_Heavy);
			this.fire_sound = "sound/weapons/marauder.ogg";
			this.icon_state = "mecha_pulse";
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Energy_Pulse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}