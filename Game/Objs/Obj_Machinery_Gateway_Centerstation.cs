// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Gateway_Centerstation : Obj_Machinery_Gateway {

		public ByTable linked = new ByTable();
		public bool ready = false;
		public double wait = 0;
		public dynamic awaygate = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "offcenter";
		}

		// Function from file: gateway.dm
		public Obj_Machinery_Gateway_Centerstation ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !( GlobalVars.the_gateway != null ) ) {
				GlobalVars.the_gateway = this;
			}
			return;
		}

		// Function from file: gateway.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Device_Multitool ) {
				user.WriteMsg( "ÿ\"The gate is already calibrated, there is no work for you to do here." );
				return null;
			}
			return null;
		}

		// Function from file: gateway.dm
		public override bool Bumped( dynamic AM = null ) {
			dynamic M = null;
			dynamic dest = null;

			
			if ( !this.ready ) {
				return false;
			}

			if ( !this.active ) {
				return false;
			}

			if ( !Lang13.Bool( this.awaygate ) || Lang13.Bool( GlobalFuncs.qdeleted( this.awaygate ) ) ) {
				return false;
			}

			if ( Lang13.Bool( this.awaygate.calibrated ) ) {
				((Ent_Dynamic)AM).forceMove( Map13.GetStep( this.awaygate.loc, ((int)( GlobalVars.SOUTH )) ) );
				AM.dir = GlobalVars.SOUTH;

				if ( AM is Mob ) {
					M = AM;

					if ( Lang13.Bool( M.client ) ) {
						M.client.move_delay = Num13.MaxInt( Game13.time + 5, Convert.ToInt32( M.client.move_delay ) );
					}
				}
				return false;
			} else {
				dest = Rand13.PickFromTable( GlobalVars.awaydestinations );

				if ( Lang13.Bool( dest ) ) {
					((Ent_Dynamic)AM).forceMove( GlobalFuncs.get_turf( dest ) );
					AM.dir = GlobalVars.SOUTH;
					this.f_use_power( 5000 );
				}
				return false;
			}
		}

		// Function from file: gateway.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( !this.ready ) {
				this.detect();
				return null;
			}

			if ( !this.active ) {
				this.toggleon( a );
				return null;
			}
			this.toggleoff();
			return null;
		}

		// Function from file: gateway.dm
		public void toggleoff(  ) {
			Obj_Machinery_Gateway G = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.linked, typeof(Obj_Machinery_Gateway) )) {
				G = _a;
				
				G.active = false;
				G.update_icon();
			}
			this.active = false;
			this.update_icon();
			return;
		}

		// Function from file: gateway.dm
		public void toggleon( dynamic user = null ) {
			Obj_Machinery_Gateway G = null;

			
			if ( !this.ready ) {
				return;
			}

			if ( this.linked.len != 8 ) {
				return;
			}

			if ( !Lang13.Bool( this.powered() ) ) {
				return;
			}

			if ( !Lang13.Bool( this.awaygate ) ) {
				user.WriteMsg( "<span class='notice'>Error: No destination found.</span>" );
				return;
			}

			if ( Game13.time < this.wait ) {
				user.WriteMsg( "<span class='notice'>Error: Warpspace triangulation in progress. Estimated time to completion: " + Num13.Floor( ( this.wait - Game13.time ) / 10 / 60 ) + " minutes.</span>" );
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.linked, typeof(Obj_Machinery_Gateway) )) {
				G = _a;
				
				G.active = true;
				G.update_icon();
			}
			this.active = true;
			this.update_icon();
			return;
		}

		// Function from file: gateway.dm
		public void detect(  ) {
			Ent_Static T = null;
			dynamic i = null;
			dynamic G = null;

			this.linked = new ByTable();
			T = this.loc;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.alldirs )) {
				i = _a;
				
				T = Map13.GetStep( this.loc, Convert.ToInt32( i ) );
				G = Lang13.FindIn( typeof(Obj_Machinery_Gateway), T );

				if ( Lang13.Bool( G ) ) {
					this.linked.Add( G );
					continue;
				}
				this.ready = false;
				this.toggleoff();
				break;
			}

			if ( this.linked.len == 8 ) {
				this.ready = true;
			}
			return;
		}

		// Function from file: gateway.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				
				if ( this.active ) {
					this.toggleoff();
				}
				return null;
			}

			if ( this.active ) {
				this.f_use_power( 5000 );
			}
			return null;
		}

		// Function from file: gateway.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.active ) {
				this.icon_state = "oncenter";
				return false;
			}
			this.icon_state = "offcenter";
			return false;
		}

		// Function from file: gateway.dm
		public override void initialize(  ) {
			this.update_icon();
			this.wait = Game13.time + ( GlobalVars.config.gateway_delay ??0);
			this.awaygate = Lang13.FindObj( typeof(Obj_Machinery_Gateway_Centeraway) );
			return;
		}

		// Function from file: gateway.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.the_gateway == this ) {
				GlobalVars.the_gateway = null;
			}
			base.Destroy();
			return null;
		}

		// Function from file: observer.dm
		public override void attack_ghost( Mob user = null ) {
			
			if ( Lang13.Bool( this.awaygate ) ) {
				user.loc = this.awaygate.loc;
			} else {
				user.WriteMsg( "" + this + " has no destination." );
			}
			return;
		}

	}

}