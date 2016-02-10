// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Unlockable_Borer : Unlockable {

		public bool remove_on_detach = true;
		public Mob_Living_SimpleAnimal_Borer borer = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cost_units = "C";
		}

		// Function from file: unlocks.dm
		public void on_attached(  ) {
			return;
		}

		// Function from file: unlocks.dm
		public void on_detached(  ) {
			return;
		}

		// Function from file: unlocks.dm
		public override bool can_buy(  ) {
			return base.can_buy() && Lang13.Bool( this.borer.host ) && !Lang13.Bool( this.borer.stat ) && !this.borer.controlling && Convert.ToInt32( this.borer.host.stat ) != 2;
		}

		// Function from file: unlocks.dm
		public override bool unlock_check(  ) {
			return this.borer.chemicals >= this.cost;
		}

		// Function from file: unlocks.dm
		public override void end_unlock(  ) {
			this.borer.chemicals -= this.cost;
			return;
		}

		// Function from file: unlocks.dm
		public override void begin_unlock(  ) {
			GlobalFuncs.to_chat( this.borer, "<span class='warning'>You begin concentrating intensely on producing the necessary changes.</span>" );
			GlobalFuncs.to_chat( this.borer, "<span class='danger'>You will be unable to use any borer abilities until the process completes.</span>" );
			return;
		}

		// Function from file: unlocks.dm
		public override void set_context( ResearchTree T = null ) {
			base.set_context( T );
			this.borer = ((dynamic)T).borer;
			return;
		}

	}

}