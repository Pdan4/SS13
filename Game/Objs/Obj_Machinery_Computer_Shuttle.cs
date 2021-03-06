// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Shuttle : Obj_Machinery_Computer {

		public string shuttleId = null;
		public string possible_destinations = "";
		public bool admin_controlled = false;
		public bool no_destination_swap = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_screen = "shuttle";
			this.icon_keyboard = "tech_key";
			this.req_access = new ByTable();
			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_Shuttle);
		}

		// Function from file: computer.dm
		public Obj_Machinery_Computer_Shuttle ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( C is Obj_Item_Weapon_Circuitboard_Shuttle ) {
				this.possible_destinations = C.possible_destinations;
				this.shuttleId = C.shuttleId;
			}
			return;
		}

		// Function from file: computer.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( !Lang13.Bool( this.emagged ) ) {
				this.req_access = new ByTable();
				this.emagged = 1;
				user.WriteMsg( "<span class='notice'>You fried the consoles ID checking system.</span>" );
			}
			return false;
		}

		// Function from file: computer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Obj_DockingPort_Mobile M = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( !this.allowed( Task13.User ) ) {
				Task13.User.WriteMsg( "<span class='danger'>Access denied.</span>" );
				return null;
			}

			if ( Lang13.Bool( href_list["move"] ) ) {
				M = GlobalVars.SSshuttle.getShuttle( this.shuttleId );

				if ( M.launch_status == 1 ) {
					Task13.User.WriteMsg( "<span class='warning'>You've already escaped. Never going back to that place again!</span>" );
					return null;
				}

				if ( this.no_destination_swap ) {
					
					if ( M.mode != 0 ) {
						Task13.User.WriteMsg( "<span class='warning'>Shuttle already in transit.</span>" );
						return null;
					}
				}

				switch ((int)( GlobalVars.SSshuttle.moveShuttle( this.shuttleId, href_list["move"], 1 ) )) {
					case 0:
						Task13.User.WriteMsg( "<span class='notice'>Shuttle received message and will be sent shortly.</span>" );
						break;
					case 1:
						Task13.User.WriteMsg( "<span class='warning'>Invalid shuttle requested.</span>" );
						break;
					default:
						Task13.User.WriteMsg( "<span class='notice'>Unable to comply.</span>" );
						break;
				}
			}
			return null;
		}

		// Function from file: computer.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			ByTable options = null;
			Obj_DockingPort_Mobile M = null;
			string dat = null;
			bool destination_found = false;
			Obj_DockingPort_Stationary S = null;
			Browser popup = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			this.add_fingerprint( Task13.User );
			options = String13.ParseUrlParams( this.possible_destinations );
			M = GlobalVars.SSshuttle.getShuttle( this.shuttleId );
			dat = "Status: " + ( M != null ? M.getStatusText() : "*Missing*" ) + "<br><br>";

			if ( M != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.SSshuttle.stationary, typeof(Obj_DockingPort_Stationary) )) {
					S = _a;
					

					if ( !( options.Find( S.id ) != 0 ) ) {
						continue;
					}

					if ( M.canDock( S ) != 0 ) {
						continue;
					}
					destination_found = true;
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";move=" ).item( S.id ).str( "'>Send to " ).item( S.name ).str( "</A><br>" ).ToString();
				}

				if ( !destination_found ) {
					dat += "<B>Shuttle Locked</B><br>";

					if ( this.admin_controlled ) {
						dat += "Authorized personnel only<br>";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";request=1]'>Request Authorization</A><br>" ).ToString();
					}
				}
			}
			dat += new Txt( "<a href='?src=" ).Ref( a ).str( ";mach_close=computer'>Close</a>" ).ToString();
			popup = new Browser( a, "computer", ( M != null ? M.name : "shuttle" ), 300, 200 );
			popup.set_content( "<center>" + dat + "</center>" );
			popup.set_title_image( Task13.User.browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			return null;
		}

	}

}