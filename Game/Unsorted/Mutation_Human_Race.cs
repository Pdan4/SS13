// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Race : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Monkified";
			this.quality = 2;
			this.time_coeff = 2;
		}

		// Function from file: mutations.dm
		public override dynamic on_losing( dynamic owner = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( owner ) && owner is Mob_Living_Carbon_Monkey && Convert.ToInt32( owner.stat ) != 2 && Lang13.Bool( owner.dna.mutations.Remove( this ) ) ) {
				_default = ((Mob_Living_Carbon)owner).humanize( 311 );
			}
			return _default;
		}

		// Function from file: mutations.dm
		public override dynamic on_acquiring( dynamic owner = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( base.on_acquiring( (object)(owner) ) ) ) {
				return _default;
			}
			_default = ((Mob_Living_Carbon)owner).monkeyize( 311 );
			return _default;
		}

	}

}