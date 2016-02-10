// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Lipozine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lipozine";
			this.id = "Lipozine";
			this.result = "lipozine";
			this.required_reagents = new ByTable().Set( "sodiumchloride", 1 ).Set( "ethanol", 1 ).Set( "radium", 1 );
			this.result_amount = 3;
		}

	}

}