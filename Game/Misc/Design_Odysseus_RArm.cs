// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Odysseus_RArm : Design_Odysseus {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (Odysseus right arm)";
			this.desc = "Used to build a Odysseus right arm.";
			this.id = "odysseus_rarm";
			this.req_tech = new ByTable().Set( "biotech", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_OdysseusRightArm);
			this.category = "Odysseus";
			this.materials = new ByTable().Set( "$iron", 10000 );
		}

	}

}