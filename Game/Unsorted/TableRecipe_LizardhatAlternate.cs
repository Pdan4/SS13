// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_LizardhatAlternate : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lizard Cloche Hat";
			this.result = typeof(Obj_Item_Clothing_Head_Lizard);
			this.time = 10;
			this.reqs = new ByTable().Set( typeof(Obj_Item_Stack_Sheet_Animalhide_Lizard), 1 );
			this.category = "Misc";
		}

	}

}