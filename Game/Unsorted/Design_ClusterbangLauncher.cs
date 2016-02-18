// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ClusterbangLauncher : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Module (SOB-3 Clusterbang Launcher)";
			this.desc = "A weapon that violates the Geneva Convention at 3 rounds per minute";
			this.id = "clusterbang_launcher";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "combat", 5 ).Set( "materials", 5 ).Set( "syndicate", 3 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang_Clusterbang);
			this.materials = new ByTable().Set( "$metal", 20000 ).Set( "$gold", 10000 ).Set( "$uranium", 10000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}