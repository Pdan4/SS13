// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Summoning : Obj_Effect {

		public Obj_Effect_Rune summon_target = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 0;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "summoning";
		}

		// Function from file: runes.dm
		public Obj_Effect_Summoning ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 10, (Task13.Closure)(() => {
				this.update();
				return;
			}));
			return;
		}

		// Function from file: runes.dm
		public void init( Obj_Effect_Rune S = null ) {
			this.summon_target = S;
			return;
		}

		// Function from file: runes.dm
		public void update(  ) {
			
			if ( this.summon_target != null && Lang13.Bool( Lang13.FindIn( GlobalFuncs.get_turf( this ), this.summon_target.summonturfs ) ) ) {
				Task13.Sleep( 10 );
				this.update();
				return;
			} else {
				GlobalFuncs.qdel( this );
			}
			return;
		}

	}

}