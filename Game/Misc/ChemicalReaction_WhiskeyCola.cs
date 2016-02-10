// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_WhiskeyCola : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Whiskey Cola";
			this.id = "whiskeycola";
			this.result = "whiskeycola";
			this.required_reagents = new ByTable().Set( "whiskey", 2 ).Set( "cola", 1 );
			this.result_amount = 3;
		}

	}

}