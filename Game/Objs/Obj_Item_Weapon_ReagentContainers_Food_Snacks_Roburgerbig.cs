// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Roburgerbig : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "roburger";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Roburgerbig ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nanites", 100 );
			this.bitesize = 0.1;
			return;
		}

	}

}