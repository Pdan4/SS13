// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Effect_Effect_System_Trail : Effect_Effect_System {

		public dynamic oldposition = null;
		public bool processing = true;
		public bool on = true;
		public Type trail_type = typeof(Obj_Effect_Effect_Trails_Ion);

		// Function from file: effect_system.dm
		public void stop(  ) {
			this.processing = false;
			this.on = false;
			return;
		}

		// Function from file: effect_system.dm
		public override void start(  ) {
			dynamic T = null;
			Game_Data I = null;

			
			if ( !this.on ) {
				this.on = true;
				this.processing = true;
			}

			if ( this.processing ) {
				this.processing = false;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					T = GlobalFuncs.get_turf( this.holder );

					if ( T != this.oldposition ) {
						
						if ( T is Tile_Space ) {
							I = GlobalFuncs.getFromPool( this.trail_type, this.oldposition );
							this.oldposition = T;
							((dynamic)I).dir = this.holder.dir;
							((Obj_Effect_Effect_Trails)I).Play();
						}
					}
					Task13.Schedule( 2, (Task13.Closure)(() => {
						
						if ( this.on ) {
							this.processing = true;
							this.start();
						}
						return;
					}));
					return;
				}));
			}
			return;
		}

		// Function from file: effect_system.dm
		public override void set_up( dynamic carry = null, dynamic n = null, dynamic c = null, dynamic loca = null, dynamic direct = null ) {
			this.attach( carry );
			this.oldposition = GlobalFuncs.get_turf( carry );
			return;
		}

	}

}