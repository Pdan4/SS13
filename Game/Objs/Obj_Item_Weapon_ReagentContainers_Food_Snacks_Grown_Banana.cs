// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "banana";
			this.filling_color = "#FCF695";
			this.trash = typeof(Obj_Item_Weapon_Bananapeel);
			this.plantname = "banana";
			this.icon_state = "banana";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana ( dynamic newloc = null, dynamic newpotency = null ) : base( (object)(newloc), (object)(newpotency) ) {
			
		}

	}

}