// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Mineral_Input : Obj_Machinery_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/mob/screen1.dmi";
			this.icon_state = "x2";
		}

		// Function from file: machine_input_output_plates.dm
		public Obj_Machinery_Mineral_Input ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "blank";
			return;
		}

	}

}