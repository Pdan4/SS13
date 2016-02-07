// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_PlaceCyborgTransformer : AIModule_Large {

		public ByTable turfOverlays = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Robotic Factory (Removes Shunting)";
			this.mod_pick_name = "cyborgtransformer";
			this.description = "Build a machine anywhere, using expensive nanomachines, that can convert a living human into a loyal cyborg slave when placed inside.";
			this.cost = 100;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "place_transformer" );
		}

		// Function from file: Malf_Modules.dm
		public AIModule_Large_PlaceCyborgTransformer (  ) {
			int? i = null;
			Image I = null;

			i = null;
			i = 0;

			while (( i ??0) < 3) {
				I = new Image( "icons/turf/overlays.dmi" );
				this.turfOverlays.Add( I );
				i++;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}