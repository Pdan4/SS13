// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_PrisonBreak : RoundEvent {

		public ByTable prisonAreas = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 50;
			this.endWhen = 20;
		}

		// Function from file: tgstation.dme
		public override void end(  ) {
			dynamic A = null;
			Obj O = null;
			Obj temp = null;
			Obj temp2 = null;
			Obj temp3 = null;
			Obj temp4 = null;
			Obj temp5 = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.prisonAreas )) {
				A = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( A, typeof(Obj) )) {
					O = _a;
					

					if ( O is Obj_Machinery_Power_Apc ) {
						temp = O;
						((Obj_Machinery_Power_Apc)temp).overload_lighting();
					} else if ( O is Obj_Structure_Closet_SecureCloset_Brig ) {
						temp2 = O;
						((dynamic)temp2).locked = 0;
						temp2.update_icon();
					} else if ( O is Obj_Machinery_Door_Airlock_Security ) {
						temp3 = O;
						((Obj_Machinery_Door_Airlock)temp3).prison_open();
					} else if ( O is Obj_Machinery_Door_Airlock_GlassSecurity ) {
						temp4 = O;
						((Obj_Machinery_Door_Airlock)temp4).prison_open();
					} else if ( O is Obj_Machinery_DoorTimer ) {
						temp5 = O;
						((Obj_Machinery_DoorTimer)temp5).timer_end( GlobalVars.TRUE );
					}
				}
			}
			return;
		}

		// Function from file: prison_break.dm
		public override bool start(  ) {
			dynamic A = null;
			Obj_Machinery_Light L = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.prisonAreas )) {
				A = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( A, typeof(Obj_Machinery_Light) )) {
					L = _a;
					
					L.flicker( 10 );
				}
			}
			return false;
		}

		// Function from file: prison_break.dm
		public override void announce(  ) {
			
			if ( this.prisonAreas != null && this.prisonAreas.len > 0 ) {
				GlobalFuncs.priority_announce( "Gr3y.T1d3 virus detected in " + GlobalFuncs.station_name() + " imprisonment subroutines. Recommend station AI involvement.", "Security Alert" );
			} else {
				Game13.log.WriteMsg( "ERROR: Could not initate grey-tide. Unable find prison or brig area." );
				this.kill();
			}
			return;
		}

		// Function from file: prison_break.dm
		public override void setup( int? loop = null ) {
			Zone_Security A = null;

			this.announceWhen = Rand13.Int( 50, 60 );
			this.endWhen = Rand13.Int( 20, 30 );

			foreach (dynamic _a in Lang13.Enumerate( typeof(Game13), typeof(Zone_Security) )) {
				A = _a;
				

				if ( A is Zone_Security_Prison || A is Zone_Security_Brig ) {
					this.prisonAreas.Add( A );
				}
			}
			return;
		}

	}

}