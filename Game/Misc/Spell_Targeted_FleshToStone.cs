// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_FleshToStone : Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Flesh to Stone";
			this.desc = "This spell turns a single person into an inert statue for a long period of time.";
			this.school = "transmutation";
			this.charge_max = 600;
			this.spell_flags = 130;
			this.range = 3;
			this.invocation = "STAUN EI";
			this.invocation_type = "shout";
			this.amt_stunned = 5;
			this.cooldown_min = 200;
			this.hud_state = "wiz_statue";
		}

		// Function from file: flesh_to_stone.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			Mob_Living target = null;

			base.cast( targets, user );

			foreach (dynamic _a in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _a;
				
				new Obj_Structure_Closet_Statue( target.loc, target );
			}
			return false;
		}

	}

}