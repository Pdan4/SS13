// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechSyringeGun : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Medical Equipment (Syringe Gun)";
			this.desc = "Equipment for medical exosuits. A chem synthesizer with syringe gun. Reagents inside are held in stasis, so no reactions will occur.";
			this.id = "mech_syringe_gun";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "magnets", 3 ).Set( "biotech", 3 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_SyringeGun);
			this.materials = new ByTable().Set( "$metal", 3000 ).Set( "$glass", 2000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}