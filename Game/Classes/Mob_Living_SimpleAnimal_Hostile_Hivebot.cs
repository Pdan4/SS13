// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Hivebot : Mob_Living_SimpleAnimal_Hostile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "basic";
			this.icon_dead = "basic";
			this.health = 15;
			this.maxHealth = 15;
			this.healable = false;
			this.melee_damage_lower = 2;
			this.melee_damage_upper = 3;
			this.attacktext = "claws";
			this.attack_sound = "sound/weapons/bladeslice.ogg";
			this.projectilesound = "sound/weapons/gunshot.ogg";
			this.projectiletype = typeof(Obj_Item_Projectile_Hivebotbullet);
			this.faction = new ByTable(new object [] { "hivebot" });
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.speak_emote = new ByTable(new object [] { "states" });
			this.gold_core_spawnable = 1;
			this.del_on_death = true;
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Decal_Cleanable_RobotDebris) });
			this.icon = "icons/mob/hivebot.dmi";
			this.icon_state = "basic";
		}

		// Function from file: hivebot.dm
		public Mob_Living_SimpleAnimal_Hostile_Hivebot ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.deathmessage = "" + this + " blows apart!";
			return;
		}

		// Function from file: hivebot.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			EffectSystem_SparkSpread s = null;

			s = new EffectSystem_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			base.death( true, toast );
			return false;
		}

	}

}