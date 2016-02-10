// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_PlaceCyborgTransformer : AIModule_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Robotic Factory (Removes Shunting)";
			this.mod_pick_name = "cyborgtransformer";
			this.description = "Build a machine anywhere, using expensive nanomachines, that can convert a living human into a loyal cyborg slave when placed inside.";
			this.cost = 100;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "place_transformer" );
		}

	}

}