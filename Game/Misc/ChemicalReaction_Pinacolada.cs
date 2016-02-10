// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Pinacolada : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pina Colada";
			this.id = "pinacolada";
			this.result = "pinacolada";
			this.required_reagents = new ByTable().Set( "rum", 2 ).Set( "ice", 1 ).Set( "cream", 1 );
			this.result_amount = 4;
		}

	}

}