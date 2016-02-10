// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Adult_Green : Mob_Living_Carbon_Slime_Adult {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "green";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Green);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Green);
			this.coretype = typeof(Obj_Item_SlimeExtract_Green);
			this.icon_state = "green adult slime";
		}

		// Function from file: subtypes.dm
		public Mob_Living_Carbon_Slime_Adult_Green ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.slime_mutation[1] = typeof(Mob_Living_Carbon_Slime_Green);
			this.slime_mutation[2] = typeof(Mob_Living_Carbon_Slime_Green);
			this.slime_mutation[3] = typeof(Mob_Living_Carbon_Slime_Black);
			this.slime_mutation[4] = typeof(Mob_Living_Carbon_Slime_Black);
			return;
		}

	}

}