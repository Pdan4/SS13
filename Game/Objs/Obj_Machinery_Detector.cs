// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Detector : Obj_Machinery {

		public dynamic id_tag = null;
		public int range = 3;
		public bool disable = false;
		public int last_read = 0;
		public string base_state = "detector";
		public bool idmode = false;
		public bool scanmode = false;
		public bool senset = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ghost_read = false;
			this.req_access = new ByTable(new object [] { 1 });
			this.flags = 257;
			this.machine_flags = 24;
			this.icon = "icons/obj/detector.dmi";
			this.icon_state = "detector1";
		}

		public Obj_Machinery_Detector ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: metaldetector.dm
		public override int wrenchAnchor( dynamic user = null ) {
			
			if ( base.wrenchAnchor( (object)(user) ) == 1 ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.overlays.Add( "" + this.base_state + "-s" );
				}
			}
			return 0;
		}

		// Function from file: metaldetector.dm
		public override bool HasProximity( dynamic AM = null ) {
			
			if ( this.disable || this.last_read != 0 && Game13.time < this.last_read + 30 ) {
				return false;
			}

			if ( AM is Mob_Living_Carbon ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.flash();
				}
			}
			return false;
		}

		// Function from file: metaldetector.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return null;
			}

			if ( Rand13.PercentChance( ((int)( 75 / severity )) ) ) {
				this.flash();
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: metaldetector.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;

			
			if ( this.allowed( a ) ) {
				((Mob)a).set_machine( this );

				if ( !Lang13.Bool( this.anchored ) ) {
					return null;
				}
				dat = new Txt( "\n		<TITLE>Mr. V.A.L.I.D. Portable Threat Detector</TITLE><h3>Menu:</h3><h4>\n\n		<br>Citizens must carry ID: <A href='?src=" ).Ref( this ).str( ";action=idmode'>Turn " ).item( ( this.idmode ? "Off" : "On" ) ).str( "</A>\n\n		<br>Intrusive Scan: <A href='?src=" ).Ref( this ).str( ";action=scanmode'>Turn " ).item( ( this.scanmode ? "Off" : "On" ) ).str( "</A>\n\n		<br>DeMil Alerts: <A href='?src=" ).Ref( this ).str( ";action=senmode'>Turn " ).item( ( this.senset ? "Off" : "On" ) ).str( "</A></h4>\n		" ).ToString();
				Interface13.Browse( a, dat, "window=detector;size=575x300" );
				GlobalFuncs.onclose( a, "detector" );
				return null;
			} else {
				this.visible_message( "<span class = 'warning'>ACCESS DENIED!</span>" );
			}
			return null;
		}

		// Function from file: metaldetector.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Task13.User != null ) {
				Task13.User.set_machine( this );
			}

			dynamic _a = href_list["action"]; // Was a switch-case, sorry for the mess.
			if ( _a=="idmode" ) {
				this.idmode = !this.idmode;
			} else if ( _a=="scanmode" ) {
				this.scanmode = !this.scanmode;
			} else if ( _a=="senmode" ) {
				this.senset = !this.senset;
			} else {
				return null;
			}
			this.updateUsrDialog();
			return 1;
		}

		// Function from file: metaldetector.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( base.attackby( (object)(a), (object)(b), (object)(c) ) == 1 ) {
				return 1;
			}
			return null;
		}

		// Function from file: metaldetector.dm
		public override dynamic power_change(  ) {
			
			if ( Lang13.Bool( this.powered() ) ) {
				this.stat &= 65533;
				this.icon_state = "" + this.base_state + "1";
			} else {
				this.stat |= 65533;
				this.icon_state = "" + this.base_state + "1";
			}
			return null;
		}

		// Function from file: metaldetector.dm
		public void flash(  ) {
			int maxthreat = 0;
			string sndstr = null;
			dynamic O = null;
			dynamic ourretlist = null;
			int dudesthreat = 0;
			dynamic dudesname = null;

			
			if ( !Lang13.Bool( this.powered() ) ) {
				return;
			}

			if ( this.disable || this.last_read != 0 && Game13.time < this.last_read + 20 ) {
				return;
			}
			maxthreat = 0;
			sndstr = "";

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
				O = _a;
				

				if ( O is Mob_Dead_Observer ) {
					continue;
				}

				if ( Map13.GetDistance( this, O ) > this.range ) {
					continue;
				}
				ourretlist = this.assess_perp( O );

				if ( !( ourretlist is ByTable ) || !( ourretlist.len != 0 ) ) {
					return;
				}
				dudesthreat = Convert.ToInt32( ourretlist[1] );
				dudesname = ourretlist[2];

				if ( dudesthreat >= 4 ) {
					
					if ( maxthreat < 2 ) {
						sndstr = "sound/machines/alert.ogg";
						maxthreat = 2;
					}
					this.last_read = Game13.time;
					this.f_use_power( 1000 );
					this.visible_message( "<span class = 'warning'>Theat Detected! Subject: " + dudesname + "</span>" );
				} else if ( dudesthreat <= 3 && dudesthreat != 0 && this.senset ) {
					
					if ( maxthreat < 1 ) {
						sndstr = "sound/machines/domore.ogg";
						maxthreat = 1;
					}
					this.last_read = Game13.time;
					this.f_use_power( 1000 );
					this.visible_message( "<span class = 'warning'>Additional screening required! Subject: " + dudesname + "</span>" );
				} else {
					
					if ( maxthreat == 0 ) {
						sndstr = "sound/machines/info.ogg";
					}
					this.last_read = Game13.time;
					this.f_use_power( 1000 );
					this.visible_message( "<span class = 'notice'> Subject: " + dudesname + " clear.</span>" );
				}
			}
			Icon13.Flick( "" + this.base_state + "_flash", this );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), sndstr, 100, 1 );
			return;
		}

		// Function from file: metaldetector.dm
		public dynamic assess_perp( dynamic perp = null ) {
			int threatcount = 0;
			dynamic B = null;
			dynamic things = null;
			string passperpname = null;
			Data_Record E = null;
			string perpname = null;
			dynamic id = null;
			Data_Record R = null;
			ByTable retlist = null;

			threatcount = 0;

			if ( !( perp is Mob_Living_Carbon ) || perp is Mob_Living_Carbon_Alien || perp is Mob_Living_Carbon_Brain ) {
				return -1;
			}

			if ( !this.allowed( perp ) ) {
				
				if ( perp.l_hand is Obj_Item_Weapon_Gun || perp.l_hand is Obj_Item_Weapon_Melee ) {
					
					if ( !( perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
						threatcount += 4;
					}
				}

				if ( perp.r_hand is Obj_Item_Weapon_Gun || perp.r_hand is Obj_Item_Weapon_Melee ) {
					
					if ( !( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
						threatcount += 4;
					}
				}

				if ( perp.back is Obj_Item_Weapon_Gun || perp.back is Obj_Item_Weapon_Melee ) {
					
					if ( !( perp.back is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.back is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.back is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
						threatcount += 2;
					}
				}

				if ( perp is Mob_Living_Carbon_Human ) {
					
					if ( perp.belt is Obj_Item_Weapon_Gun || perp.belt is Obj_Item_Weapon_Melee ) {
						
						if ( !( perp.belt is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.belt is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.belt is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
							threatcount += 2;
						}
					}

					if ( perp.s_store is Obj_Item_Weapon_Gun || perp.s_store is Obj_Item_Weapon_Melee ) {
						
						if ( !( perp.s_store is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.s_store is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.s_store is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
							threatcount += 2;
						}
					}
				}

				if ( this.scanmode ) {
					
					if ( perp.l_store is Obj_Item_Weapon_Gun || perp.l_store is Obj_Item_Weapon_Melee ) {
						
						if ( !( perp.l_store is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.l_store is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.l_store is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
							threatcount += 2;
						}
					}

					if ( perp.r_store is Obj_Item_Weapon_Gun || perp.r_store is Obj_Item_Weapon_Melee ) {
						
						if ( !( perp.r_store is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.r_store is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.r_store is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
							threatcount += 2;
						}
					}

					if ( Lang13.Bool( perp.back ) && perp.back is Obj_Item_Weapon_Storage_Backpack ) {
						B = perp.back;

						foreach (dynamic _a in Lang13.Enumerate( B.contents )) {
							things = _a;
							

							if ( things is Obj_Item_Weapon_Gun || things is Obj_Item_Weapon_Melee ) {
								
								if ( !( things is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( things is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( things is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
									threatcount += 2;
								}
							}
						}
					}
				}

				if ( this.idmode ) {
					
					if ( !Lang13.Bool( perp.wear_id ) ) {
						threatcount += 4;
					}
				} else if ( !Lang13.Bool( perp.wear_id ) ) {
					threatcount += 2;
				}

				if ( perp is Mob_Living_Carbon_Human ) {
					
					if ( perp.wear_suit is Obj_Item_Clothing_Suit_Wizrobe ) {
						threatcount += 2;
					}
				}

				if ( Lang13.Bool( perp.dna ) && Lang13.Bool( perp.dna.mutantrace ) && perp.dna.mutantrace != "none" ) {
					threatcount += 2;
				}
			}
			passperpname = "";

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.data_core.general, typeof(Data_Record) )) {
				E = _c;
				
				perpname = perp.name;

				if ( Lang13.Bool( perp.wear_id ) ) {
					id = ((Obj_Item)perp.wear_id).GetID();

					if ( Lang13.Bool( id ) ) {
						perpname = id.registered_name;
					}
				} else {
					perpname = "Unknown";
				}
				passperpname = perpname;

				if ( E.fields["name"] == perpname ) {
					
					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
						R = _b;
						

						if ( R.fields["id"] == E.fields["id"] && R.fields["criminal"] == "*Arrest*" ) {
							threatcount = 4;
							break;
						}
					}
				}
			}
			retlist = new ByTable(new object [] { threatcount, passperpname });

			if ( this.emagged != 0 ) {
				retlist[1] = 10;
			}
			return retlist;
		}

	}

}