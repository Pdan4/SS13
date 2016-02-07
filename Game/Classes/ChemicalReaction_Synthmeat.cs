// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Synthmeat : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "synthmeat";
			this.id = "synthmeat";
			this.required_reagents = new ByTable().Set( "blood", 5 ).Set( "cryoxadone", 1 );
			this.result_amount = 1;
			this.mob_react = true;
		}

		// Function from file: food_mixtures.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic location = null;

			location = GlobalFuncs.get_turf( holder.my_atom );
			new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Synthmeat( location );
			return;
		}

	}

}