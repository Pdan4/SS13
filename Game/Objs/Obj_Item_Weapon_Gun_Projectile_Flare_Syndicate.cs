// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Flare_Syndicate : Obj_Item_Weapon_Gun_Projectile_Flare {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.recoil = 3;
			this.fire_delay = 5;
			this.caliber = new ByTable().Set( "flare", 1 ).Set( "shotgun", 1 );
			this.origin_tech = "combat=4;materials=2;syndicate=2";
		}

		public Obj_Item_Weapon_Gun_Projectile_Flare_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}