// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Humanoid_Pirate_Ranged : Mob_Living_SimpleAnimal_Hostile_Humanoid_Pirate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "pirateranged";
			this.melee_damage_lower = 10;
			this.melee_damage_upper = 10;
			this.projectilesound = "sound/weapons/laser.ogg";
			this.ranged = true;
			this.rapid = true;
			this.retreat_distance = 5;
			this.minimum_distance = 5;
			this.projectiletype = typeof(Obj_Item_Projectile_Beam);
			this.corpse = typeof(Obj_Effect_Landmark_Corpse_Pirate_Ranged);
			this.items_to_drop = new ByTable(new object [] { typeof(Obj_Item_Weapon_Gun_Energy_Laser) });
			this.icon_state = "pirateranged";
		}

		public Mob_Living_SimpleAnimal_Hostile_Humanoid_Pirate_Ranged ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}