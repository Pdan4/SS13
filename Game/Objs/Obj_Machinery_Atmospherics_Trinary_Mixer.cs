// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Trinary_Mixer : Obj_Machinery_Atmospherics_Trinary {

		public bool on = false;
		public double target_pressure = 101.32499694824219;
		public double node1_concentration = 0.5;
		public double node2_concentration = 0.5;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mirror = typeof(Obj_Machinery_Atmospherics_Trinary_Mixer_Mirrored);
			this.icon = "icons/obj/atmospherics/mixer.dmi";
			this.icon_state = "intact_off";
		}

		// Function from file: mixer.dm
		public Obj_Machinery_Atmospherics_Trinary_Mixer ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air3.volume = 300;
			return;
		}

		// Function from file: mixer.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic new_pressure = null;
			double? value = null;
			double? value2 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["power"] ) ) {
				this.on = !this.on;
			}

			if ( Lang13.Bool( href_list["set_press"] ) ) {
				new_pressure = Interface13.Input( Task13.User, "Enter new output pressure (0-4500kPa)", "Pressure control", this.target_pressure, null, InputType.Num );
				this.target_pressure = Num13.MaxInt( 0, Num13.MinInt( 4500, Convert.ToInt32( new_pressure ) ) );
			}

			if ( Lang13.Bool( href_list["node1_c"] ) ) {
				value = String13.ParseNumber( href_list["node1_c"] );
				this.node1_concentration = Num13.MaxInt( 0, Num13.MinInt( 1, ((int)( this.node1_concentration + ( value ??0) )) ) );
				this.node2_concentration = Num13.MaxInt( 0, Num13.MinInt( 1, ((int)( this.node2_concentration - ( value ??0) )) ) );
			}

			if ( Lang13.Bool( href_list["node2_c"] ) ) {
				value2 = String13.ParseNumber( href_list["node2_c"] );
				this.node2_concentration = Num13.MaxInt( 0, Num13.MinInt( 1, ((int)( this.node2_concentration + ( value2 ??0) )) ) );
				this.node1_concentration = Num13.MaxInt( 0, Num13.MinInt( 1, ((int)( this.node1_concentration - ( value2 ??0) )) ) );
			}
			this.update_icon();
			this.updateUsrDialog();
			return null;
		}

		// Function from file: mixer.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			this.add_fingerprint( Task13.User );

			if ( !this.allowed( a ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>Access denied.</span>" );
				return null;
			}
			Task13.User.set_machine( this );
			dat = new Txt( "<b>Power: </b><a href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</a><br>\n				<b>Desirable output pressure: </b>\n				" ).item( this.target_pressure ).str( "kPa | <a href='?src=" ).Ref( this ).str( ";set_press=1'>Change</a>\n				<br>\n				<b>Node 1 Concentration:</b>\n				<a href='?src=" ).Ref( this ).str( ";node1_c=-0.1'><b>-</b></a>\n				<a href='?src=" ).Ref( this ).str( ";node1_c=-0.01'>-</a>\n				" ).item( this.node1_concentration ).str( "(" ).item( this.node1_concentration * 100 ).str( "%)\n				<a href='?src=" ).Ref( this ).str( ";node1_c=0.01'><b>+</b></a>\n				<a href='?src=" ).Ref( this ).str( ";node1_c=0.1'>+</a>\n				<br>\n				<b>Node 2 Concentration:</b>\n				<a href='?src=" ).Ref( this ).str( ";node2_c=-0.1'><b>-</b></a>\n				<a href='?src=" ).Ref( this ).str( ";node2_c=-0.01'>-</a>\n				" ).item( this.node2_concentration ).str( "(" ).item( this.node2_concentration * 100 ).str( "%)\n				<a href='?src=" ).Ref( this ).str( ";node2_c=0.01'><b>+</b></a>\n				<a href='?src=" ).Ref( this ).str( ";node2_c=0.1'>+</a>\n				" ).ToString();
			Interface13.Browse( a, "<HEAD><TITLE>" + this.name + " control</TITLE></HEAD><TT>" + dat + "</TT>", "window=atmo_mixer" );
			GlobalFuncs.onclose( a, "atmo_mixer" );
			return null;
		}

		// Function from file: mixer.dm
		public override dynamic process(  ) {
			dynamic _default = null;

			dynamic output_starting_pressure = null;
			double pressure_delta = 0;
			double transfer_moles1 = 0;
			double transfer_moles2 = 0;
			dynamic air1_moles = null;
			dynamic air2_moles = null;
			int ratio = 0;
			GasMixture removed1 = null;
			GasMixture removed2 = null;

			_default = base.process();

			if ( !this.on ) {
				return _default;
			}
			output_starting_pressure = this.air3.return_pressure();

			if ( Convert.ToDouble( output_starting_pressure ) >= this.target_pressure ) {
				return _default;
			}
			pressure_delta = this.target_pressure - Convert.ToDouble( output_starting_pressure );
			transfer_moles1 = 0;
			transfer_moles2 = 0;

			if ( ( this.air1.temperature ??0) > 0 ) {
				transfer_moles1 = this.node1_concentration * pressure_delta * ( this.air3.volume ??0) / ( ( this.air1.temperature ??0) * 8.314 );
			}

			if ( ( this.air2.temperature ??0) > 0 ) {
				transfer_moles2 = this.node2_concentration * pressure_delta * ( this.air3.volume ??0) / ( ( this.air2.temperature ??0) * 8.314 );
			}
			air1_moles = this.air1.f_total_moles();
			air2_moles = this.air2.f_total_moles();

			if ( Convert.ToDouble( air1_moles ) < transfer_moles1 || Convert.ToDouble( air2_moles ) < transfer_moles2 ) {
				
				if ( !( transfer_moles1 != 0 ) || !( transfer_moles2 != 0 ) ) {
					return _default;
				}
				ratio = Num13.MinInt( Convert.ToInt32( air1_moles / transfer_moles1 ), Convert.ToInt32( air2_moles / transfer_moles2 ) );
				transfer_moles1 *= ratio;
				transfer_moles2 *= ratio;
			}

			if ( transfer_moles1 > 0 ) {
				removed1 = this.air1.remove( transfer_moles1 );
				this.air3.merge( removed1 );
			}

			if ( transfer_moles2 > 0 ) {
				removed2 = this.air2.remove( transfer_moles2 );
				this.air3.merge( removed2 );
			}

			if ( this.network1 != null && transfer_moles1 != 0 ) {
				((dynamic)this.network1).update = 1;
			}

			if ( this.network2 != null && transfer_moles2 != 0 ) {
				((dynamic)this.network2).update = 1;
			}

			if ( this.network3 != null ) {
				((dynamic)this.network3).update = 1;
			}
			return 1;
		}

		// Function from file: mixer.dm
		public override dynamic power_change(  ) {
			int old_stat = 0;

			old_stat = this.stat;
			base.power_change();

			if ( old_stat != this.stat ) {
				this.update_icon();
			}
			return null;
		}

		// Function from file: mixer.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "intact_off";
			} else if ( this.node2 != null && this.node3 != null && this.node1 != null ) {
				this.icon_state = "intact_" + ( this.on ? "on" : "off" );
			} else {
				this.icon_state = "intact_off";
				this.on = false;
			}
			base.update_icon( (object)(location), (object)(target) );
			return null;
		}

	}

}