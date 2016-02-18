// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Slimesoup : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime soup";
			this.reqs = new ByTable().Set( typeof(Reagent_Water), 10 ).Set( typeof(Reagent_Toxin_Slimejelly), 5 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Slime);
			this.category = "Food";
		}

	}

}