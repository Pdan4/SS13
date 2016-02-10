// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SpaceHeater_AirConditioner : Obj_Machinery_SpaceHeater {

		public int cooling_power = 40000;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.set_temperature = 20;
			this.base_state = "aircond";
			this.light_color = "#7DE1E1";
			this.icon_state = "aircond0";
		}

		// Function from file: chiller.dm
		public Obj_Machinery_SpaceHeater_AirConditioner ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.cell = new Obj_Item_Weapon_Cell( this );
			this.cell.charge = 1000;
			this.cell.maxcharge = 1000;
			this.update_icon();
			return;
		}

		// Function from file: chiller.dm
		public override dynamic process(  ) {
			
			if ( this.on ) {
				
				if ( Lang13.Bool( this.cell ) && Convert.ToDouble( this.cell.charge ) > 0 ) {
					
					if ( this.chill() ) {
						this.cell.use( this.cooling_power / 20000 );
					}
				} else {
					this.on = false;
					this.update_icon();
				}
			}
			return null;
		}

		// Function from file: chiller.dm
		public bool chill(  ) {
			Ent_Static L = null;
			GasMixture env = null;
			dynamic transfer_moles = null;
			GasMixture removed = null;
			int air_heat_capacity = 0;
			int combined_heat_capacity = 0;
			double combined_energy = 0;

			L = this.loc;

			if ( L is Tile_Simulated ) {
				env = L.return_air();
				transfer_moles = env.f_total_moles() * 0.25;
				removed = env.remove( transfer_moles );

				if ( removed != null ) {
					
					if ( ( removed.temperature ??0) > this.set_temperature + 273.41 ) {
						air_heat_capacity = removed.heat_capacity();
						combined_heat_capacity = this.cooling_power + air_heat_capacity;

						if ( combined_heat_capacity > 0 ) {
							combined_energy = this.set_temperature * this.cooling_power + air_heat_capacity * ( removed.temperature ??0);
							removed.temperature = combined_energy / combined_heat_capacity;
						}
						env.merge( removed );
						return true;
					}
					env.merge( removed );
				}
			}
			return false;
		}

		// Function from file: chiller.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? value = null;
			dynamic C = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				Interface13.Browse( Task13.User, null, "window=aircond" );
				Task13.User.unset_machine();
				return 1;
			} else {
				Task13.User.set_machine( this );

				dynamic _a = href_list["op"]; // Was a switch-case, sorry for the mess.
				if ( _a=="temp" ) {
					value = String13.ParseNumber( href_list["val"] );
					this.set_temperature = ( this.set_temperature + ( value ??0) <= 0 ? 0 : ( this.set_temperature + ( value ??0) >= 25 ? 25 : this.set_temperature + ( value ??0) ) );
				} else if ( _a=="cellremove" ) {
					
					if ( this.panel_open && Lang13.Bool( this.cell ) && !Lang13.Bool( Task13.User.get_active_hand() ) ) {
						this.cell.updateicon();
						Task13.User.put_in_hands( this.cell );
						((Ent_Static)this.cell).add_fingerprint( Task13.User );
						this.cell = null;
						Task13.User.visible_message( new Txt( "<span class='notice'>" ).item( Task13.User ).str( " removes the power cell from " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You remove the power cell from " ).the( this ).item().str( ".</span>" ).ToString() );
					}
				} else if ( _a=="cellinstall" ) {
					
					if ( this.panel_open && !Lang13.Bool( this.cell ) ) {
						C = Task13.User.get_active_hand();

						if ( C is Obj_Item_Weapon_Cell ) {
							
							if ( Task13.User.drop_item( C, this ) ) {
								this.cell = C;
								((Ent_Static)C).add_fingerprint( Task13.User );
								Task13.User.visible_message( new Txt( "<span class='notice'>" ).item( Task13.User ).str( " inserts a power cell into " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You insert the power cell into " ).the( this ).item().str( ".</span>" ).ToString() );
							}
						}
					}
				}
				this.updateDialog();
			}
			return null;
		}

		// Function from file: chiller.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			double temp = 0;
			string dat = null;

			
			if ( this.panel_open ) {
				temp = this.set_temperature;
				dat = "Power cell: ";

				if ( Lang13.Bool( this.cell ) ) {
					dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=cellremove'>Installed</A><BR>" ).ToString();
				} else {
					dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=cellinstall'>Removed</A><BR>" ).ToString();
				}
				dat += new Txt( "Power Level: " ).item( ( Lang13.Bool( this.cell ) ? Num13.Round( ((Obj_Item_Weapon_Cell)this.cell).percent(), 1 ) : 0 ) ).str( "%<BR><BR>\n			Set Temperature:\n			<A href='?src=" ).Ref( this ).str( ";op=temp;val=-5'>-</A>\n			<A href='?src=" ).Ref( this ).str( ";op=temp;val=-1'>-</A>\n			" ).item( temp ).str( "&deg;C\n			<A href='?src=" ).Ref( this ).str( ";op=temp;val=1'>+</A>\n			<A href='?src=" ).Ref( this ).str( ";op=temp;val=5'>+</A><BR>" ).ToString();
				((Mob)user).set_machine( this );
				Interface13.Browse( user, "<HEAD><TITLE>Air Conditioner Control Panel</TITLE></HEAD><TT>" + dat + "</TT>", "window=aircond" );
				GlobalFuncs.onclose( user, "aircond" );
			} else {
				this.on = !this.on;
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " switches " + ( this.on ? "on" : "off" ) + " the " + this + ".</span>", "<span class='notice'>You switch " + ( this.on ? "on" : "off" ) + " the " + this + ".</span>" );
				this.update_icon();
			}
			return null;
		}

	}

}