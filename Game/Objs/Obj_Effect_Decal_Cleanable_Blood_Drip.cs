// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Blood_Drip : Obj_Effect_Decal_Cleanable_Blood {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = new ByTable(new object [] { "1", "2", "3", "4", "5" });
			this.base_icon = "icons/effects/drip.dmi";
			this.icon = "icons/effects/drip.dmi";
			this.icon_state = "1";
		}

		public Obj_Effect_Decal_Cleanable_Blood_Drip ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}