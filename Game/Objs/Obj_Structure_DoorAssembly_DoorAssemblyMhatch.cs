// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyMhatch : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlays_file = "icons/obj/doors/airlocks/hatch/overlays.dmi";
			this.typetext = "maintenance_hatch";
			this.icontext = "mhatch";
			this.airlock_type = typeof(Obj_Machinery_Door_Airlock_MaintenanceHatch);
			this.anchored = 1;
			this.state = 1;
			this.icon = "icons/obj/doors/airlocks/hatch/maintenance.dmi";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyMhatch ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}