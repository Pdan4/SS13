// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SmeltingRecipe_Silver : SmeltingRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Silver";
			this.ingredients = new ByTable().Set( "$silver", 1 );
			this.yieldtype = typeof(Obj_Item_Stack_Sheet_Mineral_Silver);
		}

	}

}