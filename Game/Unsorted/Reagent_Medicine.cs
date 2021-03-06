// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Medicine";
			this.id = "medicine";
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			this.current_cycle++;
			((dynamic)this.holder).remove_reagent( this.id, this.metabolization_rate / M.metabolism_efficiency );
			return false;
		}

	}

}