// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Plating_Deck : Tile_Simulated_Floor_Plating {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_plating = "deck";
		}

		// Function from file: floor_types.dm
		public Tile_Simulated_Floor_Plating_Deck ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "deck";
			return;
		}

		// Function from file: floor_types.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_plating = "deck";
			base.update_icon( (object)(location), (object)(target) );

			if ( !( this.floor_tile != null ) ) {
				this.name = "deck";
				this.icon_state = "deck";
				this.desc = "Children love to play on this deck.";
			} else {
				this.name = "floor";
				this.desc = null;
			}
			return null;
		}

	}

}