// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_ExoticGarnishes : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exotic garnishes";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Exotic), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Exotic), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Exotic), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Exotic), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Exotic), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Condiment_Exotic)
			 });
			this.cost = 15;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Secure);
			this.containername = "Exotic garnishes";
			this.access = 28;
			this.group = "Hospitality";
		}

	}

}