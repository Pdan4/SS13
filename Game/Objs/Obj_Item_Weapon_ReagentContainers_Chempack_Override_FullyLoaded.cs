// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Chempack_Override_FullyLoaded : Obj_Item_Weapon_ReagentContainers_Chempack_Override {

		// Function from file: chempack.dm
		public Obj_Item_Weapon_ReagentContainers_Chempack_Override_FullyLoaded ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic B = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.beaker = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large();
			B = this.beaker;
			((Reagents)B.reagents).add_reagent( "creatine", 100 );
			((Reagents)this.reagents).add_reagent( "kelotane", 125 );
			((Reagents)this.reagents).add_reagent( "dermaline", 125 );
			((Reagents)this.reagents).add_reagent( "tricordrazine", 125 );
			((Reagents)this.reagents).add_reagent( "anti_toxin", 210 );
			((Reagents)this.reagents).add_reagent( "bicaridine", 125 );
			((Reagents)this.reagents).add_reagent( "hyperzine", 22 );
			((Reagents)this.reagents).add_reagent( "imidazoline", 122 );
			((Reagents)this.reagents).add_reagent( "arithrazine", 32 );
			((Reagents)this.reagents).add_reagent( "hyronalin", 32 );
			((Reagents)this.reagents).add_reagent( "alkysine", 32 );
			((Reagents)this.reagents).add_reagent( "dexalinp", 125 );
			((Reagents)this.reagents).add_reagent( "leporazine", 125 );
			return;
		}

	}

}