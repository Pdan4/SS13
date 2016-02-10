// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Booger : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Booger";
			this.id = "booger";
			this.result = "booger";
			this.required_reagents = new ByTable().Set( "cream", 1 ).Set( "banana", 1 ).Set( "rum", 1 ).Set( "watermelonjuice", 1 );
			this.result_amount = 4;
		}

	}

}