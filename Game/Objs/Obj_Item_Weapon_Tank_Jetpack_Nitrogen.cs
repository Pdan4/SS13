// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tank_Jetpack_Nitrogen : Obj_Item_Weapon_Tank_Jetpack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "jetpack-red";
			this.icon_state = "jetpack-red";
		}

		// Function from file: jetpack.dm
		public Obj_Item_Weapon_Tank_Jetpack_Nitrogen ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.adjust( null, null, this.volume * 607.949951171875 / 2437.2490234375 );
			return;
		}

	}

}