// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechGeneratorPlasma : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Module Design (Plasma Generator)";
			this.desc = "A power generator that runs on burning plasma.";
			this.id = "mech_generator_plasma";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "engineering", 1 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Generator);
			this.category = "Exosuit_Tools";
			this.materials = new ByTable().Set( "$iron", 10000 ).Set( "$silver", 500 ).Set( "$glass", 1000 );
		}

	}

}