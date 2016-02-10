// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_PrisonBreak : Event {

		public int releaseWhen = 25;
		public ByTable prisonAreas = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 30;
			this.oneShot = true;
		}

		public Event_PrisonBreak ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: prison_break.dm
		public override void tick(  ) {
			dynamic A = null;
			Obj_Machinery_Power_Apc temp_apc = null;
			Obj_Structure_Closet_SecureCloset_Brig temp_closet = null;
			Obj_Machinery_Door_Airlock_Security temp_airlock = null;
			Obj_Machinery_Door_Airlock_GlassSecurity temp_glassairlock = null;
			Obj_Machinery_DoorTimer temp_timer = null;

			
			if ( this.activeFor == this.releaseWhen ) {
				
				if ( this.prisonAreas != null && this.prisonAreas.len > 0 ) {
					
					foreach (dynamic _f in Lang13.Enumerate( this.prisonAreas )) {
						A = _f;
						

						foreach (dynamic _a in Lang13.Enumerate( A, typeof(Obj_Machinery_Power_Apc) )) {
							temp_apc = _a;
							
							temp_apc.overload_lighting();
						}

						foreach (dynamic _b in Lang13.Enumerate( A, typeof(Obj_Structure_Closet_SecureCloset_Brig) )) {
							temp_closet = _b;
							
							temp_closet.locked = false;
							temp_closet.icon_state = temp_closet.icon_closed;
						}

						foreach (dynamic _c in Lang13.Enumerate( A, typeof(Obj_Machinery_Door_Airlock_Security) )) {
							temp_airlock = _c;
							
							temp_airlock.prison_open();
						}

						foreach (dynamic _d in Lang13.Enumerate( A, typeof(Obj_Machinery_Door_Airlock_GlassSecurity) )) {
							temp_glassairlock = _d;
							
							temp_glassairlock.prison_open();
						}

						foreach (dynamic _e in Lang13.Enumerate( A, typeof(Obj_Machinery_DoorTimer) )) {
							temp_timer = _e;
							
							temp_timer.releasetime = 1;
						}
					}
				}
			}
			return;
		}

		// Function from file: prison_break.dm
		public override bool start(  ) {
			dynamic A = null;
			dynamic A2 = null;
			Obj_Machinery_Light L = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.areas )) {
				A = _a;
				

				if ( A is Zone_Security_Prison || A is Zone_Security_Brig ) {
					this.prisonAreas.Add( A );
				}
			}

			if ( this.prisonAreas != null && this.prisonAreas.len > 0 ) {
				
				foreach (dynamic _c in Lang13.Enumerate( this.prisonAreas )) {
					A2 = _c;
					

					foreach (dynamic _b in Lang13.Enumerate( A2, typeof(Obj_Machinery_Light) )) {
						L = _b;
						
						L.flicker( 10 );
					}
				}
			}
			return false;
		}

		// Function from file: prison_break.dm
		public override void announce(  ) {
			
			if ( this.prisonAreas != null && this.prisonAreas.len > 0 ) {
				GlobalFuncs.command_alert( "" + Rand13.Pick(new object [] { "Gr3y.T1d3 virus", "Malignant trojan" }) + " detected in " + GlobalFuncs.station_name() + " imprisonment subroutines. Recommend station AI involvement.", "Security Alert" );
			} else {
				Game13.log.WriteMsg( "ERROR: Could not initate grey-tide. Unable find prison or brig area." );
				this.kill();
			}
			return;
		}

		// Function from file: prison_break.dm
		public override void setup(  ) {
			this.announceWhen = Rand13.Int( 50, 60 );
			this.releaseWhen = Rand13.Int( 20, 30 );
			this.startWhen = this.releaseWhen - 1;
			this.endWhen = this.releaseWhen + 1;
			return;
		}

	}

}