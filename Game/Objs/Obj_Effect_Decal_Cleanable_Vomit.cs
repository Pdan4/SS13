// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Vomit : Obj_Effect_Decal_Cleanable {

		public ByTable viruses = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = new ByTable(new object [] { "vomit_1", "vomit_2", "vomit_3", "vomit_4" });
			this.icon = "icons/effects/blood.dmi";
			this.icon_state = "vomit_1";
		}

		public Obj_Effect_Decal_Cleanable_Vomit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: misc.dm
		public override dynamic Destroy(  ) {
			Disease D = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.viruses, typeof(Disease) )) {
				D = _a;
				
				D.cure( 0 );
			}
			this.viruses = null;
			return base.Destroy();
		}

	}

}