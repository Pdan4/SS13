// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_AoeTurf_Knock_Harvester : Spell_AoeTurf_Knock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Disintegrate Doors";
			this.desc = "No door shall stop you.";
			this.spell_flags = 256;
			this.invocation = "";
			this.invocation_type = "silent";
			this.range = 5;
			this.hud_state = "const_knock";
		}

		// Function from file: vgstation13.dme
		public override bool cast( ByTable targets = null, Mob user = null ) {
			dynamic T = null;
			Obj_Machinery_Door door = null;

			
			foreach (dynamic _b in Lang13.Enumerate( targets )) {
				T = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( T.contents, typeof(Obj_Machinery_Door) )) {
					door = _a;
					
					Task13.Schedule( 0, (Task13.Closure)(() => {
						door.cultify();
						return;
					}));
				}
			}
			return false;
		}

	}

}