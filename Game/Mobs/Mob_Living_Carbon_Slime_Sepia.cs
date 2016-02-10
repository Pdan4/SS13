// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Sepia : Mob_Living_Carbon_Slime {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "sepia";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Sepia);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Sepia);
			this.coretype = typeof(Obj_Item_SlimeExtract_Sepia);
			this.icon_state = "sepia baby slime";
		}

		public Mob_Living_Carbon_Slime_Sepia ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}