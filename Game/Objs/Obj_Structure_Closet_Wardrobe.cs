// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "blue";
			this.icon_state = "blue";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Under_Color_Blue( this );
			new Obj_Item_Clothing_Under_Color_Blue( this );
			new Obj_Item_Clothing_Under_Color_Blue( this );
			new Obj_Item_Clothing_Shoes_Brown( this );
			new Obj_Item_Clothing_Shoes_Brown( this );
			new Obj_Item_Clothing_Shoes_Brown( this );
			return;
		}

	}

}