// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Fat : Dna_Gene_Disability {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Obesity";
			this.desc = "Greatly slows the subject's metabolism, enabling greater buildup of lipid tissue.";
			this.activation_message = "You feel blubbery and lethargic!";
			this.deactivation_message = "You feel fit!";
			this.mutation = 200;
		}

		// Function from file: goon_disabilities.dm
		public Dna_Gene_Disability_Fat (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.block = GlobalVars.FATBLOCK;
			return;
		}

		// Function from file: goon_disabilities.dm
		public override bool can_activate( dynamic M = null, bool? flags = null ) {
			dynamic H = null;

			
			if ( !( M is Mob_Living_Carbon_Human ) ) {
				return false;
			}
			H = M;

			if ( Lang13.Bool( H.species ) && !Lang13.Bool( H.species.flags & 8192 ) ) {
				return false;
			}
			return true;
		}

	}

}