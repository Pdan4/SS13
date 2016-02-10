// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Robot_LArm : Design_Robot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Component (Robot left arm)";
			this.desc = "Used to build a Robot left arm.";
			this.id = "robot_larm";
			this.req_tech = new ByTable().Set( "engineering", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_RobotParts_LArm);
			this.category = "Robot";
			this.materials = new ByTable().Set( "$iron", 18000 );
		}

	}

}