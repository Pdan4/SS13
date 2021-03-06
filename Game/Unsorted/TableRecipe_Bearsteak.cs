// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Bearsteak : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Filet migrawr";
			this.reqs = new ByTable().Set( typeof(Reagent_Consumable_Ethanol_ManlyDorf), 5 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Steak_Bear), 1 );
			this.tools = new ByTable(new object [] { typeof(Obj_Item_Weapon_Lighter) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bearsteak);
			this.category = "Food";
		}

	}

}