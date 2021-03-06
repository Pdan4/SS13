// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Wine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Wine";
			this.id = "wine";
			this.result = "wine";
			this.required_reagents = new ByTable().Set( "grapejuice", 10 );
			this.required_catalysts = new ByTable().Set( "enzyme", 5 );
			this.result_amount = 10;
		}

	}

}