// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SuitStorageUnit_Excavation : Obj_Machinery_SuitStorageUnit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.SUIT_TYPE = typeof(Obj_Item_Clothing_Suit_Space_Anomaly);
			this.HELMET_TYPE = typeof(Obj_Item_Clothing_Head_Helmet_Space_Anomaly);
			this.MASK_TYPE = typeof(Obj_Item_Clothing_Mask_Breath);
			this.BOOT_TYPE = typeof(Obj_Item_Clothing_Shoes_Magboots);
		}

		public Obj_Machinery_SuitStorageUnit_Excavation ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}