// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Aranesp : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "aranesp";
			this.id = "aranesp";
			this.result = "aranesp";
			this.required_reagents = new ByTable().Set( "epinephrine", 1 ).Set( "atropine", 1 ).Set( "morphine", 1 );
			this.result_amount = 3;
		}

	}

}