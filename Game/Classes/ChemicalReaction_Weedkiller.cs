// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Weedkiller : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Weed Killer";
			this.id = "weedkiller";
			this.result = "weedkiller";
			this.required_reagents = new ByTable().Set( "toxin", 1 ).Set( "ammonia", 4 );
			this.result_amount = 5;
		}

	}

}