// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Gloves_Brown : Obj_Item_Clothing_Gloves {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "brown";
			this._color = "brown";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "brown";
		}

		public Obj_Item_Clothing_Gloves_Brown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}