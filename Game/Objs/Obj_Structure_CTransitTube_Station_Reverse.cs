// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_CTransitTube_Station_Reverse : Obj_Structure_CTransitTube_Station {

		public Obj_Structure_CTransitTube_Station_Reverse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: transit_tube_construction.dm
		public override Obj_Structure_TransitTube buildtube(  ) {
			Obj_Structure_TransitTube_Station_Reverse R = null;

			R = new Obj_Structure_TransitTube_Station_Reverse( this.loc );
			R.dir = this.dir;
			R.init_dirs();
			return R;
		}

	}

}