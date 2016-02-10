// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wound_Burn_Large : Wound_Burn {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.stages = new ByTable().Set( "ripped large burn", 20 ).Set( "large burn", 15 ).Set( "large salved burn", 5 ).Set( "fresh skin", 0 );
			this.needs_treatment = true;
			this.damage_type = "fire";
		}

		public Wound_Burn_Large ( int damage = 0 ) : base( damage ) {
			
		}

	}

}