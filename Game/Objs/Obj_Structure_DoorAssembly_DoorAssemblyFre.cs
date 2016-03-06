// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyFre : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.typetext = "freezer";
			this.icontext = "fre";
			this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Freezer);
			this.anchored = 1;
			this.state = 1;
			this.icon = "icons/obj/doors/airlocks/station/freezer.dmi";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyFre ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}