// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Magnitis : Obj_Item_Weapon_ReagentContainers_Glass_Bottle {

		// Function from file: bottle.dm
		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Magnitis ( dynamic loc = null, dynamic altvol = null ) : base( (object)(loc), (object)(altvol) ) {
			Disease_Magnitis F = null;
			ByTable data = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			F = new Disease_Magnitis( false );
			data = new ByTable().Set( "viruses", new ByTable(new object [] { F }) );
			((Reagents)this.reagents).add_reagent( "blood", 20, data );
			return;
		}

	}

}