// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Medical_BruisePack : Obj_Item_Stack_Medical {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "bruise pack";
			this.heal_brute = 40;
			this.origin_tech = "biotech=1";
			this.icon_state = "brutepack";
		}

		public Obj_Item_Stack_Medical_BruisePack ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}