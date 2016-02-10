// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Epilepsy : Dna_Gene_Disability {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Epilepsy";
			this.activation_message = "You get a headache.";
			this.deactivation_message = "Your headache disappears.";
			this.disability = 2;
		}

		// Function from file: disabilities.dm
		public Dna_Gene_Disability_Epilepsy (  ) {
			this.block = GlobalVars.HEADACHEBLOCK;
			return;
		}

	}

}