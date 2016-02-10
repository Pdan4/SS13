// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Grey : Species {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Grey";
			this.icobase = "icons/mob/human_races/r_grey.dmi";
			this.deform = "icons/mob/human_races/r_def_grey.dmi";
			this.language = "Grey";
			this.darksight = 5;
			this.eyes = "grey_eyes_s";
			this.max_hurt_damage = 3;
			this.primitive = typeof(Mob_Living_Carbon_Monkey);
			this.flags = 9312;
			this.default_mutations = new ByTable(new object [] { 104 });
			this.default_block_names = new ByTable(new object [] { "REMOTETALK" });
			this.has_mutant_race = false;
		}

	}

}