// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Uranium : Obj_Machinery_Door_Airlock {

		public int last_event = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineral = "uranium";
			this.icon = "icons/obj/doors/Dooruranium.dmi";
		}

		public Obj_Machinery_Door_Airlock_Uranium ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: airlock.dm
		public void radiate(  ) {
			Mob_Living L = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 3 ), typeof(Mob_Living) )) {
				L = _a;
				
				L.apply_effect( 15, "irradiate", 0 );
			}
			return;
		}

		// Function from file: airlock.dm
		public override dynamic process(  ) {
			
			if ( Game13.time > this.last_event + 20 ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					this.radiate();
				}
				this.last_event = Game13.time;
			}
			base.process();
			return null;
		}

	}

}