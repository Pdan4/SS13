// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Monkeyclothes_Cultrobes : Obj_Item_Clothing_Monkeyclothes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cult_item";
			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 30 ).Set( "laser", 50 ).Set( "energy", 20 ).Set( "bomb", 25 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.icon_state = "cult_icon";
		}

		public Obj_Item_Clothing_Monkeyclothes_Cultrobes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}