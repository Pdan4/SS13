// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MagSmg_IncinMag : Design_MagSmg {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "SABR SMG Incendiary Magazine (9mmIC)";
			this.desc = "A 30-round incindiary round magazine for the prototype submachine gun. Deals significanlty less damage but sets the target on fire";
			this.id = "mag_smg_ic";
			this.materials = new ByTable().Set( "$metal", 3000 ).Set( "$silver", 100 ).Set( "$glass", 400 );
			this.build_path = typeof(Obj_Item_AmmoBox_Magazine_Smgm9mm_Fire);
		}

	}

}