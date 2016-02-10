// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Nervousness : Dna_Gene_Disability {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nervousness";
			this.activation_message = "You feel nervous.";
			this.deactivation_message = "You feel calmer.";
			this.disability = 16;
		}

		// Function from file: disabilities.dm
		public Dna_Gene_Disability_Nervousness (  ) {
			this.block = GlobalVars.NERVOUSBLOCK;
			return;
		}

		// Function from file: disabilities.dm
		public override void OnMobLife( Mob_Living M = null ) {
			base.OnMobLife( M );

			if ( Rand13.PercentChance( 10 ) ) {
				M.stuttering = Num13.MaxInt( 10, Convert.ToInt32( M.stuttering ) );
			}
			return;
		}

	}

}