// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Gigapuddi_Happy : Recipe_Gigapuddi {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "milk", 15 ).Set( "sugar", 5 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Gigapuddi_Happy);
		}

	}

}