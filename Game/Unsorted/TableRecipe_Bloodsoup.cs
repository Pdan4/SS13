// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Bloodsoup : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blood soup";
			this.reqs = new ByTable().Set( typeof(Reagent_Blood), 10 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato_Blood), 2 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Blood);
			this.category = "Food";
		}

	}

}