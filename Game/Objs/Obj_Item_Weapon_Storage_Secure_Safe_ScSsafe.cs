// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Secure_Safe_ScSsafe : Obj_Item_Weapon_Storage_Secure_Safe {

		// Function from file: stationCollision.dm
		public Obj_Item_Weapon_Storage_Secure_Safe_ScSsafe ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.l_code = "" + GlobalVars.sc_safecode1 + GlobalVars.sc_safecode2 + GlobalVars.sc_safecode3 + GlobalVars.sc_safecode4 + GlobalVars.sc_safecode5;
			this.l_set = true;
			new Obj_Item_Weapon_Gun_Energy_Mindflayer( this );
			new Obj_Item_Device_Soulstone( this );
			new Obj_Item_Clothing_Head_Helmet_Space_Cult( this );
			new Obj_Item_Clothing_Suit_Space_Cult( this );
			new Obj_Item_Weapon_Ore_Diamond( this );
			return;
		}

	}

}