// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Saltpetre : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "saltpetre";
			this.id = "saltpetre";
			this.result = "saltpetre";
			this.required_reagents = new ByTable().Set( "potassium", 1 ).Set( "nitrogen", 1 ).Set( "oxygen", 3 );
			this.result_amount = 3;
		}

	}

}