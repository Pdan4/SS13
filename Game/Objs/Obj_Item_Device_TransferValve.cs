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

			this.item_state = "ttv";
			this.icon = "icons/obj/assemblies.dmi";
			this.icon_state = "valve_1";
		}

		public Obj_Item_Device_TransferValve ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: transfer_valve.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Icon J = null;

			this.overlays.Cut();
			this.underlays = null;

			if ( !Lang13.Bool( this.tank_one ) && !Lang13.Bool( this.tank_two ) && !Lang13.Bool( this.attached_device ) ) {
				this.icon_state = "valve_1";
				return false;
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
			return false;
		}

		// Function from file: transfer_valve.dm
		public void c_state(  ) {
			return;
		}

		// Function from file: transfer_valve.dm
		public void toggle_valve(  ) {
			dynamic bombturf = null;
			dynamic A = null;
			dynamic attachment = null;
			string attacher_name = null;
			string log_str1 = null;
			string log_str2 = null;
			string log_attacher = null;
			dynamic mob = null;
			string last_touch_info = null;
			string log_str3 = null;
			string bomb_message = null;
			int? i = null;

			
			if ( !this.valve_open && Lang13.Bool( this.tank_one ) && Lang13.Bool( this.tank_two ) ) {
				this.valve_open = true;
				bombturf = GlobalFuncs.get_turf( this );
				A = GlobalFuncs.get_area( bombturf );
				attachment = "no device";

				if ( Lang13.Bool( this.attached_device ) ) {
					
					if ( this.attached_device is Obj_Item_Device_Assembly_Signaler ) {
						attachment = "<A HREF='?_src_=holder;secrets=list_signalers'>" + this.attached_device + "</A>";
					} else {
						attachment = this.attached_device;
					}
				}
				attacher_name = "";

				if ( !Lang13.Bool( this.attacher ) ) {
					attacher_name = "Unknown";
				} else {
					attacher_name = "" + GlobalFuncs.key_name_admin( this.attacher );
				}
				log_str1 = "Bomb valve opened in ";
				log_str2 = "with " + attachment + " attacher: " + attacher_name;
				log_attacher = "";

				if ( Lang13.Bool( this.attacher ) ) {
					log_attacher = new Txt( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( this.attacher ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( this.attacher ).str( "'>FLW</A>)" ).ToString();
				}
				mob = GlobalFuncs.get_mob_by_key( this.fingerprintslast );
				last_touch_info = "";

				if ( Lang13.Bool( mob ) ) {
					last_touch_info = new Txt( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( mob ).str( "'>?</A>) (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( mob ).str( "'>FLW</A>)" ).ToString();
				}
				log_str3 = " Last touched by: " + GlobalFuncs.key_name_admin( mob );
				bomb_message = "" + log_str1 + " <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + bombturf.x + ";Y=" + bombturf.y + ";Z=" + bombturf.z + "'>" + A.name + "</a>  " + log_str2 + log_attacher + " " + log_str3 + last_touch_info;
				GlobalVars.bombers.Add( bomb_message );
				GlobalFuncs.message_admins( bomb_message );
				GlobalFuncs.log_game( "" + log_str1 + " " + A.name + "(" + A.x + "," + A.y + "," + A.z + ") " + log_str2 + " " + log_str3 );
				this.merge_gases();
				Task13.Schedule( 20, (Task13.Closure)(() => {
					i = null;
					i = 0;

					while (( i ??0) < 5) {
						this.update_icon();
						Task13.Sleep( 10 );
						i++;
					}
					this.update_icon();
					return;
				}));
			} else if ( this.valve_open && Lang13.Bool( this.tank_one ) && Lang13.Bool( this.tank_two ) ) {
				this.split_gases();
				this.valve_open = false;
				this.update_icon();
			}
			return;
		}

		// Function from file: transfer_valve.dm
		public void split_gases(  ) {
			double? ratio1 = null;
			GasMixture temp = null;

			
			if ( !this.valve_open || !Lang13.Bool( this.tank_one ) || !Lang13.Bool( this.tank_two ) ) {
				return;
			}
			ratio1 = Lang13.DoubleNullable( this.tank_one.air_contents.volume / this.tank_two.air_contents.volume );
			temp = ((GasMixture)this.tank_two.air_contents).remove_ratio( ratio1 );
			this.tank_one.air_contents.merge( temp );
			this.tank_two.air_contents.volume -= this.tank_one.air_contents.volume;
			return;
		}

		// Function from file: transfer_valve.dm
		public void merge_gases(  ) {
			GasMixture temp = null;

			this.tank_two.air_contents.volume += this.tank_one.air_contents.volume;
			temp = ((GasMixture)this.tank_one.air_contents).remove_ratio( 1 );
			this.tank_two.air_contents.merge( temp );
			return;
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
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			base.Topic( href, href_list, (object)(hsrc) );

			if ( Task13.User.stat != 0 || Task13.User.restrained() ) {
				return null;
			}

			if ( this.loc == Task13.User ) {
				
				if ( Lang13.Bool( this.tank_one ) && Lang13.Bool( href_list["tankone"] ) ) {
					this.split_gases();
					this.valve_open = false;
					this.tank_one.loc = GlobalFuncs.get_turf( this );
					this.tank_one = null;
					this.update_icon();

					if ( ( !Lang13.Bool( this.tank_two ) || Convert.ToDouble( this.tank_two.w_class ) < 4 ) && Convert.ToDouble( this.w_class ) > 3 ) {
						this.w_class = 3;
					}
				} else if ( Lang13.Bool( this.tank_two ) && Lang13.Bool( href_list["tanktwo"] ) ) {
					this.split_gases();
					this.valve_open = false;
					this.tank_two.loc = GlobalFuncs.get_turf( this );
					this.tank_two = null;
					this.update_icon();

					if ( ( !Lang13.Bool( this.tank_one ) || Convert.ToDouble( this.tank_one.w_class ) < 4 ) && Convert.ToDouble( this.w_class ) > 3 ) {
						this.w_class = 3;
					}
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
			Browser popup = null;

			((Mob)user).set_machine( this );
			dat = "<B> Valve properties: </B>\n	<BR> <B> Attachment one:</B> " + this.tank_one + " " + ( Lang13.Bool( this.tank_one ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";tankone=1'>Remove</A>" ).ToString() : "" ) + "\n	<BR> <B> Attachment two:</B> " + this.tank_two + " " + ( Lang13.Bool( this.tank_two ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";tanktwo=1'>Remove</A>" ).ToString() : "" ) + "\n	<BR> <B> Valve attachment:</B> " + ( Lang13.Bool( this.attached_device ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";device=1'>" ).item( this.attached_device ).str( "</A>" ).ToString() : "None" ) + " " + ( Lang13.Bool( this.attached_device ) ? new Txt( "<A href='?src=" ).Ref( this ).str( ";rem_device=1'>Remove</A>" ).ToString() : "" ) + "\n	<BR> <B> Valve status: </B> " + ( this.valve_open ? new Txt( "<A href='?src=" ).Ref( this ).str( ";open=1'>Closed</A> <B>Open</B>" ).ToString() : new Txt( "<B>Closed</B> <A href='?src=" ).Ref( this ).str( ";open=1'>Open</A>" ).ToString() );
			popup = new Browser( user, "trans_valve", this.name );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: transfer_valve.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic A2 = null;

			
			if ( A is Obj_Item_Weapon_Tank ) {
				
				if ( Lang13.Bool( this.tank_one ) && Lang13.Bool( this.tank_two ) ) {
					user.WriteMsg( "<span class='warning'>There are already two tanks attached, remove one first!</span>" );
					return null;
				}

				if ( !Lang13.Bool( this.tank_one ) ) {
					
					if ( !((Mob)user).unEquip( A ) ) {
						return null;
					}
					this.tank_one = A;
					A.loc = this;
					user.WriteMsg( "<span class='notice'>You attach the tank to the transfer valve.</span>" );

					if ( Convert.ToDouble( A.w_class ) > Convert.ToDouble( this.w_class ) ) {
						this.w_class = A.w_class;
					}
				} else if ( !Lang13.Bool( this.tank_two ) ) {
					
					if ( !((Mob)user).unEquip( A ) ) {
						return null;
					}
					this.tank_two = A;
					A.loc = this;
					user.WriteMsg( "<span class='notice'>You attach the tank to the transfer valve.</span>" );

					if ( Convert.ToDouble( A.w_class ) > Convert.ToDouble( this.w_class ) ) {
						this.w_class = A.w_class;
					}
				}
				this.update_icon();
			} else if ( A is Obj_Item_Device_Assembly ) {
				A2 = A;

				if ( A2.secured ) {
					user.WriteMsg( "<span class='notice'>The device is secured.</span>" );
					return null;
				}

				if ( Lang13.Bool( this.attached_device ) ) {
					user.WriteMsg( "<span class='warning'>There is already a device attached to the valve, remove it first!</span>" );
					return null;
				}
				((Mob)user).remove_from_mob( A );
				this.attached_device = A2;
				A2.loc = this;
				user.WriteMsg( "<span class='notice'>You attach the " + A + " to the valve controls and secure it.</span>" );
				A2.holder = this;
				((Obj_Item_Device_Assembly)A2).toggle_secure();
				GlobalVars.bombers.Add( "" + GlobalFuncs.key_name( user ) + " attached a " + A + " to a transfer valve." );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user ) + " attached a " + A + " to a transfer valve." );
				GlobalFuncs.log_game( "" + GlobalFuncs.key_name_admin( user ) + " attached a " + A + " to a transfer valve." );
				this.attacher = user;
			}
			return null;
		}

		// Function from file: transfer_valve.dm
		public override bool IsAssemblyHolder(  ) {
			return true;
		}

	}

}