// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Bolt : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 15;
			this.damage_type = "tox";
			this.weaken = 5;
			this.stutter = 5;
			this.icon_state = "cbbolt";
		}

		public Obj_Item_Projectile_Energy_Bolt ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}