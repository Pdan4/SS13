// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgUpgradeDisablercooler : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Upgrade (Rapid Disabler Cooling Module)";
			this.id = "borg_upgrade_disablercooler";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Disablercooler);
			this.req_tech = new ByTable().Set( "combat", 5 ).Set( "powerstorage", 4 );
			this.materials = new ByTable().Set( "$metal", 80000 ).Set( "$glass", 6000 ).Set( "$gold", 2000 ).Set( "$diamond", 500 );
			this.construction_time = 120;
			this.category = new ByTable(new object [] { "Cyborg Upgrade Modules" });
		}

	}

}