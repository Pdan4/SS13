// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechSyringeGun : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Module Design (Syringe Gun)";
			this.desc = "Exosuit-mounted syringe gun and chemical synthesizer.";
			this.id = "mech_syringe_gun";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "materials", 3 ).Set( "biotech", 4 ).Set( "magnets", 4 ).Set( "programming", 3 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Tool_SyringeGun);
			this.category = "Exosuit_Tools";
			this.materials = new ByTable().Set( "$iron", 3000 ).Set( "$glass", 2000 );
		}

	}

}