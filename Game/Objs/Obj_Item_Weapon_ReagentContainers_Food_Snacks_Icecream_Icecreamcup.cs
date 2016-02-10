// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream_Icecreamcup : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.volume = 500;
			this.icon_state = "icecream_cup";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream_Icecreamcup ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 4 );
			((Reagents)this.reagents).add_reagent( "sugar", 8 );
			((Reagents)this.reagents).add_reagent( "ice", 2 );
			this.bitesize = 6;
			return;
		}

	}

}