// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Syndicake : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_SyndiCakes);
			this.icon_state = "syndi_cakes";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Syndicake ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 4 );
			((Reagents)this.reagents).add_reagent( "doctorsdelight", 5 );
			this.bitesize = 3;
			return;
		}

	}

}