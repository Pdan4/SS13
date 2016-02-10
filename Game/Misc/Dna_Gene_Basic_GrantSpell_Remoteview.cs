// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Basic_GrantSpell_Remoteview : Dna_Gene_Basic_GrantSpell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Remote Viewing";
			this.activation_messages = new ByTable(new object [] { "Your mind expands." });
			this.deactivation_messages = new ByTable(new object [] { "Your mind is no longer expanded." });
			this.drug_activation_messages = new ByTable(new object [] { "You feel in touch with the cosmos." });
			this.drug_deactivation_messages = new ByTable(new object [] { "You no longer feel in touch with the cosmos." });
			this.mutation = 101;
			this.spelltype = typeof(Spell_Targeted_Remoteobserve);
		}

		// Function from file: powers.dm
		public Dna_Gene_Basic_GrantSpell_Remoteview (  ) {
			this.block = GlobalVars.REMOTEVIEWBLOCK;
			return;
		}

	}

}