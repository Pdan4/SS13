// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_MeteorWave : Event {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.endWhen = 30;
		}

		public Event_MeteorWave ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: meteors.dm
		public override void end(  ) {
			GlobalFuncs.command_alert( "The station has cleared the meteor storm.", "Meteor Alert" );
			return;
		}

		// Function from file: meteors.dm
		public override void tick(  ) {
			GlobalFuncs.meteor_wave( Rand13.Int( 10, 15 ), 2 );
			return;
		}

		// Function from file: meteors.dm
		public override void announce(  ) {
			GlobalFuncs.command_alert( "A meteor storm has been detected on collision course with the station. Seek shelter within the core of the station immediately.", "Meteor Alert" );
			GlobalFuncs.to_chat( typeof(Game13), new Sound( "sound/AI/meteors.ogg" ) );
			return;
		}

		// Function from file: meteors.dm
		public override void setup(  ) {
			this.endWhen = Rand13.Int( 45, 90 );
			return;
		}

	}

}