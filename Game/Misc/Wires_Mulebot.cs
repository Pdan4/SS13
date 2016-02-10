// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Mulebot : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random = true;
			this.holder_type = typeof(Obj_Machinery_Bot_Mulebot);
			this.wire_count = 10;
		}

		public Wires_Mulebot ( Obj holder = null ) : base( holder ) {
			
		}

		// Function from file: mulebot.dm
		public bool BeaconRX(  ) {
			return !( ( this.wires_status & 256 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool RemoteRX(  ) {
			return !( ( this.wires_status & 64 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool RemoteTX(  ) {
			return !( ( this.wires_status & 128 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool MobAvoid(  ) {
			return !( ( this.wires_status & 4 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool LoadCheck(  ) {
			return !( ( this.wires_status & 8 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool HasPower(  ) {
			return !( ( this.wires_status & 1 ) != 0 ) && !( ( this.wires_status & 2 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool Motor2(  ) {
			return !( ( this.wires_status & 32 ) != 0 );
		}

		// Function from file: mulebot.dm
		public bool Motor1(  ) {
			return !( ( this.wires_status & 16 ) != 0 );
		}

		// Function from file: mulebot.dm
		public string getRegulatorColor(  ) {
			
			if ( this.IsIndexCut( GlobalVars.WIRE_MOTOR1 ) != 0 && this.IsIndexCut( GlobalVars.WIRE_MOTOR2 ) != 0 ) {
				return "red";
			} else if ( this.IsIndexCut( GlobalVars.WIRE_MOTOR1 ) != 0 || this.IsIndexCut( GlobalVars.WIRE_MOTOR2 ) != 0 ) {
				return "yellow";
			} else {
				return "green";
			}
			return null;
		}

		// Function from file: mulebot.dm
		public override void UpdatePulsed( double? index = null ) {
			
			switch ((double?)( index )) {
				case 64:
				case 128:
				case 256:
					this.holder.visible_message( new Txt( "<span class='notice'>" ).icon( this.holder ).str( " You hear a radio crackle.</span>" ).ToString() );
					break;
			}
			return;
		}

		// Function from file: mulebot.dm
		public override string GetInteractWindow(  ) {
			string _default = null;

			_default += base.GetInteractWindow();
			_default += "<BR>The charge light is " + ( this.IsIndexCut( GlobalVars.WIRE_POWER1 ) != 0 || this.IsIndexCut( GlobalVars.WIRE_POWER2 ) != 0 ? "off" : "on" ) + ".<BR>\n	The warning light is " + ( this.IsIndexCut( GlobalVars.WIRE_AVOIDANCE ) != 0 ? "gleaming ominously" : "off" ) + ".<BR>\n	The platform is " + ( this.IsIndexCut( GlobalVars.WIRE_LOADCHECK ) != 0 ? "riding low" : "elevated" ) + ".<BR>\n	The regulator light is " + this.getRegulatorColor() + ".<BR>";
			return _default;
		}

		// Function from file: mulebot.dm
		public override bool Interact( dynamic user = null ) {
			Obj M = null;

			
			if ( this.CanUse( user ) ) {
				M = this.holder;
				M.interact( user );
			}
			return false;
		}

		// Function from file: mulebot.dm
		public override bool CanUse( dynamic L = null ) {
			Obj M = null;

			M = this.holder;

			if ( Lang13.Bool( ((dynamic)M).open ) ) {
				return true;
			}
			return false;
		}

	}

}