// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_SyndieKit_ImpAdrenal : Obj_Item_Weapon_Storage_Box_SyndieKit {

		// Function from file: uplink_kits.dm
		public Obj_Item_Weapon_Storage_Box_SyndieKit_ImpAdrenal ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Weapon_Implanter O = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			O = new Obj_Item_Weapon_Implanter( this );
			O.imp = new Obj_Item_Weapon_Implant_Adrenalin( O );
			O.update_icon();
			return;
		}

	}

}