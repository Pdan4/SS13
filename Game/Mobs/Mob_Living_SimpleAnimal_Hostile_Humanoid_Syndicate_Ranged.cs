// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Humanoid_Syndicate_Ranged : Mob_Living_SimpleAnimal_Hostile_Humanoid_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ranged = true;
			this.rapid = true;
			this.retreat_distance = 5;
			this.minimum_distance = 5;
			this.icon_living = "syndicateranged";
			this.casingtype = typeof(Obj_Item_AmmoCasing_A12mm);
			this.projectilesound = "sound/weapons/Gunshot_smg.ogg";
			this.projectiletype = typeof(Obj_Item_Projectile_Bullet_Midbullet2);
			this.items_to_drop = new ByTable(new object [] { typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_C20r) });
			this.icon_state = "syndicateranged";
		}

		public Mob_Living_SimpleAnimal_Hostile_Humanoid_Syndicate_Ranged ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}