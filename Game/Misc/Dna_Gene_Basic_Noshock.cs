// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Basic_Noshock : Dna_Gene_Basic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Shock Immunity";
			this.activation_messages = new ByTable(new object [] { "Your skin feels electric." });
			this.deactivation_messages = new ByTable(new object [] { "Your skin no longer feels electric." });
			this.mutation = 109;
		}

		// Function from file: powers.dm
		public Dna_Gene_Basic_Noshock (  ) {
			this.block = GlobalVars.SHOCKIMMUNITYBLOCK;
			return;
		}

	}

}