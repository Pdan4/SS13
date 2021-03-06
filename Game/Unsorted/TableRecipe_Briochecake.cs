// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Briochecake : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Brioche cake";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Plain), 1 ).Set( typeof(Reagent_Consumable_Sugar), 2 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Brioche);
			this.category = "Food";
		}

	}

}