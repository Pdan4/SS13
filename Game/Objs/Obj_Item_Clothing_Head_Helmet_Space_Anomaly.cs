// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Anomaly : Obj_Item_Clothing_Head_Helmet_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cespace_helmet";
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 100 ).Set( "rad", 100 );
			this.body_parts_covered = 14337;
			this.icon_state = "cespace_helmet";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Anomaly ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}