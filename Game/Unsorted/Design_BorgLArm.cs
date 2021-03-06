// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgLArm : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Left Arm";
			this.id = "borg_l_arm";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_RobotParts_LArm);
			this.materials = new ByTable().Set( "$metal", 10000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Cyborg" });
		}

	}

}