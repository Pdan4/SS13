// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Pill_Bicaridine : Obj_Item_Weapon_ReagentContainers_Pill {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pill18";
		}

		// Function from file: pill.dm
		public Obj_Item_Weapon_ReagentContainers_Pill_Bicaridine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "bicaridine", 30 );
			return;
		}

	}

}