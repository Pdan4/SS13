// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_CommunicationsBlackout : RoundEvent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 1;
		}

		// Function from file: communications_blackout.dm
		public override bool start(  ) {
			Obj_Machinery_Telecomms T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.telecomms_list, typeof(Obj_Machinery_Telecomms) )) {
				T = _a;
				
				T.emp_act( 1 );
			}
			return false;
		}

		// Function from file: communications_blackout.dm
		public override void announce(  ) {
			string alert = null;
			Mob_Living_Silicon_Ai A = null;

			alert = Rand13.Pick(new object [] { "Ionospheric anomalies detected. Temporary telecommunication failure imminent. Please contact you*%fj00)`5vc-BZZT", "Ionospheric anomalies detected. Temporary telecommunication failu*3mga;b4;'1v¬-BZZZT", "Ionospheric anomalies detected. Temporary telec#MCi46:5.;@63-BZZZZT", "Ionospheric anomalies dete'fZ\\kg5_0-BZZZZZT", "Ionospheri:%£ MCayj^j<.3-BZZZZZZT", "#4nd%;f4y6,>£%-BZZZZZZZT" });

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
				A = _a;
				
				A.WriteMsg( "<br>" );
				A.WriteMsg( "<span class='warning'><b>" + alert + "</b></span>" );
				A.WriteMsg( "<br>" );
			}

			if ( Rand13.PercentChance( 30 ) ) {
				GlobalFuncs.priority_announce( alert );
			}
			return;
		}

	}

}