// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Brainburger : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "flour", 5 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Organ_Brain) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Brainburger);
		}

	}

}