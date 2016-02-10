// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Effect_Smoke_Bad : Obj_Effect_Effect_Smoke {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.time_to_live = 200;
		}

		public Obj_Effect_Effect_Smoke_Bad ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: effect_system.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			dynamic B = null;

			
			if ( air_group == true || height == 0 ) {
				return true;
			}

			if ( mover is Obj_Item_Projectile_Beam ) {
				B = mover;
				B.damage = B.damage / 2;
			}
			return true;
		}

		// Function from file: effect_system.dm
		public override bool affect( Ent_Dynamic M = null ) {
			
			if ( !base.affect( M ) ) {
				return false;
			}
			((dynamic)M).drop_item();
			((dynamic)M).adjustOxyLoss( 1 );

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