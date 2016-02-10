// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Assembly_Signaler_SignalerButton : Obj_Item_Device_Assembly_Signaler {

		public string id_tag = "default";
		public bool active = false;
		public bool activated = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.show_status = false;
			this.ghost_read = false;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "launcherbtt";
		}

		// Function from file: signaler.dm
		public Obj_Item_Device_Assembly_Signaler_SignalerButton ( dynamic loc = null, int? w_dir = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			switch ((int?)( w_dir )) {
				case 1:
					this.pixel_y = 25;
					break;
				case 2:
					this.pixel_y = -25;
					break;
				case 4:
					this.pixel_x = 25;
					break;
				case 8:
					this.pixel_x = -25;
					break;
			}
			return;
		}

		// Function from file: signaler.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string n_name = null;
			Obj_Item_Mounted_Frame_DriverButton_SignalerButton I = null;

			
			if ( a is Obj_Item_Weapon_Pen ) {
				n_name = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( b, "What would you like to name this button?", "Button Labeling", null, null, InputType.Str | InputType.Null ) ), 1, 78 );

				if ( Lang13.Bool( n_name ) && this.Adjacent( b ) && !Lang13.Bool( b.stat ) ) {
					this.name = "" + n_name;
				}
				return null;
			}

			if ( a is Obj_Item_Weapon_Crowbar ) {
				GlobalFuncs.to_chat( b, new Txt( "You begin prying " ).the( this ).item().str( " off the wall." ).ToString() );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 50, 1 );

				if ( GlobalFuncs.do_after( b, this, 10 ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You pry the button off of the wall.</span>" );
					I = new Obj_Item_Mounted_Frame_DriverButton_SignalerButton( GlobalFuncs.get_turf( b ) );
					I.code = this.code;
					I.frequency = this.frequency;
					GlobalFuncs.qdel( this );
				}
				return null;
			}

			if ( a is Obj_Item_Device_Multitool ) {
				this.interact( b, null );
				return null;
			}
			return null;
		}

		// Function from file: signaler.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( !this.activated ) {
				this.activated = true;
				this.icon_state = "launcheract";
				this.activate();
				Task13.Sleep( 20 );
				this.icon_state = "launcherbtt";
				this.activated = false;
			}
			return null;
		}

	}

}