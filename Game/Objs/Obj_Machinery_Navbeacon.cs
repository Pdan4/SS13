// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Navbeacon : Obj_Machinery {

		public bool locked = true;
		public dynamic freq = 1445;
		public string location = "";
		public ByTable codes = null;
		public string codes_txt = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.level = 1;
			this.anchored = 1;
			this.req_access = new ByTable(new object [] { 10 });
			this.machine_flags = 2;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "navbeacon0-f";
			this.layer = 2.5;
		}

		// Function from file: navbeacon.dm
		public Obj_Machinery_Navbeacon ( dynamic loc = null ) : base( (object)(loc) ) {
			Ent_Static T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.set_codes();
			T = this.loc;
			this.hide( Lang13.BoolNullable( ((dynamic)T).intact ) );
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				if ( GlobalVars.radio_controller != null ) {
					GlobalVars.radio_controller.add_object( this, this.freq, GlobalVars.RADIO_NAVBEACONS );
				}
				return;
			}));
			return;
		}

		// Function from file: navbeacon.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			string newloc = null;
			dynamic codekey = null;
			dynamic newkey = null;
			dynamic codeval = null;
			dynamic newval = null;
			dynamic codekey2 = null;
			dynamic newkey2 = null;
			dynamic newval2 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			} else if ( this.panel_open && !this.locked ) {
				Task13.User.set_machine( this );

				if ( Lang13.Bool( href_list["freq"] ) ) {
					this.freq = GlobalFuncs.sanitize_frequency( this.freq + String13.ParseNumber( href_list["freq"] ) );
					this.updateDialog();
				} else if ( Lang13.Bool( href_list["locedit"] ) ) {
					newloc = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter New Location", "Navigation Beacon", this.location, null, null, InputType.Str | InputType.Null ) ), 1, 1024 );

					if ( Lang13.Bool( newloc ) ) {
						this.location = newloc;
						this.updateDialog();
					}
				} else if ( Lang13.Bool( href_list["edit"] ) ) {
					codekey = href_list["code"];
					newkey = Interface13.Input( "Enter Transponder Code Key", "Navigation Beacon", codekey, null, null, InputType.Str | InputType.Null );

					if ( !Lang13.Bool( newkey ) ) {
						return null;
					}
					codeval = this.codes[codekey];
					newval = Interface13.Input( "Enter Transponder Code Value", "Navigation Beacon", codeval, null, null, InputType.Str | InputType.Null );

					if ( !Lang13.Bool( newval ) ) {
						newval = codekey;
						return null;
					}
					this.codes.Remove( codekey );
					this.codes[newkey] = newval;
					this.updateDialog();
				} else if ( Lang13.Bool( href_list["delete"] ) ) {
					codekey2 = href_list["code"];
					this.codes.Remove( codekey2 );
					this.updateDialog();
				} else if ( Lang13.Bool( href_list["add"] ) ) {
					newkey2 = Interface13.Input( "Enter New Transponder Code Key", "Navigation Beacon", null, null, null, InputType.Str | InputType.Null );

					if ( !Lang13.Bool( newkey2 ) ) {
						return null;
					}
					newval2 = Interface13.Input( "Enter New Transponder Code Value", "Navigation Beacon", null, null, null, InputType.Str | InputType.Null );

					if ( !Lang13.Bool( newval2 ) ) {
						newval2 = "1";
						return null;
					}

					if ( !( this.codes != null ) ) {
						this.codes = new ByTable();
					}
					this.codes[newkey2] = newval2;
					this.updateDialog();
				}
			}
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			flag1 = flag1 ?? false;

			Ent_Static T = null;
			string t = null;
			dynamic key = null;
			dynamic key2 = null;

			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				return null;
			}

			if ( !this.panel_open && !( flag1 == true ) ) {
				GlobalFuncs.to_chat( user, "The beacon's control cover is closed." );
				return null;
			}

			if ( this.locked && !( flag1 == true ) ) {
				t = "<TT><B>Navigation Beacon</B><HR><BR>\n<i>(swipe card to unlock controls)</i><BR>\nFrequency: " + GlobalFuncs.format_frequency( this.freq ) + "<BR><HR>\nLocation: " + ( Lang13.Bool( this.location ) ? this.location : "(none)" ) + "</A><BR>\nTransponder Codes:<UL>";

				foreach (dynamic _a in Lang13.Enumerate( this.codes )) {
					key = _a;
					
					t += "<LI>" + key + " ... " + this.codes[key];
				}
				t += "<UL></TT>";
			} else {
				t = new Txt( "<TT><B>Navigation Beacon</B><HR><BR>\n<i>(swipe card to lock controls)</i><BR>\nFrequency:\n<A href='byond://?src=" ).Ref( this ).str( ";freq=-10'>-</A>\n<A href='byond://?src=" ).Ref( this ).str( ";freq=-2'>-</A>\n" ).item( GlobalFuncs.format_frequency( this.freq ) ).str( "\n<A href='byond://?src=" ).Ref( this ).str( ";freq=2'>+</A>\n<A href='byond://?src=" ).Ref( this ).str( ";freq=10'>+</A><BR>\n<HR>\nLocation: <A href='byond://?src=" ).Ref( this ).str( ";locedit=1'>" ).item( ( Lang13.Bool( this.location ) ? this.location : "(none)" ) ).str( "</A><BR>\nTransponder Codes:<UL>" ).ToString();

				foreach (dynamic _b in Lang13.Enumerate( this.codes )) {
					key2 = _b;
					
					t += new Txt( "<LI>" ).item( key2 ).str( " ... " ).item( this.codes[key2] ).str( "\n					<small><A href='byond://?src=" ).Ref( this ).str( ";edit=1;code=" ).item( key2 ).str( "'>(edit)</A>\n					<A href='byond://?src=" ).Ref( this ).str( ";delete=1;code=" ).item( key2 ).str( "'>(delete)</A></small><BR>" ).ToString();
					t += "<LI>" + key2 + " ... " + this.codes[key2];
				}
				t += new Txt( "<small><A href='byond://?src=" ).Ref( this ).str( ";add=1;'>(add new)</A></small><BR>\n				<UL></TT>" ).ToString();
			}
			Interface13.Browse( user, t, "window=navbeacon" );
			GlobalFuncs.onclose( user, "navbeacon" );
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.interact( a, false );
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			this.interact( user, true );
			return null;
		}

		// Function from file: navbeacon.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Ent_Static T = null;

			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				return null;
			}

			if ( Lang13.Bool( base.attackby( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			} else if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( this.panel_open ) {
					
					if ( this.allowed( b ) ) {
						this.locked = !this.locked;
						GlobalFuncs.to_chat( b, "Controls are now " + ( this.locked ? "locked." : "unlocked." ) );
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>Access denied.</span>" );
					}
					this.updateDialog();
				} else {
					GlobalFuncs.to_chat( b, "You must open the cover first!" );
				}
			}
			return null;
		}

		// Function from file: navbeacon.dm
		public override bool receive_signal( Game_Data signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			string request = null;

			request = ((dynamic)signal).data["findbeacon"];

			if ( Lang13.Bool( request ) && ( false || request == "any" || request == this.location ) ) {
				Task13.Schedule( 1, (Task13.Closure)(() => {
					this.post_signal();
					return;
				}));
			}
			return false;
		}

		// Function from file: navbeacon.dm
		public override void hide( bool? h = null ) {
			this.invisibility = ( h == true ? 101 : 0 );
			this.updateicon();
			return;
		}

		// Function from file: navbeacon.dm
		public void post_signal(  ) {
			dynamic frequency = null;
			Game_Data signal = null;
			dynamic key = null;

			frequency = GlobalVars.radio_controller.return_frequency( this.freq );

			if ( !Lang13.Bool( frequency ) ) {
				return;
			}
			signal = GlobalFuncs.getFromPool( typeof(Signal) );
			((dynamic)signal).source = this;
			((dynamic)signal).transmission_method = 1;
			((dynamic)signal).data["beacon"] = this.location;

			foreach (dynamic _a in Lang13.Enumerate( this.codes )) {
				key = _a;
				
				((dynamic)signal).data[key] = this.codes[key];
			}
			new ByTable().Set( 1, this ).Set( 2, signal ).Set( "filter", GlobalVars.RADIO_NAVBEACONS ).Apply( Lang13.BindFunc( frequency, "post_signal" ) );
			return;
		}

		// Function from file: navbeacon.dm
		public void updateicon(  ) {
			string state = null;

			state = "navbeacon" + this.panel_open;

			if ( this.invisibility != 0 ) {
				this.icon_state = "" + state + "-f";
			} else {
				this.icon_state = "" + state;
			}
			return;
		}

		// Function from file: navbeacon.dm
		public void set_codes(  ) {
			ByTable entries = null;
			dynamic e = null;
			int index = 0;
			string key = null;
			string val = null;

			
			if ( !Lang13.Bool( this.codes_txt ) ) {
				return;
			}
			this.codes = new ByTable();
			entries = GlobalFuncs.text2list( this.codes_txt, ";" );

			foreach (dynamic _a in Lang13.Enumerate( entries )) {
				e = _a;
				
				index = String13.FindIgnoreCase( e, "=", 1, 0 );

				if ( index != 0 ) {
					key = String13.SubStr( e, 1, index );
					val = String13.SubStr( e, index + 1, 0 );
					this.codes[key] = val;
				} else {
					this.codes[e] = "1";
				}
			}
			return;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}