// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Injectors : Obj_Item_Weapon_Storage_Box {

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Injectors ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;
			int? i2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			i = null;
			i = 0;

			while (( i ??0) < 3) {
				new Obj_Item_Weapon_Dnainjector_Nofail_H2m( this );
				i++;
			}
			i2 = null;
			i2 = 0;

			while (( i2 ??0) < 3) {
				new Obj_Item_Weapon_Dnainjector_Nofail_M2h( this );
				i2++;
			}
			return;
		}

	}

}