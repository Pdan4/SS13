// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Oil : Mob_Living_Carbon_Slime {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "oil";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Oil);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Oil);
			this.coretype = typeof(Obj_Item_SlimeExtract_Oil);
			this.icon_state = "oil baby slime";
		}

		public Mob_Living_Carbon_Slime_Oil ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}