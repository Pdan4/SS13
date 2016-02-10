// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Bear_Skrite : Mob_Living_SimpleAnimal_Hostile_Bear {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "skrite";
			this.icon_dead = "skrite_dead";
			this.icon_gib = "skrite_dead";
			this.default_icon_floor = "skritefloor";
			this.default_icon_space = "skrite";
			this.speak = new ByTable(new object [] { "SKREEEEEEEE!", "SKRAAAAAAAAW!", "KREEEEEEEEE!" });
			this.speak_emote = new ByTable(new object [] { "screams", "shrieks" });
			this.emote_hear = new ByTable(new object [] { "snarls" });
			this.emote_see = new ByTable(new object [] { "lets out a scream", "rubs its claws together" });
			this.speak_chance = 20;
			this.meat_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat);
			this.maxHealth = 150;
			this.health = 150;
			this.melee_damage_lower = 10;
			this.attack_sound = "sound/effects/lingstabs.ogg";
			this.attacktext = "uses its blades to stab";
			this.projectiletype = typeof(Obj_Item_Projectile_Energy_Neurotox);
			this.projectilesound = "sound/weapons/pierce.ogg";
			this.ranged = true;
			this.move_to_delay = 7;
			this.icon_state = "skrite";
		}

		public Mob_Living_SimpleAnimal_Hostile_Bear_Skrite ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}