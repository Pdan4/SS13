// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Coatrack_Full : Obj_Structure_Coatrack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "coatrack3";
		}

		// Function from file: coatrack.dm
		public Obj_Structure_Coatrack_Full ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.suit = new Obj_Item_Clothing_Suit_Storage_DetSuit( this );
			this.hat = new Obj_Item_Clothing_Head_DetHat( this );
			return;
		}

	}

}