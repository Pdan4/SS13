// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses_Meson_Prescription : Obj_Item_Clothing_Glasses_Meson {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.prescription = true;
			this.species_fit = new ByTable(new object [] { "Vox" });
		}

		public Obj_Item_Clothing_Glasses_Meson_Prescription ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}