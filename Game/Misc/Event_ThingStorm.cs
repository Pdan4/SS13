// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_ThingStorm : Event {

		public dynamic storm_name = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.startWhen = 10;
			this.endWhen = 30;
		}

		public Event_ThingStorm ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: meteors.dm
		public override void end(  ) {
			GlobalFuncs.command_alert( "The station has cleared the " + this.storm_name + ".", "Meteor Alert" );
			return;
		}

		// Function from file: meteors.dm
		public override void tick(  ) {
			GlobalFuncs.meteor_wave( Rand13.Int( 10, 20 ), null, GlobalVars.thing_storm_types[this.storm_name] );
			return;
		}

		// Function from file: meteors.dm
		public override void announce(  ) {
			GlobalFuncs.command_alert( "The station is about to be hit by a small-intensity meteor storm. Seek shelter within the core of the station immediately.", "Meteor Alert" );
			return;
		}

		// Function from file: meteors.dm
		public override void setup(  ) {
			ByTable possible_names = null;
			dynamic storm_id = null;

			this.endWhen = Rand13.Int( 30, 60 ) + 10;
			possible_names = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.thing_storm_types )) {
				storm_id = _a;
				
				possible_names.Add( storm_id );
			}
			this.storm_name = Rand13.PickFromTable( possible_names );
			return;
		}

	}

}