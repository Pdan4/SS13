// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SmeltingRecipe_Cardboard : SmeltingRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cardboard";
			this.ingredients = new ByTable().Set( "$cardboard", 1 );
			this.yieldtype = typeof(Obj_Item_Stack_Sheet_Cardboard);
		}

	}

}