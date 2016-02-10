// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_GeneralAirControl_LargeTankControl : Obj_Machinery_Computer_GeneralAirControl {

		public dynamic input_tag = null;
		public dynamic output_tag = null;
		public dynamic input_info = null;
		public dynamic output_info = null;
		public ByTable input_linkable = new ByTable(new object [] { typeof(Obj_Machinery_Atmospherics_Unary_OutletInjector), typeof(Obj_Machinery_Atmospherics_Unary_VentPump) });
		public ByTable output_linkable = new ByTable(new object [] { typeof(Obj_Machinery_Atmospherics_Unary_VentPump) });
		public double? pressure_setting = 4559.625;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = "/obj/item/weapon/circuitboard/large_tank_control";
		}

		public Obj_Machinery_Computer_GeneralAirControl_LargeTankControl ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: atmo_control.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic response = null;
			double? oldpressure = null;
			Game_Data signal = null;
			dynamic new_rate = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["out_set_pressure"] ) ) {
				response = Interface13.Input( Task13.User, "Set new pressure, in kPa. [0-" + 5066.25 + "]", null, null, null, InputType.Num );
				oldpressure = this.pressure_setting;
				this.pressure_setting = String13.ParseNumber( response );
				this.pressure_setting = ( ( this.pressure_setting ??0) <= 0 ? 0 : ( ( this.pressure_setting ??0) >= 5066.25 ? 5066.25 : this.pressure_setting ) );
				this.investigation_log( "atmos", "'s output pressure set to " + this.pressure_setting + " from " + oldpressure + " by " + GlobalFuncs.key_name( Task13.User ) );
			}

			if ( !( this.radio_connection != null ) ) {
				return 0;
			}
			signal = GlobalFuncs.getFromPool( typeof(Signal) );
			((dynamic)signal).transmission_method = 1;
			((dynamic)signal).source = this;

			if ( Lang13.Bool( href_list["in_refresh_status"] ) ) {
				this.input_info = null;
				((dynamic)signal).data = new ByTable().Set( "tag", this.input_tag ).Set( 2, "status" );
			} else if ( Lang13.Bool( href_list["in_toggle_injector"] ) ) {
				this.input_info = null;
				((dynamic)signal).data = new ByTable().Set( "tag", this.input_tag ).Set( 2, "power_toggle" );
			} else if ( Lang13.Bool( href_list["in_set_rate"] ) ) {
				this.input_info = null;
				new_rate = Interface13.Input( "Enter the new volume rate of the injector:", "Injector Rate", null, null, null, InputType.Num );
				new_rate = String13.ParseNumber( new_rate );
				new_rate = ( Convert.ToDouble( new_rate ) <= 0 ? ((dynamic)( 0 )) : ( Convert.ToDouble( new_rate ) >= Convert.ToDouble( new_rate ) ? new_rate : new_rate ) );
				((dynamic)signal).data = new ByTable().Set( "tag", this.input_tag ).Set( "set_volume_rate", new_rate );
			} else if ( Lang13.Bool( href_list["out_refresh_status"] ) ) {
				this.output_info = null;
				((dynamic)signal).data = new ByTable().Set( "tag", this.output_tag ).Set( 2, "status" );
			} else if ( Lang13.Bool( href_list["out_toggle_power"] ) ) {
				this.output_info = null;
				((dynamic)signal).data = new ByTable().Set( "tag", this.output_tag ).Set( 2, "power_toggle" ).Set( "direction", 0 ).Set( "checks", 2 );
			} else if ( Lang13.Bool( href_list["out_set_pressure"] ) ) {
				this.output_info = null;
				((dynamic)signal).data = new ByTable().Set( "tag", this.output_tag ).Set( "set_internal_pressure", "" + this.pressure_setting );
			}
			((dynamic)signal).data["sigtype"] = "command";
			this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_ATMOSIA );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: atmo_control.dm
		public void send_signal( ByTable data = null ) {
			Game_Data signal = null;

			signal = GlobalFuncs.getFromPool( typeof(Signal) );
			((dynamic)signal).transmission_method = 1;
			((dynamic)signal).source = this;
			((dynamic)signal).data = data;
			((dynamic)signal).data["sigtype"] = "command";
			this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_ATMOSIA );
			return;
		}

		// Function from file: atmo_control.dm
		public void request_device_refresh( dynamic device = null ) {
			this.send_signal( new ByTable().Set( "tag", device ).Set( 2, "status" ) );
			return;
		}

		// Function from file: atmo_control.dm
		public override bool receive_signal( Game_Data signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			dynamic id_tag = null;

			
			if ( !( signal != null ) || Lang13.Bool( ((dynamic)signal).encryption ) ) {
				return false;
			}
			id_tag = ((dynamic)signal).data["tag"];

			if ( this.input_tag == id_tag ) {
				this.input_info = ((dynamic)signal).data;
				this.updateUsrDialog();
			} else if ( this.output_tag == id_tag ) {
				this.output_info = ((dynamic)signal).data;
				this.updateUsrDialog();
			} else {
				base.receive_signal( signal, receive_method, (object)(receive_param) );
			}
			return false;
		}

		// Function from file: atmo_control.dm
		public override string return_text(  ) {
			string output = null;
			dynamic power = null;
			dynamic volume_rate = null;
			dynamic power2 = null;
			dynamic output_pressure = null;

			output = base.return_text();
			output += "<h2>Tank Control System</h2><BR>";

			if ( Lang13.Bool( this.input_tag ) ) {
				
				if ( Lang13.Bool( this.input_info ) ) {
					power = this.input_info["power"];
					volume_rate = this.input_info["volume_rate"];
					output += new Txt( "\n<fieldset>\n<legend>Input (<A href='?src=" ).Ref( this ).str( @";in_refresh_status=1'>Refresh</A>)</legend>
<table>
<tr>
	<th>State:</th>
	<td><A href='?src=" ).Ref( this ).str( ";in_toggle_injector=1'>" ).item( ( Lang13.Bool( power ) ? "Injecting" : "On Hold" ) ).str( @"</A></td>
</tr>
<tr>
	<th>Rate:</th>
	<td><a href=""?src=" ).Ref( this ).str( ";in_set_rate=1\">" ).item( volume_rate ).str( @"</a> L/sec</td>
</tr>
</table>
</fieldset>
" ).ToString();
				} else {
					output += new Txt( "<FONT color='red'>ERROR: Can not find input port</FONT> <A href='?src=" ).Ref( this ).str( ";in_refresh_status=1'>Search</A><BR>" ).ToString();
				}
			}

			if ( Lang13.Bool( this.output_tag ) ) {
				
				if ( Lang13.Bool( this.output_info ) ) {
					power2 = this.output_info["power"];
					output_pressure = this.output_info["internal"];
					output += new Txt( "\n<fieldset>\n<legend>Output (<A href='?src=" ).Ref( this ).str( @";out_refresh_status=1'>Refresh</A>)</legend>
<table>
<tr>
	<th>State:</th>
	<td><A href='?src=" ).Ref( this ).str( ";out_toggle_power=1'>" ).item( ( Lang13.Bool( power2 ) ? "Open" : "On Hold" ) ).str( @"</A></td>
</tr>
<tr>
	<th>Max Output Pressure:</th>
	<td><A href='?src=" ).Ref( this ).str( ";out_set_pressure=1'>" ).item( output_pressure ).str( @"</A> kPa</td>
</tr>
</table>
</fieldset>
" ).ToString();
				} else {
					output += new Txt( "<FONT color='red'>ERROR: Can not find output port</FONT> <A href='?src=" ).Ref( this ).str( ";out_refresh_status=1'>Search</A><BR>" ).ToString();
				}
			}
			return output;
		}

		// Function from file: atmo_control.dm
		public override dynamic process(  ) {
			base.process();

			if ( !Lang13.Bool( this.input_info ) && Lang13.Bool( this.input_tag ) ) {
				this.request_device_refresh( this.input_tag );
			}

			if ( !Lang13.Bool( this.output_info ) && Lang13.Bool( this.output_tag ) ) {
				this.request_device_refresh( this.output_tag );
			}
			return null;
		}

		// Function from file: atmo_control.dm
		public override bool? isLinkedWith( Base_Data O = null ) {
			
			if ( ((dynamic)O).id_tag == this.input_tag ) {
				return true;
			}

			if ( ((dynamic)O).id_tag == this.output_tag ) {
				return true;
			}
			return false;
		}

		// Function from file: atmo_control.dm
		public override bool canLink( Base_Data O = null, ByTable context = null ) {
			return context["slot"] == "input" && GlobalFuncs.is_type_in_list( O, this.input_linkable ) || context["slot"] == "output" && GlobalFuncs.is_type_in_list( O, this.output_linkable );
		}

		// Function from file: atmo_control.dm
		public override string linkMenu( Base_Data O = null ) {
			string dat = null;

			dat = "";

			if ( this.canLink( O, new ByTable().Set( "slot", "input" ) ) ) {
				dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";link=1;slot=input'>[Link @ Input]</a> " ).ToString();
			}

			if ( this.canLink( O, new ByTable().Set( "slot", "output" ) ) ) {
				dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";link=1;slot=output'>[Link @ Output]</a> " ).ToString();
			}
			return dat;
		}

		// Function from file: atmo_control.dm
		public override bool unlinkFrom( Mob user = null, Base_Data buffer = null ) {
			Interface13.Stat( null, buffer.vars.Contains( "id_tag" ) );

			if ( false ) {
				
				if ( ((dynamic)buffer).id_tag == this.input_tag ) {
					this.input_tag = null;
					this.input_info = null;
					return true;
				}

				if ( ((dynamic)buffer).id_tag == this.output_tag ) {
					this.output_tag = null;
					this.output_info = null;
					return true;
				}
			}
			return false;
		}

		// Function from file: atmo_control.dm
		public override bool linkWith( Mob user = null, Base_Data buffer = null, ByTable context = null ) {
			
			if ( context["slot"] == "input" && GlobalFuncs.is_type_in_list( buffer, this.input_linkable ) ) {
				this.input_tag = ((dynamic)buffer).id_tag;
				this.input_info = null;

				if ( buffer is Obj_Machinery_Atmospherics_Unary_VentPump ) {
					this.send_signal( new ByTable().Set( "tag", this.input_tag ).Set( "direction", 1 ).Set( "checks", 0 ) );
				}
				return true;
			}

			if ( context["slot"] == "output" && GlobalFuncs.is_type_in_list( buffer, this.output_linkable ) ) {
				this.output_tag = ((dynamic)buffer).id_tag;
				this.output_info = null;

				if ( buffer is Obj_Machinery_Atmospherics_Unary_VentPump ) {
					this.send_signal( new ByTable().Set( "tag", this.output_tag ).Set( "direction", 0 ).Set( "checks", 2 ) );
				}
				return true;
			}
			return false;
		}

		// Function from file: atmo_control.dm
		public override string multitool_menu( dynamic user = null, dynamic P = null ) {
			string dat = null;
			dynamic id_tag = null;

			dat = new Txt( "\n	<ul>\n		<li><b>Frequency:</b> <a href=\"?src=" ).Ref( this ).str( ";set_freq=-1\">" ).item( GlobalFuncs.format_frequency( this.frequency ) ).str( " GHz</a> (<a href=\"?src=" ).Ref( this ).str( ";set_freq=" ).item( Lang13.Initial( this, "frequency" ) ).str( "\">Reset</a>)</li>\n		<li>" ).item( this.format_tag( "Input", "input_tag" ) ).str( "</li>\n		<li>" ).item( this.format_tag( "Output", "output_tag" ) ).str( "</li>\n	</ul>\n	<b>Sensors:</b>\n	<ul>" ).ToString();

			foreach (dynamic _a in Lang13.Enumerate( this.sensors )) {
				id_tag = _a;
				
				dat += new Txt( "<li><a href=\"?src=" ).Ref( this ).str( ";edit_sensor=" ).item( id_tag ).str( "\">" ).item( this.sensors[id_tag] ).str( "</a></li>" ).ToString();
			}
			dat += new Txt( "<li><a href=\"?src=" ).Ref( this ).str( ";add_sensor=1\">[+]</a></li></ul>" ).ToString();
			return dat;
		}

	}

}