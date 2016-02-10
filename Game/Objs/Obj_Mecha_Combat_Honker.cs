// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Combat_Honker : Obj_Mecha_Combat {

		public bool squeak = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.infra_luminosity = 5;
			this.initial_icon = "honker";
			this.step_in = 2;
			this.health = 140;
			this.deflect_chance = 60;
			this.internal_damage_threshold = 60;
			this.damage_absorption = new ByTable().Set( "brute", 1.2 ).Set( "fire", 1.5 ).Set( "bullet", 1 ).Set( "laser", 1 ).Set( "energy", 1 ).Set( "bomb", 1 );
			this.operation_req_access = new ByTable(new object [] { 43 });
			this.wreckage = typeof(Obj_Effect_Decal_MechaWreckage_Honker);
			this.add_req_access = false;
			this.icon_state = "honker";
		}

		public Obj_Mecha_Combat_Honker ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: honker.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( href_list["play_sound"] ) ) {
				
				dynamic _a = href_list["play_sound"]; // Was a switch-case, sorry for the mess.
				if ( _a=="sadtrombone" ) {
					GlobalFuncs.playsound( this, "sound/misc/sadtrombone.ogg", 50 );
				}
			}
			return null;
		}

		// Function from file: honker.dm
		public override dynamic mechstep( double? direction = null ) {
			dynamic result = null;

			Map13.Step( this, ((int)( direction ??0 )) );
			result = null;

			if ( Lang13.Bool( result ) ) {
				
				if ( !this.squeak ) {
					GlobalFuncs.playsound( this, "clownstep", 70, 1 );
					this.squeak = true;
				} else {
					this.squeak = false;
				}
			}
			return result;
		}

		// Function from file: honker.dm
		public override string get_equipment_list(  ) {
			string output = null;
			Obj_Item_MechaParts_MechaEquipment MT = null;

			
			if ( !( this.equipment.len != 0 ) ) {
				return null;
			}
			output = "<b>Honk-ON-Systems:</b><div style=\"margin-left: 15px;\">";

			foreach (dynamic _a in Lang13.Enumerate( this.equipment, typeof(Obj_Item_MechaParts_MechaEquipment) )) {
				MT = _a;
				
				output += "" + ( this.selected == MT ? new Txt( "<b id='" ).Ref( MT ).str( "'>" ).ToString() : new Txt( "<a id='" ).Ref( MT ).str( "' href='?src=" ).Ref( this ).str( ";select_equip=" ).Ref( MT ).str( "'>" ).ToString() ) + MT.get_equip_info() + ( this.selected == MT ? "</b>" : "</a>" ) + "<br>";
			}
			output += "</div>";
			return output;
		}

		// Function from file: honker.dm
		public override string get_commands(  ) {
			string output = null;

			output = new Txt( "<div class='wr'>\n						<div class='header'>Sounds of HONK:</div>\n						<div class='links'>\n						<a href='?src=" ).Ref( this ).str( ";play_sound=sadtrombone'>Sad Trombone</a>\n						</div>\n						</div>\n						" ).ToString();
			output += base.get_commands();
			return output;
		}

		// Function from file: honker.dm
		public override string get_stats_html(  ) {
			string output = null;

			output = new Txt( "<html>\n						<head><title>" ).item( this.name ).str( @" data</title>
						<style>
						body {color: #00ff00; background: #32CD32; font-family:""Courier"",monospace; font-size: 12px;}
						hr {border: 1px solid #0f0; color: #fff; background-color: #000;}
						a {padding:2px 5px;;color:#0f0;}
						.wr {margin-bottom: 5px;}
						.header {cursor:pointer;}
						.open, .closed {background: #32CD32; color:#000; padding:1px 2px;}
						.links a {margin-bottom: 2px;padding-top:3px;}
						.visible {display: block;}
						.hidden {display: none;}
						</style>
						<script language='javascript' type='text/javascript'>
						" ).item( GlobalVars.js_byjax ).str( "\n						" ).item( GlobalVars.js_dropdowns ).str( "\n						function ticker() {\n						    setInterval(function(){\n						        window.location='byond://?src=" ).Ref( this ).str( @"&update_content=1';
						        document.body.style.color = get_rand_color_string();
						      document.body.style.background = get_rand_color_string();
						    }, 1000);
						}

						function get_rand_color_string() {
						    var color = new Array;
						    for(var i=0;i<3;i++){
						        color.push(Math.floor(Math.random()*255));
						    }
						    return ""rgb(""+color.toString()+"")"";
						}

						window.onload = function() {
							dropdowns();
							ticker();
						}
						</script>
						</head>
						<body>
						<div id='content'>
						" ).item( this.get_stats_part() ).str( "\n						</div>\n						<div id='eq_list'>\n						" ).item( this.get_equipment_list() ).str( @"
						</div>
						<hr>
						<div id='commands'>
						" ).item( this.get_commands() ).str( @"
						</div>
						</body>
						</html>
					 " ).ToString();
			return output;
		}

		// Function from file: honker.dm
		public override string get_stats_part(  ) {
			double integrity = 0;
			dynamic cell_charge = null;
			dynamic tank_pressure = null;
			dynamic tank_temperature = null;
			double cabin_pressure = 0;
			string output = null;

			integrity = this.health / Convert.ToDouble( Lang13.Initial( this, "health" ) ) * 100;
			cell_charge = this.get_charge();
			tank_pressure = ( this.internal_tank != null ? ((dynamic)( Num13.Round( Convert.ToDouble( this.internal_tank.return_pressure() ), 0.01 ) )) : ((dynamic)( "None" )) );
			tank_temperature = ( this.internal_tank != null ? ((dynamic)( this.internal_tank.return_temperature() )) : ((dynamic)( "Unknown" )) );
			cabin_pressure = Num13.Round( Convert.ToDouble( this.return_pressure() ), 0.01 );
			output = "" + this.report_internal_damage() + "\n						" + ( integrity < 30 ? "<font color='red'><b>DAMAGE LEVEL CRITICAL</b></font><br>" : null ) + "\n						" + ( ( this.internal_damage & 2 ) != 0 ? "<font color='red'><b>CLOWN SUPPORT SYSTEM MALFUNCTION</b></font><br>" : null ) + "\n						" + ( ( this.internal_damage & 8 ) != 0 ? "<font color='red'><b>GAS TANK HONK</b></font><br>" : null ) + "\n						" + ( ( this.internal_damage & 16 ) != 0 ? new Txt( "<font color='red'><b>HONK-A-DOODLE</b></font> - <a href='?src=" ).Ref( this ).str( ";repair_int_control_lost=1'>Recalibrate</a><br>" ).ToString() : null ) + "\n						<b>IntegriHONK: </b> " + integrity + "%<br>\n						<b>PowerHONK charge: </b>" + ( cell_charge == null ? "No powercell installed" : "" + ((Obj_Item_Weapon_Cell)this.cell).percent() + "%" ) + "<br>\n						<b>Air source: </b>" + ( this.use_internal_tank ? "Internal Airtank" : "Environment" ) + "<br>\n						<b>AirHONK pressure: </b>" + tank_pressure + "kPa<br>\n						<b>AirHONK temperature: </b>" + tank_temperature + "K|" + ( tank_temperature - 273.41 ) + "&deg;C<br>\n						<b>HONK pressure: </b>" + ( cabin_pressure > 325 ? ((dynamic)( "<font color='red'>" + cabin_pressure + "</font>" )) : ((dynamic)( cabin_pressure )) ) + "kPa<br>\n						<b>HONK temperature: </b> " + this.return_temperature() + "K|" + ( this.return_temperature() - 273.41 ) + "&deg;C<br>\n						<b>Lights: </b>" + ( this.lights ? "on" : "off" ) + "<br>\n						" + ( Lang13.Bool( this.dna ) ? new Txt( "<b>DNA-locked:</b><br> <span style='font-size:10px;letter-spacing:-1px;'>" ).item( this.dna ).str( "</span> [<a href='?src=" ).Ref( this ).str( ";reset_dna=1'>Reset</a>]<br>" ).ToString() : null ) + "\n					";
			return output;
		}

		// Function from file: honker.dm
		public override void melee_action( dynamic target = null ) {
			
			if ( !this.melee_can_hit ) {
				return;
			} else if ( target is Mob ) {
				Map13.StepAway( target, this, 15 );
			}
			return;
		}

	}

}