// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Phazon_LArm : Design_Phazon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (Phazon left arm)";
			this.desc = "Used to build a Phazon left arm.";
			this.id = "phazon_larm";
			this.req_tech = new ByTable().Set( "bluespace", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_PhazonLeftArm);
			this.category = "Phazon";
			this.materials = new ByTable().Set( "$iron", 20000 ).Set( "$plasma", 10000 ).Set( "$phazon", 2500 );
		}

	}

}