// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Lithium : Obj_Item_Weapon_ReagentContainers_Glass_Beaker {

		// Function from file: chemistry.dm
		public Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Lithium ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "lithium", 50 );
			this.update_icon();
			return;
		}

	}

}