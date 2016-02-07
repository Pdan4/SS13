// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_SalgluSolution : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Saline-Glucose Solution";
			this.id = "salglu_solution";
			this.result = "salglu_solution";
			this.required_reagents = new ByTable().Set( "sodiumchloride", 1 ).Set( "water", 1 ).Set( "sugar", 1 );
			this.result_amount = 3;
		}

	}

}