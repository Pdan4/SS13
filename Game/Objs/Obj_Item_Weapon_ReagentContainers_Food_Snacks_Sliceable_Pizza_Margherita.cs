// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Pizza_Margherita : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Pizza {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Margheritaslice);
			this.food_flags = 2;
			this.icon_state = "pizzamargherita";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Pizza_Margherita ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 40 );
			((Reagents)this.reagents).add_reagent( "tomatojuice", 6 );
			this.bitesize = 2;
			return;
		}

	}

}