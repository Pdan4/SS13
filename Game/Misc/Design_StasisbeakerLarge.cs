// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_StasisbeakerLarge : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Large Stasis Beaker";
			this.desc = "A beaker powered by experimental bluespace technology. Chemicals are held in stasis and do not react inside of it. Can hold up to 100 units.";
			this.id = "stasisbeaker_large";
			this.req_tech = new ByTable().Set( "bluespace", 4 ).Set( "materials", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$diamond", 1500 ).Set( "$iron", 3750 ).Set( "$glass", 3750 ).Set( "$uranium", 1500 );
			this.category = "Bluespace";
			this.build_path = typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Noreact_Large);
		}

	}

}