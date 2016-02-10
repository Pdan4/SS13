// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Erikasurprise : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Erika Surprise";
			this.id = "erikasurprise";
			this.result = "erikasurprise";
			this.required_reagents = new ByTable().Set( "ale", 1 ).Set( "limejuice", 1 ).Set( "whiskey", 1 ).Set( "banana", 1 ).Set( "ice", 1 );
			this.result_amount = 5;
		}

	}

}