// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Dnainjector_Nofail_Antihulk : Obj_Item_Weapon_Dnainjector_Nofail {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.datatype = 4;
			this.value = 1;
		}

		// Function from file: dna_injector.dm
		public Obj_Item_Weapon_Dnainjector_Nofail_Antihulk ( dynamic loc = null ) : base( (object)(loc) ) {
			this.block = GlobalVars.HULKBLOCK;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}