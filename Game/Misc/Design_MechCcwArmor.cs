// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechCcwArmor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Module Design (Melee Armor Booster Module)";
			this.desc = "Exosuit-mounted armor booster.";
			this.id = "mech_ccw_armor";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "materials", 5 ).Set( "combat", 4 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_AnticcwArmorBooster);
			this.category = "Exosuit_Modules";
			this.materials = new ByTable().Set( "$iron", 20000 ).Set( "$silver", 5000 );
		}

	}

}