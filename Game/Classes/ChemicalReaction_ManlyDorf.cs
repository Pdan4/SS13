// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_ManlyDorf : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "The Manly Dorf";
			this.id = "manlydorf";
			this.result = "manlydorf";
			this.required_reagents = new ByTable().Set( "beer", 1 ).Set( "ale", 2 );
			this.result_amount = 3;
		}

	}

}