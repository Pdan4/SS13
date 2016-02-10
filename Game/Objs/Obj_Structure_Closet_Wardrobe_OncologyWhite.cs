// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_OncologyWhite : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "white";
			this.icon_state = "white";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_OncologyWhite ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Rank_Medical( this );
			new Obj_Item_Clothing_Under_Rank_Medical( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat_Oncologist( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat_Oncologist( this );
			this.AddToProfiler();
			return;
		}

	}

}