// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Lipolicide : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "lipolicide";
			this.id = "lipolicide";
			this.result = "lipolicide";
			this.required_reagents = new ByTable().Set( "mercury", 1 ).Set( "diethylamine", 1 ).Set( "ephedrine", 1 );
			this.result_amount = 3;
		}

	}

}