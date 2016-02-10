// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_SpecopsShuttle : Obj_Machinery_Computer {

		public dynamic temp = null;
		public bool hacked = false;
		public bool allowedtocall = false;
		public int specops_shuttle_timereset = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 103, 110 });
			this.light_color = "#7DE1E1";
			this.icon_state = "shuttle";
		}

		public Obj_Machinery_Computer_SpecopsShuttle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: specops_shuttle.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic special_ops = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}

			if ( Task13.User.contents.Find( this ) != 0 || GlobalFuncs.in_range( this, Task13.User ) && this.loc is Tile || Task13.User is Mob_Living_Silicon ) {
				Task13.User.machine = this;
			}

			if ( Lang13.Bool( href_list["sendtodock"] ) ) {
				
				if ( !GlobalVars.specops_shuttle_at_station || GlobalVars.specops_shuttle_moving_to_station || GlobalVars.specops_shuttle_moving_to_centcom ) {
					return null;
				}

				if ( !GlobalFuncs.specops_can_move() ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='notice'>Central Command will not allow the Special Operations shuttle to return yet.</span>" );

					if ( Game13.timeofday <= this.specops_shuttle_timereset ) {
						
						if ( ( Game13.timeofday - this.specops_shuttle_timereset ) / 10 > 60 ) {
							GlobalFuncs.to_chat( Task13.User, "<span class='notice'>" + -( ( Game13.timeofday - this.specops_shuttle_timereset ) / 10 ) / 60 + " minutes remain!</span>" );
						}
						GlobalFuncs.to_chat( Task13.User, "<span class='notice'>" + -( Game13.timeofday - this.specops_shuttle_timereset ) / 10 + " seconds remain!</span>" );
					}
					return null;
				}
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>The Special Operations shuttle will arrive at Central Command in " + 60 + " seconds.</span>" );
				this.temp += new Txt( "Shuttle departing.<BR><BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
				this.updateUsrDialog();
				GlobalVars.specops_shuttle_moving_to_centcom = true;
				GlobalVars.specops_shuttle_time = Game13.timeofday + 600;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.specops_return();
					return;
				}));
			} else if ( Lang13.Bool( href_list["sendtostation"] ) ) {
				
				if ( GlobalVars.specops_shuttle_at_station || GlobalVars.specops_shuttle_moving_to_station || GlobalVars.specops_shuttle_moving_to_centcom ) {
					return null;
				}

				if ( !GlobalFuncs.specops_can_move() ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The Special Operations shuttle is unable to leave.</span>" );
					return null;
				}
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>The Special Operations shuttle will arrive on " + GlobalVars.station_name + " in " + 60 + " seconds.</span>" );
				this.temp += new Txt( "Shuttle departing.<BR><BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
				this.updateUsrDialog();
				special_ops = Lang13.FindObj( typeof(Zone_Centcom_Specops) );

				if ( Lang13.Bool( special_ops ) ) {
					((Zone)special_ops).readyalert();
				}
				GlobalVars.specops_shuttle_moving_to_station = true;
				GlobalVars.specops_shuttle_time = Game13.timeofday + 600;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.specops_process();
					return;
				}));
			} else if ( Lang13.Bool( href_list["mainmenu"] ) ) {
				this.temp = null;
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: specops_shuttle.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic dat = null;

			
			if ( !this.allowed( a ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>Access Denied.</span>" );
				return null;
			}

			if ( !GlobalVars.sent_strike_team && !GlobalVars.send_emergency_team ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The strike team has not yet deployed.</span>" );
				return null;
			}

			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			a.machine = this;

			if ( Lang13.Bool( this.temp ) ) {
				dat = this.temp;
			} else {
				dat += new Txt( "<BR><B>Special Operations Shuttle</B><HR>\n		\nLocation: " ).item( ( GlobalVars.specops_shuttle_moving_to_station || GlobalVars.specops_shuttle_moving_to_centcom ? "Departing for " + GlobalVars.station_name + " in (" + GlobalVars.specops_shuttle_timeleft + " seconds.)" : ( GlobalVars.specops_shuttle_at_station ? "Station" : "Dock" ) ) ).str( "<BR>\n		" ).item( ( GlobalVars.specops_shuttle_moving_to_station || GlobalVars.specops_shuttle_moving_to_centcom ? "\n*The Special Ops. shuttle is already leaving.*<BR>\n<BR>" : ( GlobalVars.specops_shuttle_at_station ? new Txt( "\n<A href='?src=" ).Ref( this ).str( ";sendtodock=1'>Shuttle standing by...</A><BR>\n<BR>" ).ToString() : new Txt( "\n<A href='?src=" ).Ref( this ).str( ";sendtostation=1'>Depart to " ).item( GlobalVars.station_name ).str( "</A><BR>\n<BR>" ).ToString() ) ) ).str( "\n		\n<A href='?src=" ).Ref( a ).str( ";mach_close=computer'>Close</A>" ).ToString();
			}
			Interface13.Browse( a, dat, "window=computer;size=575x450" );
			GlobalFuncs.onclose( a, "computer" );
			return null;
		}

		// Function from file: specops_shuttle.dm
		public override int emag( dynamic user = null ) {
			GlobalFuncs.to_chat( user, "<span class='notice'>The electronic systems in this console are far too advanced for your primitive hacking peripherals.</span>" );
			return 0;
		}

		// Function from file: specops_shuttle.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: specops_shuttle.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

	}

}