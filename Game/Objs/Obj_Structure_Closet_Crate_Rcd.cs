// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Rcd : Obj_Structure_Closet_Crate {

		// Function from file: crates.dm
		public Obj_Structure_Closet_Crate_Rcd ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 4 )) {
				i = _a;
				
				new Obj_Item_Weapon_RcdAmmo( this );
			}
			new Obj_Item_Weapon_Rcd( this );
			return;
		}

	}

}