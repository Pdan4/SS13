// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SuitStorageUnit_MeteorEod : Obj_Machinery_SuitStorageUnit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.SUIT_TYPE = typeof(Obj_Item_Clothing_Suit_BombSuit);
			this.HELMET_TYPE = typeof(Obj_Item_Clothing_Head_BombHood);
			this.MASK_TYPE = typeof(Obj_Item_Clothing_Mask_Gas);
			this.BOOT_TYPE = typeof(Obj_Item_Clothing_Shoes_Jackboots);
		}

		public Obj_Machinery_SuitStorageUnit_MeteorEod ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}