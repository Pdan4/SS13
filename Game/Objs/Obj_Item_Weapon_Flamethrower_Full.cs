// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Flamethrower_Full : Obj_Item_Weapon_Flamethrower {

		// Function from file: flamethrower.dm
		public Obj_Item_Weapon_Flamethrower_Full ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.weldtool = new Obj_Item_Weapon_Weldingtool( this );
			this.weldtool.status = false;
			this.igniter = new Obj_Item_Device_Assembly_Igniter( this );
			this.igniter.secured = 0;
			this.status = true;
			this.update_icon();
			return;
		}

	}

}