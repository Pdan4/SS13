// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Ammonia : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ammonia";
			this.id = "ammonia";
			this.result = "ammonia";
			this.required_reagents = new ByTable().Set( "hydrogen", 3 ).Set( "nitrogen", 1 );
			this.result_amount = 3;
		}

	}

}