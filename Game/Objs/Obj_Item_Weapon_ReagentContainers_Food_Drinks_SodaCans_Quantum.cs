// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Quantum : Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "quantum";
		}

		// Function from file: drinks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Quantum ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "quantum", 30 );
			this.pixel_x = Rand13.Int( -10, 10 );
			this.pixel_y = Rand13.Int( -10, 10 );
			return;
		}

	}

}