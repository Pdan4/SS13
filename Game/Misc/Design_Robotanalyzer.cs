// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Robotanalyzer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Analyzer";
			this.desc = "A hand-held scanner able to diagnose robotic injuries.";
			this.id = "robotanalyzer";
			this.req_tech = new ByTable().Set( "magnets", 3 ).Set( "engineering", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 8000 ).Set( "$glass", 2000 );
			this.category = "Robotics";
			this.build_path = typeof(Obj_Item_Device_Robotanalyzer);
		}

	}

}