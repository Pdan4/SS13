// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_Cell_Bluespace : Obj_Item_Weapon_StockParts_Cell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "powerstorage=7";
			this.maxcharge = 40000;
			this.materials = new ByTable().Set( "$glass", 80 );
			this.rating = 6;
			this.chargerate = 4000;
			this.icon_state = "bscell";
		}

		public Obj_Item_Weapon_StockParts_Cell_Bluespace ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}