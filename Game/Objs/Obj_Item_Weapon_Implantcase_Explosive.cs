// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implantcase_Explosive : Obj_Item_Weapon_Implantcase {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "implantcase-r";
		}

		// Function from file: implantcase.dm
		public Obj_Item_Weapon_Implantcase_Explosive ( dynamic loc = null ) : base( (object)(loc) ) {
			this.imp = new Obj_Item_Weapon_Implant_Explosive( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}