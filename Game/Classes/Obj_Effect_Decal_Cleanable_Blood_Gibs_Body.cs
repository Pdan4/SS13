// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Blood_Gibs_Body : Obj_Effect_Decal_Cleanable_Blood_Gibs {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = new ByTable(new object [] { "gibhead", "gibtorso" });
		}

		public Obj_Effect_Decal_Cleanable_Blood_Gibs_Body ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}