// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Sbiten : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sbiten";
			this.id = "sbiten";
			this.result = "sbiten";
			this.required_reagents = new ByTable().Set( "vodka", 10 ).Set( "capsaicin", 1 );
			this.result_amount = 10;
		}

	}

}