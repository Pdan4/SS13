// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Steal_Exchange_Backstab : Objective_Steal_Exchange {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dangerrating = 3;
		}

		public Objective_Steal_Exchange_Backstab ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override void set_faction( string faction = null, dynamic otheragent = null ) {
			
			if ( faction == "red" ) {
				this.targetinfo = new ObjectiveItem_Unique_DocsRed();
			} else if ( faction == "blue" ) {
				this.targetinfo = new ObjectiveItem_Unique_DocsBlue();
			}
			this.explanation_text = "Do not give up or lose " + this.targetinfo.name + ".";
			this.steal_target = this.targetinfo.targetitem;
			return;
		}

	}

}