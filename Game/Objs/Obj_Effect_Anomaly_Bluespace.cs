// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Anomaly_Bluespace : Obj_Effect_Anomaly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/projectiles.dmi";
			this.icon_state = "bluespace";
		}

		// Function from file: anomalies.dm
		public Obj_Effect_Anomaly_Bluespace ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.aSignal.origin_tech = "bluespace=5;magnets=5;powerstorage=3";
			return;
		}

		// Function from file: anomalies.dm
		public override bool Bumped( dynamic AM = null ) {
			
			if ( AM is Mob_Living ) {
				GlobalFuncs.do_teleport( AM, Map13.GetTile( Convert.ToInt32( AM.x ), Convert.ToInt32( AM.y ), Convert.ToInt32( AM.z ) ), 8 );
			}
			return false;
		}

		// Function from file: anomalies.dm
		public override void anomalyEffect(  ) {
			Mob_Living M = null;

			base.anomalyEffect();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 1 ), typeof(Mob_Living) )) {
				M = _a;
				
				GlobalFuncs.do_teleport( M, Map13.GetTile( M.x, M.y, M.z ), 4 );
			}
			return;
		}

	}

}