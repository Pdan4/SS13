// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Sulfonal : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "sulfonal";
			this.id = "sulfonal";
			this.result = "sulfonal";
			this.required_reagents = new ByTable().Set( "acetone", 1 ).Set( "diethylamine", 1 ).Set( "sulfur", 1 );
			this.result_amount = 3;
		}

	}

}