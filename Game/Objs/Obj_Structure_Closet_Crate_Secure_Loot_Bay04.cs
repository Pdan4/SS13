// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Crate_Secure_Loot_Bay04 : Obj_Structure_Closet_Crate_Secure_Loot {

		// Function from file: bay12.dm
		public Obj_Structure_Closet_Crate_Secure_Loot_Bay04 ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			i = null;
			i = 0;

			while (( i ??0) < Rand13.Int( 10, 20 )) {
				new Obj_Item_Weapon_Ore_Diamond( this );
				i++;
			}
			return;
		}

	}

}