// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Xenocurry : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "sacid", 10 );
			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Xenomeat), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Xenomeat), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Chili), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Curry_Xeno);
		}

	}

}