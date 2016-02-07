// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Vanillapudding : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Vanilla Pudding";
			this.id = "vanillapudding";
			this.result = "vanillapudding";
			this.required_reagents = new ByTable().Set( "vanilla", 5 ).Set( "milk", 5 ).Set( "eggyolk", 5 );
			this.result_amount = 20;
		}

	}

}