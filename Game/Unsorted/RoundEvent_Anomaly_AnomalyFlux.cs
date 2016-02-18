// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Anomaly_AnomalyFlux : RoundEvent_Anomaly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.startWhen = 3;
			this.announceWhen = 20;
			this.endWhen = 80;
		}

		// Function from file: anomaly_flux.dm
		public override void end(  ) {
			
			if ( this.newAnomaly.loc != null ) {
				GlobalFuncs.explosion( this.newAnomaly, 1, 4, 16, 18 );
				GlobalFuncs.qdel( this.newAnomaly );
			}
			return;
		}

		// Function from file: anomaly_flux.dm
		public override bool start(  ) {
			dynamic T = null;

			T = GlobalFuncs.safepick( GlobalFuncs.get_area_turfs( this.impact_area ) );

			if ( Lang13.Bool( T ) ) {
				this.newAnomaly = new Obj_Effect_Anomaly_Flux( T );
			}
			return false;
		}

		// Function from file: anomaly_flux.dm
		public override void announce(  ) {
			GlobalFuncs.priority_announce( "Localized hyper-energetic flux wave detected on long range scanners. Expected location: " + this.impact_area.name + ".", "Anomaly Alert" );
			return;
		}

	}

}