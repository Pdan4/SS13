// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_SalAcid : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Salicyclic Acid";
			this.id = "sal_acid";
			this.result = "sal_acid";
			this.required_reagents = new ByTable().Set( "sodium", 1 ).Set( "phenol", 1 ).Set( "carbon", 1 ).Set( "oxygen", 1 ).Set( "sacid", 1 );
			this.result_amount = 5;
		}

	}

}