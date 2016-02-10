// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Gloves_Fyellow : Obj_Item_Clothing_Gloves {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "yellow";
			this.permeability_coefficient = 0.05;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this._color = "yellow";
			this.icon_state = "yellow";
		}

		// Function from file: color.dm
		public Obj_Item_Clothing_Gloves_Fyellow ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.siemens_coefficient = Rand13.Pick(new object [] { 0, 0.5, 0.5, 0.5, 0.5, 0.75, 1.5 });
			return;
		}

	}

}