// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Media_Transmitter_Broadcast : Obj_Machinery_Media_Transmitter {

		public bool on = false;
		public int integrity = 100;
		public ByTable sources = new ByTable();
		public int heating_power = 40000;
		public ByTable autolink = null;
		public Wires_Transmitter wires = null;
		public PowerConnection_Consumer_Cable power_connection = null;
		public int RADS_PER_TICK = 150;
		public int MAX_TEMP = 70;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.light_color = "#6496FA";
			this.use_power = 0;
			this.anchored = 1;
			this.idle_power_usage = 50;
			this.active_power_usage = 1000;
			this.machine_flags = 154;
			this.icon = "icons/obj/machines/broadcast.dmi";
			this.icon_state = "broadcaster";
		}

		// Function from file: broadcast.dm
		public Obj_Machinery_Media_Transmitter_Broadcast ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.wires = new Wires_Transmitter( this );
			this.power_connection = new PowerConnection_Consumer_Cable( this, 2 );
			this.power_connection.idle_usage = this.idle_power_usage;
			this.power_connection.active_usage = this.active_power_usage;
			return;
		}

		// Function from file: broadcast.dm
		public override bool? isLinkedWith( Base_Data O = null ) {
			Interface13.Stat( null, this.sources.Contains( O ) );
			return null;
		}

		// Function from file: broadcast.dm
		public override bool canLink( Base_Data O = null, ByTable context = null ) {
			return O is Obj_Machinery_Media && !GlobalFuncs.is_type_in_list( O, new ByTable(new object [] { typeof(Obj_Machinery_Media_Transmitter), typeof(Obj_Machinery_Media_Receiver) }) );
		}

		// Function from file: broadcast.dm
		public override bool unlinkFrom( Mob user = null, Base_Data buffer = null ) {
			Interface13.Stat( null, this.sources.Contains( buffer ) );

			if ( false ) {
				this.unhook_media_sources();
				this.sources.Remove( buffer );

				if ( this.sources.len != 0 ) {
					this.hook_media_sources();
				}
				this.update_icon();
			}
			return false;
		}

		// Function from file: broadcast.dm
		public override bool linkWith( Mob user = null, Base_Data buffer = null, ByTable context = null ) {
			
			if ( buffer is Obj_Machinery_Media && !GlobalFuncs.is_type_in_list( buffer, new ByTable(new object [] { typeof(Obj_Machinery_Media_Transmitter), typeof(Obj_Machinery_Media_Receiver) }) ) ) {
				
				if ( this.sources.len != 0 ) {
					this.unhook_media_sources();
				}
				this.sources.Add( buffer );
				this.hook_media_sources();
				this.update_icon();
				return true;
			}
			return false;
		}

		// Function from file: broadcast.dm
		public override dynamic process(  ) {
			Mob_Living_Carbon M = null;
			double rads = 0;
			Ent_Static L = null;
			GasMixture env = null;
			dynamic transfer_moles = null;
			GasMixture removed = null;
			int heat_capacity = 0;
			GasMixture environment = null;

			
			if ( ( this.stat & 3 ) != 0 || this.wires.IsIndexCut( GlobalVars.TRANS_POWER ) != 0 ) {
				return null;
			}

			if ( this.on && Lang13.Bool( this.anchored ) ) {
				
				if ( this.integrity <= 0 || this.count_rad_wires() == 0 ) {
					this.on = false;
					this.update_on();
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( 3, this ), typeof(Mob_Living_Carbon) )) {
					M = _a;
					
					rads = Math.Sqrt( 1 / ( Map13.GetDistance( M, this ) + 1 ) ) * 150;

					if ( M is Mob_Living_Carbon_Human ) {
						M.apply_effect( rads * this.count_rad_wires(), "irradiate" );
					} else {
						M.radiation += rads;
					}
				}
				L = this.loc;

				if ( L is Tile_Simulated && this.heating_power != 0 ) {
					env = L.return_air();

					if ( env.temperature != 343.41 ) {
						transfer_moles = env.f_total_moles() * 0.25;
						removed = env.remove( transfer_moles );

						if ( removed != null ) {
							heat_capacity = removed.heat_capacity();

							if ( heat_capacity != 0 ) {
								
								if ( ( removed.temperature ??0) < 343.41 ) {
									removed.temperature = Num13.MinInt( ((int)( ( removed.temperature ??0) + this.heating_power / heat_capacity )), 1000 );
								} else {
									removed.temperature = Num13.MaxInt( ((int)( ( removed.temperature ??0) - this.heating_power / heat_capacity )), ((int)( 2.73 )) );
								}
							}
						}
						env.merge( removed );
					}
				}
				environment = this.loc.return_air();

				dynamic _b = environment.temperature; // Was a switch-case, sorry for the mess.
				if ( 273.41<=_b&&_b<=313.41 ) {
					this.integrity = ( this.integrity <= 0 ? 0 : ( this.integrity >= 100 ? 100 : this.integrity ) );
				} else if ( 313.41<=_b&&_b<=Double.PositiveInfinity ) {
					this.integrity = Num13.MaxInt( 0, this.integrity - 1 );
				}
			}
			return null;
		}

		// Function from file: broadcast.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic newfreq = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Interface13.Stat( null, href_list.Contains( "power" ) );

			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				
				if ( !( this.power_connection.powernet != null ) ) {
					this.power_connection.connect();
				}

				if ( !this.power_connection.powered() ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This machine needs to be hooked up to a powered cable.</span>" );
					return null;
				}
				this.on = !this.on;
				this.update_on();
				return null;
			}
			Interface13.Stat( null, href_list.Contains( "set_freq" ) );

			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				newfreq = this.media_frequency;

				if ( href_list["set_freq"] != "-1" ) {
					newfreq = String13.ParseNumber( href_list["set_freq"] );
				} else {
					newfreq = Interface13.Input( Task13.User, "Set a new frequency (MHz, 90.0, 200.0).", this, this.media_frequency, null, InputType.Num | InputType.Null );
				}

				if ( Lang13.Bool( newfreq ) ) {
					
					if ( String13.FindIgnoreCase( String13.NumberToString( Convert.ToDouble( newfreq ) ), ".", 1, 0 ) != 0 ) {
						newfreq *= 10;
					}

					if ( Convert.ToDouble( newfreq ) > 900 && Convert.ToDouble( newfreq ) < 2000 ) {
						this.disconnect_frequency();
						this.media_frequency = newfreq;
						this.connect_frequency();
					} else {
						GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Invalid FM frequency. (90.0, 200.0)</span>" );
					}
				}
			}
			return null;
		}

		// Function from file: broadcast.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.overlays = 0;

			if ( ( this.stat & 3 ) != 0 || this.wires.IsIndexCut( GlobalVars.TRANS_POWER ) != 0 ) {
				return null;
			}

			if ( this.on ) {
				this.overlays.Add( "broadcaster on" );
				this.set_light( 3 );
				this.use_power = 2;
			} else {
				this.set_light( 1 );
				this.use_power = 1;
			}

			if ( this.sources.len != 0 ) {
				this.overlays.Add( "broadcaster linked" );
			}
			return null;
		}

		// Function from file: broadcast.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return null;
			}
			this.cable_power_change();
			base.emp_act( severity );
			return null;
		}

		// Function from file: broadcast.dm
		public override string multitool_menu( dynamic user = null, dynamic P = null ) {
			string screen = null;
			int? i = null;
			dynamic source = null;

			
			if ( !( user is Mob_Living_Silicon ) ) {
				
				if ( !( ((Mob)user).get_active_hand() is Obj_Item_Device_Multitool ) ) {
					return null;
				}
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			screen = new Txt( "\n	<h2>Settings</h2>\n	<ul>\n		<li><b>Power:</b> <a href=\"?src=" ).Ref( this ).str( ";power=1\">" ).item( ( this.on ? "On" : "Off" ) ).str( "</a></li>\n		<li><b>Frequency:</b> <a href=\"?src=" ).Ref( this ).str( ";set_freq=-1\">" ).item( GlobalFuncs.format_frequency( this.media_frequency ) ).str( " GHz</a> (<a href=\"?src=" ).Ref( this ).str( ";set_freq=" ).item( Lang13.Initial( this, "media_frequency" ) ).str( "\">Reset</a>)</li>\n	</ul>\n	<h2>Media Sources</h2>" ).ToString();

			if ( !( this.sources.len != 0 ) ) {
				screen += "<em>No media sources have been selected.</em>";
			} else {
				screen += "<ol>";
				i = null;
				i = 1;

				while (( i ??0) <= this.sources.len) {
					source = this.sources[i];
					screen += new Txt( "<li>" ).Ref( source ).str( " " ).item( source.name ).str( " (" ).item( source.id_tag ).str( ")  <a href='?src=" ).Ref( this ).str( ";unlink=" ).item( i ).str( "'>[X]</a></li>" ).ToString();
					i++;
				}
				screen += "</ol>";
			}
			return screen;
		}

		// Function from file: broadcast.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			
			if ( this.panel_open ) {
				this.wires.Interact( a );
			}
			_default = base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			return _default;
		}

		// Function from file: broadcast.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			this.attack_hand( user );
			return null;
		}

		// Function from file: broadcast.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			dynamic S = null;

			_default = base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( this.panel_open && ( a is Obj_Item_Device_Multitool || a is Obj_Item_Weapon_Wirecutters ) ) {
				this.attack_hand( b );
			}

			if ( a is Obj_Item_Weapon_Solder ) {
				
				if ( this.integrity >= 100 ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + this + " doesn't need to be repaired!</span>" );
					return _default;
				}
				S = a;

				if ( !Lang13.Bool( S.remove_fuel( 4, b ) ) ) {
					return _default;
				}
				GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 100, 1 );

				if ( GlobalFuncs.do_after( b, this, 40 ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 100, 1 );
					this.integrity = 100;
					GlobalFuncs.to_chat( b, "<span class='notice'>You repair the blown fuses on " + this + ".</span>" );
				}
			}
			return _default;
		}

		// Function from file: broadcast.dm
		public override int wrenchAnchor( dynamic user = null ) {
			
			if ( base.wrenchAnchor( (object)(user) ) != 0 ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.power_connection.connect();
				} else {
					this.power_connection.disconnect();
					this.on = false;
					this.update_on();
				}
				return 1;
			}
			return 0;
		}

		// Function from file: broadcast.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			Obj_Machinery_Media source = null;

			
			if ( this.autolink != null && this.autolink.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this, 20 ), typeof(Obj_Machinery_Media) )) {
					source = _a;
					
					Interface13.Stat( null, this.autolink.Contains( source.id_tag ) );

					if ( source is Obj_Machinery_Media ) {
						this.sources.Add( source );
						Game13.log.WriteMsg( "## TESTING: " + ( "Autolinked " + source + " -> " + this ) );
					}
				}
				this.hook_media_sources();
			}

			if ( this.on ) {
				this.update_on();
			}
			this.power_connection.power_changed.Add( this, "cable_power_change" );
			this.power_connection.connect();
			this.update_icon();
			return false;
		}

		// Function from file: broadcast.dm
		public int count_rad_wires(  ) {
			return ( !( this.wires.IsIndexCut( GlobalVars.TRANS_RAD_ONE ) != 0 ) ?1:0) + ( !( this.wires.IsIndexCut( GlobalVars.TRANS_RAD_TWO ) != 0 ) ?1:0);
		}

		// Function from file: broadcast.dm
		public void update_on(  ) {
			
			if ( this.on ) {
				this.visible_message( new Txt().The( this ).item().str( " hums as it begins pumping energy into the air!" ).ToString() );
				this.connect_frequency();
				this.hook_media_sources();
			} else {
				this.visible_message( new Txt().The( this ).item().str( " falls quiet and makes a soft ticking noise as it cools down." ).ToString() );
				this.unhook_media_sources();
				this.disconnect_frequency();
			}
			this.update_icon();
			return;
		}

		// Function from file: broadcast.dm
		public void unhook_media_sources(  ) {
			Obj_Machinery_Media source = null;

			
			if ( !( this.sources.len != 0 ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.sources, typeof(Obj_Machinery_Media) )) {
				source = _a;
				
				source.unhookMediaOutput( this );
			}
			this.broadcast();
			return;
		}

		// Function from file: broadcast.dm
		public void hook_media_sources(  ) {
			Obj_Machinery_Media source = null;

			
			if ( !( this.sources.len != 0 ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.sources, typeof(Obj_Machinery_Media) )) {
				source = _a;
				
				source.hookMediaOutput( this, true );
				source.update_music();
			}
			return;
		}

		// Function from file: broadcast.dm
		public void cable_power_change( dynamic args = null ) {
			
			if ( this.power_connection.powered() ) {
				this.stat &= 65533;
			} else {
				this.stat |= 2;
			}
			this.update_icon();
			return;
		}

		// Function from file: broadcast.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.wires != null ) {
				GlobalFuncs.qdel( this.wires );
				this.wires = null;
			}

			if ( this.power_connection != null ) {
				GlobalFuncs.qdel( this.power_connection );
				this.power_connection = null;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}