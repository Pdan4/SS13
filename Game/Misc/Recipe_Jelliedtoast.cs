// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Jelliedtoast : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "cherryjelly", 5 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jelliedtoast_Cherry);
		}

	}

}