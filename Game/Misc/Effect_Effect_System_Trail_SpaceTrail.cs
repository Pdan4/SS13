// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Effect_Effect_System_Trail_SpaceTrail : Effect_Effect_System_Trail {

		public Tile oldloc = null;
		public dynamic currloc = null;

		// Function from file: effect_system.dm
		public override void start(  ) {
			dynamic T = null;
			Game_Data I = null;
			Game_Data II = null;

			
			if ( !this.on ) {
				this.on = true;
				this.processing = true;
			}

			if ( this.processing ) {
				this.processing = false;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					T = GlobalFuncs.get_turf( this.holder );

					if ( this.currloc != T ) {
						
						dynamic _a = this.holder.dir; // Was a switch-case, sorry for the mess.
						if ( _a==1 ) {
							this.oldposition = T;
							this.oldposition = Map13.GetStep( this.oldposition, ((int)( GlobalVars.SOUTH )) );
							this.oldloc = Map13.GetStep( this.oldposition, ((int)( GlobalVars.EAST )) );
						} else if ( _a==2 ) {
							this.oldposition = Map13.GetStep( this.holder, ((int)( GlobalVars.NORTH )) );
							this.oldposition = Map13.GetStep( this.oldposition, ((int)( GlobalVars.NORTH )) );
							this.oldloc = Map13.GetStep( this.oldposition, ((int)( GlobalVars.EAST )) );
						} else if ( _a==4 ) {
							this.oldposition = T;
							this.oldposition = Map13.GetStep( this.oldposition, ((int)( GlobalVars.WEST )) );
							this.oldloc = Map13.GetStep( this.oldposition, ((int)( GlobalVars.NORTH )) );
						} else if ( _a==8 ) {
							this.oldposition = Map13.GetStep( this.holder, ((int)( GlobalVars.EAST )) );
							this.oldposition = Map13.GetStep( this.oldposition, ((int)( GlobalVars.EAST )) );
							this.oldloc = Map13.GetStep( this.oldposition, ((int)( GlobalVars.NORTH )) );
						}

						if ( T is Tile_Space ) {
							I = GlobalFuncs.getFromPool( typeof(Obj_Effect_Effect_Trails_Ion), this.oldposition );
							II = GlobalFuncs.getFromPool( typeof(Obj_Effect_Effect_Trails_Ion), this.oldloc );
							((dynamic)I).dir = this.holder.dir;
							((dynamic)II).dir = this.holder.dir;
							Icon13.Flick( "ion_fade", I );
							Icon13.Flick( "ion_fade", II );
							((dynamic)I).icon_state = "blank";
							((dynamic)II).icon_state = "blank";
							Task13.Schedule( 20, (Task13.Closure)(() => {
								
								if ( I != null ) {
									GlobalFuncs.returnToPool( I );
								}

								if ( II != null ) {
									GlobalFuncs.returnToPool( II );
								}
								return;
							}));
						}
					}
					Task13.Schedule( 2, (Task13.Closure)(() => {
						
						if ( this.on ) {
							this.processing = true;
							this.start();
						}
						return;
					}));
					this.currloc = T;
					return;
				}));
			}
			return;
		}

	}

}