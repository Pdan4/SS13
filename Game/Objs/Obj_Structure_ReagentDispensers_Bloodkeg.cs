// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_ReagentDispensers_Bloodkeg : Obj_Structure_ReagentDispensers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "bloodkeg";
		}

		// Function from file: reagent_dispenser.dm
		public Obj_Structure_ReagentDispensers_Bloodkeg ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "blood", 1000 );
			return;
		}

		// Function from file: reagent_dispenser.dm
		public override dynamic cultify(  ) {
			return null;
		}

	}

}