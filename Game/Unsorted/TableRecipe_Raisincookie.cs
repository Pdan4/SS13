// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Raisincookie : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Raisin cookie";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_NoRaisin), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pastrybase), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Oat), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Raisincookie);
			this.category = "Food";
		}

	}

}