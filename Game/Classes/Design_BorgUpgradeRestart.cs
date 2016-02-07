// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgUpgradeRestart : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Upgrade (Emergency Reboot Board)";
			this.id = "borg_upgrade_restart";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Restart);
			this.materials = new ByTable().Set( "$metal", 60000 ).Set( "$glass", 5000 );
			this.construction_time = 120;
			this.category = new ByTable(new object [] { "Cyborg Upgrade Modules" });
		}

	}

}