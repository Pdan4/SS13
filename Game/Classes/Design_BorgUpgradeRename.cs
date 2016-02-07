// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgUpgradeRename : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Upgrade (Rename Board)";
			this.id = "borg_upgrade_rename";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Rename);
			this.materials = new ByTable().Set( "$metal", 35000 );
			this.construction_time = 120;
			this.category = new ByTable(new object [] { "Cyborg Upgrade Modules" });
		}

	}

}