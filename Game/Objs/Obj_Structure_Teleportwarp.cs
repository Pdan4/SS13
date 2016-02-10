// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Teleportwarp : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -64;
			this.pixel_y = -64;
			this.anchored = 1;
			this.icon = "icons/effects/160x160.dmi";
		}

		public Obj_Structure_Teleportwarp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: adminbus.dm
		public override bool singularity_pull( Obj S = null, double? current_size = null, int? radiations = null ) {
			return false;
		}

		// Function from file: adminbus.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			return 0;
		}

		// Function from file: adminbus.dm
		public override bool singuloCanEat(  ) {
			return false;
		}

		// Function from file: adminbus.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: adminbus.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

	}

}