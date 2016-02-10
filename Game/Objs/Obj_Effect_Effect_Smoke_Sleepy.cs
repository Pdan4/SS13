// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Effect_Smoke_Sleepy : Obj_Effect_Effect_Smoke {

		public Obj_Effect_Effect_Smoke_Sleepy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: effect_system.dm
		public override bool affect( Ent_Dynamic M = null ) {
			
			if ( !base.affect( M ) ) {
				return false;
			}
			((dynamic)M).drop_item();
			((dynamic)M).sleeping += 1;

			if ( Lang13.Bool( ((dynamic)M).coughedtime ) != true ) {
				((dynamic)M).coughedtime = 1;
				((dynamic)M).emote( "cough" );
				Task13.Schedule( 20, (Task13.Closure)(() => {
					((dynamic)M).coughedtime = 0;
					return;
				}));
			}
			return false;
		}

		// Function from file: effect_system.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Mob_Living_Carbon M = null;

			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Mob_Living_Carbon) )) {
				M = _a;
				
				this.affect( M );
			}
			return false;
		}

	}

}