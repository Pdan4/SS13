// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Nearsighted : Dna_Gene_Disability {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nearsightedness";
			this.activation_message = "Your eyes feel weird...";
			this.deactivation_message = "Your eyes no longer feel weird...";
			this.disability = 1;
		}

		// Function from file: disabilities.dm
		public Dna_Gene_Disability_Nearsighted (  ) {
			this.block = GlobalVars.GLASSESBLOCK;
			return;
		}

	}

}