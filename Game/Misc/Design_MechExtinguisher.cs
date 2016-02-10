// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechExtinguisher : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Module Design (Foam Extinguisher)";
			this.desc = "A foam extinguisher module for firefighting mechs.";
			this.id = "mech_extinguisher";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "materials", 1 ).Set( "engineering", 2 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Tool_Extinguisher);
			this.category = "Exosuit_Tools";
			this.materials = new ByTable().Set( "$iron", 10000 );
		}

	}

}