// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Centhat : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "that";
			this.flags_inv = 0;
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 15 ).Set( "laser", 30 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.strip_delay = 80;
			this.icon_state = "centcom";
		}

		public Obj_Item_Clothing_Head_Centhat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}