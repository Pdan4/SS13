// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Mineral_Sandstone : Tile_Simulated_Wall_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "sandstone";
			this.mineral = "sandstone";
			this.icon_state = "sandstone0";
		}

		public Tile_Simulated_Wall_Mineral_Sandstone ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}