// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Lye2 : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "lye";
			this.id = "lye";
			this.result = "lye";
			this.required_reagents = new ByTable().Set( "ash", 1 ).Set( "water", 1 );
			this.result_amount = 2;
		}

	}

}