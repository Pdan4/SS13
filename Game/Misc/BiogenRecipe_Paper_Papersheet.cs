// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class BiogenRecipe_Paper_Papersheet : BiogenRecipe_Paper {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cost = 15;
			this.id = "papersheet";
			this.name = "Paper Sheet";
			this.other_amounts = new ByTable(new object [] { 5, 10 });
			this.result = typeof(Obj_Item_Weapon_Paper);
		}

	}

}