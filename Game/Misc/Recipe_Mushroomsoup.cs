// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Mushroomsoup : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "water", 5 ).Set( "milk", 5 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Chanterelle) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Mushroomsoup);
		}

	}

}