// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Neurotox : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage_type = "tox";
			this.icon_state = "toxin";
		}

		public Obj_Item_Projectile_Energy_Neurotox ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}