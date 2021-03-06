// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Russian_Ranged_Officer : Mob_Living_SimpleAnimal_Hostile_Russian_Ranged {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "russianofficer";
			this.maxHealth = 65;
			this.health = 65;
			this.rapid = true;
			this.casingtype = typeof(Obj_Item_AmmoCasing_C9mm);
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Landmark_Mobcorpse_Russian_Ranged_Officer), typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_Pistol_APS) });
			this.icon_state = "russianofficer";
		}

		public Mob_Living_SimpleAnimal_Hostile_Russian_Ranged_Officer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: russian.dm
		public override void Aggro(  ) {
			base.Aggro();
			this.summon_backup( 15 );
			this.say( "V BOJ!!" );
			return;
		}

	}

}