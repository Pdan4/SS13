// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Shotgun_ScPump : Obj_Item_Weapon_Gun_Projectile_Shotgun {

		// Function from file: stationCollision.dm
		public Obj_Item_Weapon_Gun_Projectile_Shotgun_ScPump ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic ammo = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( this.magazine.stored_ammo )) {
				ammo = _a;
				

				if ( Rand13.PercentChance( 95 ) ) {
					this.magazine.stored_ammo.Remove( ammo );
				}
			}
			return;
		}

	}

}