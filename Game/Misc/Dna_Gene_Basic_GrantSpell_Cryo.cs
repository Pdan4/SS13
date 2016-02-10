// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Basic_GrantSpell_Cryo : Dna_Gene_Basic_GrantSpell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cryokinesis";
			this.desc = "Allows the subject to lower the body temperature of others.";
			this.activation_messages = new ByTable(new object [] { "You notice a strange cold tingle in your fingertips." });
			this.deactivation_messages = new ByTable(new object [] { "Your fingers feel warmer." });
			this.drug_activation_messages = new ByTable(new object [] { "Your skin is icy to the touch." });
			this.drug_deactivation_messages = new ByTable(new object [] { "Your skin stops feeling icy." });
			this.spelltype = typeof(Spell_Targeted_Cryokinesis);
		}

		// Function from file: goon_powers.dm
		public Dna_Gene_Basic_GrantSpell_Cryo (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.block = GlobalVars.CRYOBLOCK;
			return;
		}

	}

}