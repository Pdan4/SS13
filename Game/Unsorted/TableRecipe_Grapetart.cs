// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Grapetart : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Grape tart";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Milk), 5 )
				.Set( typeof(Reagent_Consumable_Sugar), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Plain), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Grapes), 3 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Grapetart);
			this.category = "Food";
		}

	}

}