// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Aloe : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Aloe";
			this.id = "aloe";
			this.result = "aloe";
			this.required_reagents = new ByTable().Set( "irishcream", 1 ).Set( "watermelonjuice", 1 );
			this.result_amount = 2;
		}

	}

}