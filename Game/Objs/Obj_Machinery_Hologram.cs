// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Hologram : Obj_Machinery {

		public Obj_Effect_Overlay hologram = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 5;
			this.active_power_usage = 100;
		}

		public Obj_Machinery_Hologram ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: hologram.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.hologram != null ) {
				((dynamic)this).clear_holo();
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: hologram.dm
		public override bool blob_act( dynamic severity = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: hologram.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: hologram.dm
		public override dynamic power_change(  ) {
			
			if ( Lang13.Bool( this.powered() ) ) {
				this.stat &= 65533;
			} else {
				this.stat |= 65533;
			}
			return null;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}