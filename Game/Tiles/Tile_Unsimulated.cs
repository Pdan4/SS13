// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated : Tile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.oxygen = 21.826091766357422;
			this.nitrogen = 82.1076889038086;
		}

		public Tile_Unsimulated ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: explosion_recursive.dm
		public override void explosion_spread( dynamic power = null, dynamic direction = null ) {
			return;
		}

	}

}