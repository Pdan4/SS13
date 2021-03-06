// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Toy_Smg : Obj_Item_AmmoBox_Magazine_Toy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.max_ammo = 20;
			this.icon_state = "smg9mm-20";
		}

		public Obj_Item_AmmoBox_Magazine_Toy_Smg ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magazines.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "smg9mm-" + Num13.Round( this.ammo_count(), 5 );
			return false;
		}

	}

}