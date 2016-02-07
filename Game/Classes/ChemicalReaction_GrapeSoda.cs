// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_GrapeSoda : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "grape soda";
			this.id = "grapesoda";
			this.result = "grape_soda";
			this.required_reagents = new ByTable().Set( "grapejuice", 1 ).Set( "sodawater", 1 );
			this.result_amount = 2;
		}

	}

}