// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Speech_Swedish : Dna_Gene_Disability_Speech {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Swedish";
			this.desc = "Forces the language center of the subject's brain to construct sentences in a vaguely norse manner.";
			this.activation_message = "You feel Swedish, however that works.";
			this.deactivation_message = "The feeling of Swedishness passes.";
		}

		// Function from file: goon_disabilities.dm
		public Dna_Gene_Disability_Speech_Swedish (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.block = GlobalVars.SWEDEBLOCK;
			return;
		}

		// Function from file: goon_disabilities.dm
		public override dynamic OnSay( Mob M = null, dynamic message = null ) {
			message.message = GlobalFuncs.replacetext( message.message, "w", "v" );

			if ( Rand13.PercentChance( 30 ) ) {
				message.message += " Bork" + Rand13.Pick(new object [] { "", ", bork", ", bork, bork" }) + "!";
			}
			return null;
		}

	}

}