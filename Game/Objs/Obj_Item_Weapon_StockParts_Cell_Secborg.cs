// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_Cell_Secborg : Obj_Item_Weapon_StockParts_Cell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.maxcharge = 600;
			this.materials = new ByTable().Set( "$glass", 40 );
			this.rating = 2.5;
		}

		public Obj_Item_Weapon_StockParts_Cell_Secborg ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}