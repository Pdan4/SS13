// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Butt : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.priority = 1;
			this.blood_level = 1;
		}

		// Function from file: butt.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			return target_zone == "groin" && GlobalFuncs.hasorgans( target ) ?1:0;
		}

	}

}