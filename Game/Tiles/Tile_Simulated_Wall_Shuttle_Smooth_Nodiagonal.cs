// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Shuttle_Smooth_Nodiagonal : Tile_Simulated_Wall_Shuttle_Smooth {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.smooth = 2;
			this.icon_state = "shuttle_nd";
		}

		public Tile_Simulated_Wall_Shuttle_Smooth_Nodiagonal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}