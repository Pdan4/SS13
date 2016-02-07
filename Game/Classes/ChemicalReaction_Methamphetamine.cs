// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Methamphetamine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "methamphetamine";
			this.id = "methamphetamine";
			this.result = "methamphetamine";
			this.required_reagents = new ByTable().Set( "ephedrine", 1 ).Set( "iodine", 1 ).Set( "phosphorus", 1 ).Set( "hydrogen", 1 );
			this.result_amount = 4;
			this.required_temp = 374;
		}

	}

}