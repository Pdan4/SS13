// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_TransferValve : Obj_Item_Device {

		public dynamic tank_one = null;
		public dynamic tank_two = null;
		public dynamic attached_device = null;
		public dynamic attacher = null;
		public bool valve_open = false;
		public bool toggle = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 257;
			this.icon = "icons/obj/assemblies.dmi";
			this.icon_state = "valve_1";
		}

		public Obj_Item_Device_TransferValve ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: transfer_valve.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Icon J = null;

			this.overlays.len = 0;
			this.underlays = null;

			if ( !Lang13.Bool( this.tank_one ) && !Lang13.Bool( this.tank_two ) && !Lang13.Bool( this.attached_device ) ) {
				this.icon_state = "valve_1";
				return null;
			}
			this.icon_state = "valve";

			if ( Lang13.Bool( this.tank_one ) ) {
				this.overlays.Add( "" + this.tank_one.icon_state );
			}

			if ( Lang13.Bool( this.tank_two ) ) {
				J = new Icon( this.icon, "" + this.tank_two.icon_state );
				J.Shift( GlobalVars.WEST, 13 );
				this.underlays.Add( J );
			}

			if ( Lang13.Bool( this.attached_device ) ) {
				this.overlays.Add( "device" );
			}
			return null;
		}

		// Function from file: transfer_valve.dm
		public void process_activation( dynamic D = null ) {
			
			if ( this.toggle ) {
				this.toggle = false;
				this.toggle_valve();
				Task13.Schedule( 50, (Task13.Closure)(() => {
					this.toggle = true;
					return;
				}));
			}
			return;
		}

		// Function from file: transfer_valve.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() ) {
				return null;
			}

			if ( this.loc == Task13.User ) {
				
				if ( Lang13.Bool( this.tank_one ) && Lang13.Bool( href_list["tankone"] ) ) {
					this.split_gases();
					this.valve_open = false;
					this.tank_one.loc = GlobalFuncs.get_turf( this );
					this.tank_one = null;
					this.update_icon();
				} else if ( Lang13.Bool( this.tank_two ) && Lang13.Bool( href_list["tanktwo"] ) ) {
					this.split_gases();
					this.valve_open = false;
					this.tank_two.loc = GlobalFuncs.get_turf( this );
					this.tank_two = null;
					this.update_icon();
				} else if ( Lang13.Bool( href_list["open"] ) ) {
					this.toggle_valve();
				} else if ( Lang13.Bool( this.attached_device ) ) {
					
					if ( Lang13.Bool( href_list["rem_device"] ) ) {
						this.attached_device.loc = GlobalFuncs.get_turf( this );
						this.attached_device.holder = null;
						this.attached_device = null;
						this.update_icon();
					}

					if ( Lang13.Bool( href_list["device"] ) ) {
						((Obj_Item)this.attached_device).attack_self( Task13.User );
					}
				}
				this.attack_self( Task13.User );
				this.add_fingerprint( Task13.User );
				return null;
			}
			return null;
		}

		// Function from file: transfer_valve.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;

			((Mob)user).set_machine( this );
			dat = "<B> Valve properties: </B>\n	<BR> <B> Attachment one:</B> " + this.tank_one + " " + ( Lang13.Bool( this.tank_one ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";tankone=1'>Remove</A>" ).ToString() : "" ) + "\n	<BR> <B> Attachment two:</B> " + this.tank_two + " " + ( Lang13.Bool( this.tank_two ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";tanktwo=1'>Remove</A>" ).ToString() : "" ) + "\n	<BR> <B> Valve attachment:</B> " + ( Lang13.Bool( this.attached_device ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";device=1'>" ).item( this.attached_device ).str( "</A>" ).ToString() : "None" ) + " " + ( Lang13.Bool( this.attached_device ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";rem_device=1'>Remove</A>" ).ToString() : "" ) + "\n	<BR> <B> Valve status: </B> " + ( this.valve_open ? new Txt( "<A href='?src=" ).Ref( this ).str( ";open=1'>Closed</A> <B>Open</B>" ).ToString() : new Txt( "<B>Closed</B> <A href='?src=" ).Ref( this ).str( ";open=1'>Open</A>" ).ToString() );
			Interface13.Browse( user, dat, "window=trans_valve;size=600x300" );
			GlobalFuncs.onclose( user, "trans_valve" );
			return null;
		}

		// Function from file: transfer_valve.dm
		public override bool HasProximity( dynamic AM = null ) {
			
			if ( !Lang13.Bool( this.attached_device ) ) {
				return false;
			}
			((Ent_Static)this.attached_device).HasProximity( AM );
			return false;
		}

		// Function from file: transfer_valve.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic A = null;

			
			if ( a is Obj_Item_Weapon_Tank ) {
				
				if ( Lang13.Bool( this.tank_one ) && Lang13.Bool( this.tank_two ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>There are already two tanks attached, remove one first.</span>" );
					return null;
				}

				if ( !Lang13.Bool( this.tank_one ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.tank_one = a;
						GlobalFuncs.to_chat( b, "<span class='notice'>You attach the tank to the transfer valve.</span>" );
					}
				} else if ( !Lang13.Bool( this.tank_two ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						this.tank_two = a;
						GlobalFuncs.to_chat( b, "<span class='notice'>You attach the tank to the transfer valve.</span>" );
					}
				}
				this.update_icon();
			} else if ( GlobalFuncs.isassembly( a ) ) {
				A = a;

				if ( Lang13.Bool( A.secured ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>The device is secured.</span>" );
					return null;
				}

				if ( Lang13.Bool( this.attached_device ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>There is already a device attached to the valve, remove it first.</span>" );
					return null;
				}
				((Mob)b).remove_from_mob( a );
				this.attached_device = A;
				A.loc = this;
				GlobalFuncs.to_chat( b, "<span class='notice'>You attach the " + a + " to the valve controls and secure it.</span>" );
				A.holder = this;
				((Obj_Item_Device_Assembly)A).toggle_secure();
				GlobalVars.bombers.Add( "" + GlobalFuncs.key_name( b ) + " attached a " + a + " to a transfer valve." );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( b ) + " attached a " + a + " to a transfer valve." );
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name_admin( b ) + " attached a " + a + " to a transfer valve." ) ) );
				this.attacher = b;
			}
			return null;
		}

		// Function from file: transfer_valve.dm
		public override bool on_found( dynamic finder = null ) {
			
			if ( Lang13.Bool( this.attached_device ) ) {
				((Obj_Item)this.attached_device).on_found( finder );
			}
			base.on_found( (object)(finder) );
			return false;
		}

		// Function from file: transfer_valve.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			
			if ( Lang13.Bool( this.attached_device ) ) {
				((Base_Dynamic)this.attached_device).Crossed( O );
			}
			base.Crossed( O, (object)(X) );
			return null;
		}

		// Function from file: transfer_valve.dm
		public override bool IsAssemblyHolder(  ) {
			return true;
		}

		// Function from file: transfer_valve.dm
		public void c_state(  ) {
			return;
		}

		// Function from file: transfer_valve.dm
		public void child_ruptured( Obj_Item_Weapon_Tank tank = null, dynamic range = null ) {
			
			if ( this.tank_one == tank ) {
				this.tank_one = null;
			}

			if ( this.tank_two == tank ) {
				this.tank_two = null;
			}
			this.update_icon();

			if ( Convert.ToDouble( range ) > 4 ) {
				
				if ( this.loc != null && this.loc is Obj ) {
					this.loc.ex_act( 1, this );
				}
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: transfer_valve.dm
		public void toggle_valve(  ) {
			dynamic bombturf = null;
			dynamic A = null;
			string attacher_name = null;
			string log_str = null;
			dynamic mob = null;
			string last_touch_info = null;

			
			if ( !this.valve_open && Lang13.Bool( this.tank_one ) && Lang13.Bool( this.tank_two ) ) {
				this.valve_open = true;
				bombturf = GlobalFuncs.get_turf( this );
				A = GlobalFuncs.get_area( bombturf );
				attacher_name = "";

				if ( !Lang13.Bool( this.attacher ) ) {
					attacher_name = "Unknown";
				} else {
					attacher_name = "" + this.attacher.name + "(" + this.attacher.ckey + ")";
				}
				log_str = "Bomb valve opened in <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + bombturf.x + ";Y=" + bombturf.y + ";Z=" + bombturf.z + "'>" + A.name + "</a> ";
				log_str += "with " + ( Lang13.Bool( this.attached_device ) ? this.attached_device : ((dynamic)( "no device" )) ) + " attacher: " + attacher_name;

				if ( Lang13.Bool( this.attacher ) ) {
					log_str += new Txt( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( this.attacher ).str( "'>?</A>)" ).ToString();
				}
				mob = GlobalFuncs.get_mob_by_key( this.fingerprintslast );
				last_touch_info = "";

				if ( Lang13.Bool( mob ) ) {
					last_touch_info = new Txt( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( mob ).str( "'>?</A>)" ).ToString();
				}
				log_str += " Last touched by: " + this.fingerprintslast + last_touch_info;
				GlobalVars.bombers.Add( log_str );
				GlobalFuncs.message_admins( log_str );
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + log_str ) );
				this.merge_gases();
			} else if ( this.valve_open && Lang13.Bool( this.tank_one ) && Lang13.Bool( this.tank_two ) ) {
				this.split_gases();
				this.valve_open = false;
				this.update_icon();
			}
			return;
		}

		// Function from file: transfer_valve.dm
		public void split_gases(  ) {
			double ratio1 = 0;
			GasMixture temp = null;

			
			if ( !this.valve_open || !Lang13.Bool( this.tank_one ) || !Lang13.Bool( this.tank_two ) ) {
				return;
			}
			ratio1 = Convert.ToDouble( this.tank_one.air_contents.volume / this.tank_two.air_contents.volume );
			temp = ((GasMixture)this.tank_two.air_contents).remove_ratio( ratio1 );
			((GasMixture)this.tank_one.air_contents).merge( temp );
			this.tank_two.air_contents.volume -= this.tank_one.air_contents.volume;
			return;
		}

		// Function from file: transfer_valve.dm
		public void merge_gases(  ) {
			GasMixture temp = null;

			this.tank_two.air_contents.volume += this.tank_one.air_contents.volume;
			temp = ((GasMixture)this.tank_one.air_contents).remove_ratio( 1 );
			((GasMixture)this.tank_two.air_contents).merge( temp );
			return;
		}

		// Function from file: transfer_valve.dm
		[VerbInfo( name: "process activation" )]
		[VerbArg( 1, InputType.Obj )]
		public void _internal_process_activation( dynamic D = null ) {
			return;
		}

	}

}