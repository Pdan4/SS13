// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Warden : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 5 ).Set( "laser", 25 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.strip_delay = 60;
			this.icon_state = "policehelm";
		}

		public Obj_Item_Clothing_Head_Warden ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}