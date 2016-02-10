// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ProcessingUnit_Recycling : Design_ProcessingUnit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (Recycling Furnace)";
			this.desc = "Allows for the construction of circuit boards used to build a recycling furnace.";
			this.id = "smelter_recycling";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_ProcessingUnit_Recycling);
		}

	}

}