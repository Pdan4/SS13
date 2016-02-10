// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Crystal : Obj_Machinery {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/mining.dmi";
			this.icon_state = "crystal";
		}

		// Function from file: finds_misc.dm
		public Obj_Machinery_Crystal ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( Rand13.PercentChance( 50 ) ) {
				this.icon_state = "crystal2";
			}
			return;
		}

	}

}