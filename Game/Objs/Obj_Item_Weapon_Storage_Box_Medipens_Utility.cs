// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Medipens_Utility : Obj_Item_Weapon_Storage_Box_Medipens {

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Medipens_Utility ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 5 )) {
				i = _a;
				
				new Obj_Item_Weapon_ReagentContainers_Hypospray_Medipen_Stimpack( this );
			}
			return;
		}

	}

}