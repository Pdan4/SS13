// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Cult : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cult";
			this._color = "cult";
			this.siemens_coefficient = 061;
			this.heat_conductivity = 0.3;
			this.max_heat_protection_temperature = 1500;
			this.icon_state = "cult";
		}

		public Obj_Item_Clothing_Shoes_Cult ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: miscellaneous.dm
		public override dynamic cultify(  ) {
			return null;
		}

	}

}