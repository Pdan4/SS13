// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Adult_Yellow : Mob_Living_Carbon_Slime_Adult {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "yellow";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Yellow);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Yellow);
			this.coretype = typeof(Obj_Item_SlimeExtract_Yellow);
			this.icon_state = "yellow adult slime";
		}

		// Function from file: subtypes.dm
		public Mob_Living_Carbon_Slime_Adult_Yellow ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.slime_mutation[1] = typeof(Mob_Living_Carbon_Slime_Metal);
			this.slime_mutation[2] = typeof(Mob_Living_Carbon_Slime_Bluespace);
			this.slime_mutation[3] = typeof(Mob_Living_Carbon_Slime_Orange);
			this.slime_mutation[4] = typeof(Mob_Living_Carbon_Slime_Bluespace);
			return;
		}

	}

}