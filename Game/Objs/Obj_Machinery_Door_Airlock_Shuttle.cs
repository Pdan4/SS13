// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Shuttle : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlays_file = "icons/obj/doors/airlocks/shuttle/overlays.dmi";
			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyShuttle);
			this.icon = "icons/obj/doors/airlocks/shuttle/shuttle.dmi";
		}

		public Obj_Machinery_Door_Airlock_Shuttle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}