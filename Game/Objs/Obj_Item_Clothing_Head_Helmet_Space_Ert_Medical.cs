// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Ert_Medical : Obj_Item_Clothing_Head_Helmet_Space_Ert {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.icon_state = "ert_medical";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Ert_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}