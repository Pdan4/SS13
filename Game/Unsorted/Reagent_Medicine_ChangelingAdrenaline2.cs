// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_ChangelingAdrenaline2 : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Adrenaline";
			this.id = "changelingAdrenaline2";
			this.description = "Drastically increases movement speed.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 1;
		}

		// Function from file: adrenaline.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.status_flags |= 64;
			((Mob_Living)M).adjustToxLoss( 2 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}