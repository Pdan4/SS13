// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ_Internal_Eyes : Organ_Internal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "eyes";
			this.parent_organ = "head";
			this.removed_type = typeof(Obj_Item_Organ_Eyes);
		}

		public Organ_Internal_Eyes ( Mob_Living_Carbon_Human H = null ) : base( H ) {
			
		}

		// Function from file: organ_internal.dm
		public override bool process(  ) {
			
			if ( this.is_bruised() ) {
				this.owner.eye_blurry = 20;
			}

			if ( this.is_broken() ) {
				this.owner.eye_blind = 20;
			}
			return false;
		}

	}

}