// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Reinforced : Obj_Structure_Window {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reinf = true;
			this.maxhealth = 50;
			this.explosion_block = 1;
			this.icon_state = "rwindow";
		}

		public Obj_Structure_Window_Reinforced ( dynamic Loc = null, bool? re = null ) : base( (object)(Loc), re ) {
			
		}

		// Function from file: window.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					this.spawnfragments();
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.spawnfragments();
					}
					break;
			}
			return false;
		}

	}

}