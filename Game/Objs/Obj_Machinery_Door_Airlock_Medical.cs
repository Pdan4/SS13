// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Medical : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.assembly_type = typeof(Obj_Structure_DoorAssembly_DoorAssemblyMed);
			this.icon = "icons/obj/doors/doormed.dmi";
		}

		public Obj_Machinery_Door_Airlock_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}