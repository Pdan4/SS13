// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Robot : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random = true;
			this.holder_type = typeof(Mob_Living_Silicon_Robot);
			this.wire_count = 5;
		}

		public Wires_Robot ( Obj holder = null ) : base( holder ) {
			
		}

		// Function from file: robot.dm
		public virtual int AIHasControl(  ) {
			return this.wires_status & 8;
		}

		// Function from file: robot.dm
		public virtual int CanLawCheck(  ) {
			return this.wires_status & 16;
		}

		// Function from file: robot.dm
		public int LockedCut(  ) {
			return this.wires_status & 2;
		}

		// Function from file: robot.dm
		public int IsCameraCut(  ) {
			return this.wires_status & 4;
		}

		// Function from file: robot.dm
		public override bool CanUse( dynamic L = null ) {
			Obj R = null;

			R = this.holder;

			if ( Lang13.Bool( ((dynamic)R).wiresexposed ) ) {
				return true;
			}
			return false;
		}

		// Function from file: robot.dm
		public override void UpdatePulsed( double? index = null ) {
			Ent_Static R = null;

			R = this.holder;

			switch ((double?)( index )) {
				case 8:
					
					if ( !Lang13.Bool( ((dynamic)R).emagged ) && !( R is Mob_Living_Silicon_Robot_Mommi ) ) {
						((dynamic)R).connected_ai = GlobalFuncs.select_active_ai();
					}
					break;
				case 4:
					
					if ( !( ((dynamic)R).camera == null ) && Lang13.Bool( ((dynamic)R).camera.can_use() ) && !Lang13.Bool( ((dynamic)R).scrambledcodes ) ) {
						((dynamic)R).camera.deactivate( Task13.User, 0 );
						R.visible_message( "" + R + "'s camera lense focuses loudly." );
						GlobalFuncs.to_chat( R, "Your camera lense focuses loudly." );
					}
					break;
				case 2:
					((dynamic)R).SetLockdown( !Lang13.Bool( ((dynamic)R).lockcharge ) );
					break;
			}
			return;
		}

		// Function from file: robot.dm
		public override void UpdateCut( double? index = null, bool mended = false ) {
			Ent_Static R = null;

			R = this.holder;

			switch ((double?)( index )) {
				case 16:
					
					if ( !mended ) {
						
						if ( Lang13.Bool( ((dynamic)R).lawupdate ) == true ) {
							GlobalFuncs.to_chat( R, "LawSync protocol engaged." );
							((dynamic)R).show_laws();
						}
					} else if ( Lang13.Bool( ((dynamic)R).lawupdate ) == false && !Lang13.Bool( ((dynamic)R).emagged ) ) {
						((dynamic)R).lawupdate = 1;
					}
					break;
				case 8:
					
					if ( !mended ) {
						
						if ( Lang13.Bool( ((dynamic)R).connected_ai ) ) {
							((dynamic)R).connected_ai = null;
						}
					}
					break;
				case 4:
					
					if ( !( ((dynamic)R).camera == null ) && !Lang13.Bool( ((dynamic)R).scrambledcodes ) ) {
						((dynamic)R).camera.status = mended;
						((dynamic)R).camera.deactivate( Task13.User, 0 );
					}
					break;
				case 16:
					
					if ( Lang13.Bool( ((dynamic)R).lawupdate ) ) {
						((dynamic)R).lawsync();
					}
					break;
				case 2:
					((dynamic)R).SetLockdown( !mended );
					break;
			}
			return;
		}

		// Function from file: robot.dm
		public override string GetInteractWindow(  ) {
			string _default = null;

			Ent_Static R = null;

			_default = base.GetInteractWindow();
			R = this.holder;

			if ( !( this is Wires_Robot_Mommi ) ) {
				_default += "<br>\n" + ( Lang13.Bool( ((dynamic)R).lawupdate ) ? "The LawSync light is on." : "The LawSync light is off." ) + "<br>\n" + ( Lang13.Bool( ((dynamic)R).connected_ai ) ? "The AI link light is on." : "The AI link light is off." );
			}
			_default += "<br>\n" + ( !( ((dynamic)R).camera == null ) && Lang13.Bool( ((dynamic)R).camera.status ) == true ? "The Camera light is on." : "The Camera light is off." ) + "<br>\n";
			_default += "<br>\n" + ( Lang13.Bool( ((dynamic)R).lockcharge ) ? "The lockdown light is on." : "The lockdown light is off." );
			return _default;
		}

	}

}