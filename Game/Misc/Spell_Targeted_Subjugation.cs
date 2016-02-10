// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_Subjugation : Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Subjugation";
			this.desc = "This spell temporarily subjugates a target's mind and does not require wizard garb.";
			this.school = "transmutation";
			this.charge_max = 300;
			this.invocation = "DII ODA BAJI";
			this.invocation_type = "whisper";
			this.message = "<span class='danger'>You suddenly feel completely overwhelmed!<span>";
			this.amt_dizziness = 86;
			this.amt_confused = 86;
			this.amt_stuttering = 86;
			this.compatible_mobs = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human), typeof(Mob_Living_Carbon_Monkey) });
			this.hud_state = "wiz_subj";
		}

	}

}