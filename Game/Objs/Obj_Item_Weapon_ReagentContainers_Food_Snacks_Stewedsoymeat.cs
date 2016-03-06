// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Stewedsoymeat : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 );
			this.list_reagents = new ByTable().Set( "nutriment", 8 );
			this.filling_color = "#D2691E";
			this.icon_state = "stewedsoymeat";
		}

		// Function from file: snacks_meat.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Stewedsoymeat ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.eatverb = Rand13.Pick(new object [] { "slurp", "sip", "suck", "inhale", "drink" });
			return;
		}

	}

}