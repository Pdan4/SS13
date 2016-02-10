// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wound_Cut_GapingBig : Wound_Cut {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.max_bleeding_stage = 2;
			this.stages = new ByTable().Set( "big gaping wound", 60 ).Set( "healing gaping wound", 40 ).Set( "large angry scar", 10 ).Set( "large straight scar", 0 );
			this.needs_treatment = true;
		}

		public Wound_Cut_GapingBig ( int damage = 0 ) : base( damage ) {
			
		}

	}

}