// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Grille_Broken : Obj_Structure_Grille {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.broken = true;
			this.icon_state = "grille-b";
		}

		// Function from file: grille.dm
		public Obj_Structure_Grille_Broken ( dynamic loc = null ) : base( (object)(loc) ) {
			this.health -= Rand13.Int( Convert.ToInt32( Lang13.Initial( this, "health" ) * 0.8 ), Convert.ToInt32( Lang13.Initial( this, "health" ) * 081 ) );
			this.healthcheck();
			return;
		}

	}

}