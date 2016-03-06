// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_StepTrigger_SoundEffect : Obj_Effect_StepTrigger {

		public dynamic sound = null;
		public int? volume = 100;
		public int? freq_vary = 1;
		public int? extra_range = 0;
		public bool happens_once = false;
		public bool triggerer_only = false;

		public Obj_Effect_StepTrigger_SoundEffect ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: step_triggers.dm
		public override bool Trigger( Ent_Dynamic A = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( A );

			if ( !Lang13.Bool( T ) ) {
				return false;
			}

			if ( this.triggerer_only ) {
				A.playsound_local( T, this.sound, this.volume, this.freq_vary );
			} else {
				GlobalFuncs.playsound( T, this.sound, this.volume, this.freq_vary, this.extra_range );
			}

			if ( this.happens_once ) {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

	}

}