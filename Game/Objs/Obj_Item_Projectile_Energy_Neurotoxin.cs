// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Neurotoxin : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 5;
			this.damage_type = "tox";
			this.weaken = 5;
			this.icon_state = "neurotoxin";
		}

		public Obj_Item_Projectile_Energy_Neurotoxin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}