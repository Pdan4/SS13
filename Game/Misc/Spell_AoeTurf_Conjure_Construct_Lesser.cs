// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_AoeTurf_Conjure_Construct_Lesser : Spell_AoeTurf_Conjure_Construct {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.charge_max = 1800;
			this.summon_type = new ByTable(new object [] { typeof(Obj_Structure_Constructshell_Cult) });
			this.hud_state = "const_shell";
			this.override_base = "const";
		}

	}

}