// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream_Icecreamcone : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.volume = 500;
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Icecream_Icecreamcone ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 2 );
			((Reagents)this.reagents).add_reagent( "sugar", 6 );
			((Reagents)this.reagents).add_reagent( "ice", 2 );
			this.bitesize = 3;
			return;
		}

	}

}