// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Thirteenloko : Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "thirteen_loko";
		}

		// Function from file: drinks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Thirteenloko ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "thirteenloko", 30 );
			this.pixel_x = Rand13.Int( -10, 10 );
			this.pixel_y = Rand13.Int( -10, 10 );
			return;
		}

	}

}