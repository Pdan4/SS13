// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Deaf : Dna_Gene_Disability {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Deafness";
			this.activation_message = "It's kinda quiet.";
			this.deactivation_message = "You can hear again.";
			this.sdisability = 4;
			this.flags = 2;
		}

		// Function from file: disabilities.dm
		public Dna_Gene_Disability_Deaf (  ) {
			this.block = GlobalVars.DEAFBLOCK;
			return;
		}

		// Function from file: disabilities.dm
		public override bool activate( dynamic M = null, dynamic connected = null, bool? flags = null ) {
			base.activate( (object)(M), (object)(connected), flags );
			M.ear_deaf = 1;
			return false;
		}

	}

}