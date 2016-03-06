// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_CTransitTube_Station : Obj_Structure_CTransitTube {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/atmospherics/pipes/transit_tube_station.dmi";
			this.icon_state = "closed";
		}

		public Obj_Structure_CTransitTube_Station ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: transit_tube_construction.dm
		public override Obj_Structure_TransitTube buildtube(  ) {
			Obj_Structure_TransitTube_Station R = null;

			R = new Obj_Structure_TransitTube_Station( this.loc );
			R.dir = this.dir;
			R.init_dirs();
			return R;
		}

		// Function from file: transit_tube_construction.dm
		public override void tube_flip(  ) {
			this.tube_turn( 180 );
			return;
		}

		// Function from file: transit_tube_construction.dm
		public override void tube_turn( double angle = 0 ) {
			this.dir = Num13.Rotate( this.dir, angle );
			return;
		}

	}

}