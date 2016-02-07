// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Surfactant : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Foam surfactant";
			this.id = "foam surfactant";
			this.result = "fluorosurfactant";
			this.required_reagents = new ByTable().Set( "fluorine", 2 ).Set( "carbon", 2 ).Set( "sacid", 1 );
			this.result_amount = 5;
		}

	}

}