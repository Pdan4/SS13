// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_ChemGrenade_Bioterrorfoam : Obj_Item_Weapon_Grenade_ChemGrenade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.stage = 3;
		}

		// Function from file: chem_grenade.dm
		public Obj_Item_Weapon_Grenade_ChemGrenade_Bioterrorfoam ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace B1 = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace B2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			B1 = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace( this );
			B2 = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace( this );
			B1.reagents.add_reagent( "cryptobiolin", 75 );
			B1.reagents.add_reagent( "water", 50 );
			B1.reagents.add_reagent( "mutetoxin", 50 );
			B1.reagents.add_reagent( "spore", 75 );
			B1.reagents.add_reagent( "itching_powder", 50 );
			B2.reagents.add_reagent( "fluorosurfactant", 150 );
			B2.reagents.add_reagent( "mutagen", 150 );
			this.beakers.Add( B1 );
			this.beakers.Add( B2 );
			return;
		}

	}

}