// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BruisePack : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Roll of gauze";
			this.desc = "Some sterile gauze to wrap around bloody stumps.";
			this.id = "bruise_pack";
			this.req_tech = new ByTable().Set( "biotech", 1 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 400 ).Set( "$glass", 125 );
			this.category = "Medical";
			this.build_path = typeof(Obj_Item_Stack_Medical_BruisePack);
		}

	}

}