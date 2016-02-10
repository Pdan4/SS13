// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tank : Obj_Item_Weapon {

		public GasMixture air_contents = null;
		public dynamic distribute_pressure = 101.32499694824219;
		public int integrity = 3;
		public double volume = 70;
		public dynamic manipulated_by = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slot_flags = 1024;
			this.pressure_resistance = 506.625;
			this.force = 5;
			this.throwforce = 10;
			this.throw_speed = 1;
			this.throw_range = 4;
			this.icon = "icons/obj/tank.dmi";
		}

		// Function from file: tanks.dm
		public Obj_Item_Weapon_Tank ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents = new GasMixture();
			this.air_contents.volume = this.volume;
			this.air_contents.temperature = 293.41;
			GlobalVars.processing_objects.Add( this );
			return;
		}

		// Function from file: tanks.dm
		public override dynamic process(  ) {
			
			if ( this.air_contents != null ) {
				this.air_contents.react();
			}
			this.check_status();
			return null;
		}

		// Function from file: bomb.dm
		public void release(  ) {
			GasMixture removed = null;
			dynamic T = null;

			removed = this.air_contents.remove( this.air_contents.f_total_moles() );
			T = GlobalFuncs.get_turf( this );

			if ( !Lang13.Bool( T ) ) {
				return;
			}
			((Ent_Static)T).assume_air( removed );
			return;
		}

		// Function from file: bomb.dm
		public void detonate(  ) {
			dynamic fuel_moles = null;
			dynamic strength = null;
			dynamic ground_zero = null;

			fuel_moles = this.air_contents.toxins + this.air_contents.oxygen / 6;
			strength = 1;
			ground_zero = GlobalFuncs.get_turf( this.loc );
			this.loc = null;

			if ( ( this.air_contents.temperature ??0) > 673.1500244140625 ) {
				strength = fuel_moles / 15;

				if ( Convert.ToDouble( strength ) >= 1 ) {
					GlobalFuncs.explosion( ground_zero, Num13.Round( Convert.ToDouble( strength ), 1 ), Num13.Round( Convert.ToDouble( strength * 2 ), 1 ), Num13.Round( Convert.ToDouble( strength * 3 ), 1 ), Num13.Round( Convert.ToDouble( strength * 4 ), 1 ) );
				} else if ( Convert.ToDouble( strength ) >= 0.5 ) {
					GlobalFuncs.explosion( ground_zero, 0, 1, 2, 4 );
				} else if ( Convert.ToDouble( strength ) >= 0.2 ) {
					GlobalFuncs.explosion( ground_zero, -1, 0, 1, 2 );
				} else {
					((Ent_Static)ground_zero).assume_air( this.air_contents );
					((Tile)ground_zero).hotspot_expose( 1000, 125, null, true );
				}
			} else if ( ( this.air_contents.temperature ??0) > 523.1500244140625 ) {
				strength = fuel_moles / 20;

				if ( Convert.ToDouble( strength ) >= 1 ) {
					GlobalFuncs.explosion( ground_zero, 0, Num13.Round( Convert.ToDouble( strength ), 1 ), Num13.Round( Convert.ToDouble( strength * 2 ), 1 ), Num13.Round( Convert.ToDouble( strength * 3 ), 1 ) );
				} else if ( Convert.ToDouble( strength ) >= 0.5 ) {
					GlobalFuncs.explosion( ground_zero, -1, 0, 1, 2 );
				} else {
					((Ent_Static)ground_zero).assume_air( this.air_contents );
					((Tile)ground_zero).hotspot_expose( 1000, 125, null, true );
				}
			} else if ( ( this.air_contents.temperature ??0) > 373.41 ) {
				strength = fuel_moles / 25;

				if ( Convert.ToDouble( strength ) >= 1 ) {
					GlobalFuncs.explosion( ground_zero, -1, 0, Num13.Round( Convert.ToDouble( strength ), 1 ), Num13.Round( Convert.ToDouble( strength * 3 ), 1 ) );
				} else {
					((Ent_Static)ground_zero).assume_air( this.air_contents );
					((Tile)ground_zero).hotspot_expose( 1000, 125, true );
				}
			} else {
				((Ent_Static)ground_zero).assume_air( this.air_contents );
				((Tile)ground_zero).hotspot_expose( 1000, 125, null, true );
			}

			if ( Lang13.Bool( this.master ) ) {
				Lang13.Delete( this.master );
				this.master = null;
			}
			Lang13.Delete( this );
			Task13.Source = null;
			return;
		}

		// Function from file: bomb.dm
		public void bomb_assemble( dynamic W = null, dynamic user = null ) {
			dynamic S = null;
			dynamic M = null;
			Obj_Item_Device_Onetankbomb R = null;

			S = W;
			M = user;

			if ( !Lang13.Bool( S.secured ) ) {
				return;
			}

			if ( GlobalFuncs.isigniter( S.a_left ) == GlobalFuncs.isigniter( S.a_right ) ) {
				return;
			}

			if ( !Lang13.Bool( M.drop_item( S ) ) ) {
				return;
			}
			R = new Obj_Item_Device_Onetankbomb( this.loc );
			((Mob)M).remove_from_mob( this );
			((Mob)M).put_in_hands( R );
			R.bombassembly = S;
			S.master = R;
			S.loc = R;
			R.bombtank = this;
			this.master = R;
			this.loc = R;
			R.update_icon();
			return;
		}

		// Function from file: tanks.dm
		public bool check_status(  ) {
			bool? cap = null;
			dynamic uncapped = null;
			dynamic pressure = null;
			dynamic range = null;
			dynamic epicenter = null;
			Obj_Machinery_Computer_Bhangmeter bhangmeter = null;
			Ent_Static TV = null;
			dynamic T = null;
			dynamic T2 = null;
			GasMixture leaked_gas = null;

			
			if ( this.timestopped ) {
				return false;
			}
			cap = false;
			uncapped = 0;

			if ( !( this.air_contents != null ) ) {
				return false;
			}
			pressure = this.air_contents.return_pressure();

			if ( Convert.ToDouble( pressure ) > 5066.25 ) {
				
				if ( !( this.loc is Obj_Item_Device_TransferValve ) ) {
					GlobalFuncs.message_admins( "Explosive tank rupture! last key to touch the tank was " + this.fingerprintslast + "." );
					GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "Explosive tank rupture! last key to touch the tank was " + this.fingerprintslast + "." ) ) );
				}
				this.air_contents.react();
				this.air_contents.react();
				this.air_contents.react();
				pressure = this.air_contents.return_pressure();
				range = ( pressure - 5066.25 ) / 1013.25;

				if ( Convert.ToDouble( range ) > Convert.ToDouble( GlobalVars.MAX_EXPLOSION_RANGE ) ) {
					cap = true;
					uncapped = range;
				}
				range = Num13.MinInt( Convert.ToInt32( range ), Convert.ToInt32( GlobalVars.MAX_EXPLOSION_RANGE ) );
				epicenter = GlobalFuncs.get_turf( this.loc );
				GlobalFuncs.explosion( epicenter, Num13.Floor( Convert.ToDouble( range * 0.25 ) ), Num13.Floor( Convert.ToDouble( range * 0.5 ) ), Num13.Floor( Convert.ToDouble( range ) ), Num13.Floor( Convert.ToDouble( range * 1.5 ) ), 1, cap );

				if ( cap == true ) {
					
					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.doppler_arrays, typeof(Obj_Machinery_Computer_Bhangmeter) )) {
						bhangmeter = _a;
						

						if ( bhangmeter != null ) {
							bhangmeter.sense_explosion( Convert.ToInt32( epicenter.x ), Convert.ToInt32( epicenter.y ), Convert.ToInt32( epicenter.z ), Num13.Floor( Convert.ToDouble( uncapped * 0.25 ) ), Num13.Floor( Convert.ToDouble( uncapped * 0.5 ) ), Num13.Floor( Convert.ToDouble( uncapped ) ), "???", cap );
						}
					}
				}

				if ( this.loc is Obj_Item_Device_TransferValve ) {
					TV = this.loc;
					((Obj_Item_Device_TransferValve)TV).child_ruptured( this, range );
				}
				GlobalFuncs.qdel( this );
				return false;
			} else if ( Convert.ToDouble( pressure ) > 4053 ) {
				
				if ( this.integrity <= 0 ) {
					T = GlobalFuncs.get_turf( this );

					if ( !Lang13.Bool( T ) ) {
						return false;
					}
					((Ent_Static)T).assume_air( this.air_contents );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/spray.ogg", 10, 1, -3 );
					GlobalFuncs.qdel( this );
					return false;
				} else {
					this.integrity--;
				}
			} else if ( Convert.ToDouble( pressure ) > 3039.75 ) {
				
				if ( this.integrity <= 0 ) {
					T2 = GlobalFuncs.get_turf( this );

					if ( !Lang13.Bool( T2 ) ) {
						return false;
					}
					leaked_gas = this.air_contents.remove_ratio( 0.25 );
					((Ent_Static)T2).assume_air( leaked_gas );
				} else {
					this.integrity--;
				}
			} else if ( this.integrity < 3 ) {
				this.integrity++;
			}
			return false;
		}

		// Function from file: tanks.dm
		public dynamic remove_air_volume( double volume_to_return = 0 ) {
			dynamic tank_pressure = null;
			dynamic moles_needed = null;

			
			if ( !( this.air_contents != null ) ) {
				return null;
			}
			tank_pressure = this.air_contents.return_pressure();

			if ( Convert.ToDouble( tank_pressure ) < Convert.ToDouble( this.distribute_pressure ) ) {
				this.distribute_pressure = tank_pressure;
			}
			moles_needed = this.distribute_pressure * volume_to_return / ( ( this.air_contents.temperature ??0) * 8.314 );
			return this.remove_air( moles_needed );
		}

		// Function from file: tanks.dm
		public override bool? assume_air( dynamic giver = null ) {
			this.air_contents.merge( giver );
			this.check_status();
			return true;
		}

		// Function from file: tanks.dm
		public override GasMixture return_air(  ) {
			return this.air_contents;
		}

		// Function from file: tanks.dm
		public override dynamic remove_air( dynamic amount = null ) {
			return this.air_contents.remove( amount );
		}

		// Function from file: tanks.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? cp = null;
			Ent_Static location = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( href_list["close"] ) ) {
				
				if ( Task13.User.machine == this ) {
					Task13.User.unset_machine();
				}
				return 1;
			}

			if ( Lang13.Bool( Task13.User.stat ) || Task13.User.restrained() ) {
				return 0;
			}

			if ( this.loc != Task13.User ) {
				return 0;
			}

			if ( Lang13.Bool( href_list["dist_p"] ) ) {
				
				if ( href_list["dist_p"] == "reset" ) {
					this.distribute_pressure = 24;
				} else if ( href_list["dist_p"] == "max" ) {
					this.distribute_pressure = 303.9749755859375;
				} else {
					cp = String13.ParseNumber( href_list["dist_p"] );
					this.distribute_pressure += cp;
				}
				this.distribute_pressure = Num13.MinInt( Num13.MaxInt( Num13.Floor( Convert.ToDouble( this.distribute_pressure ) ), 0 ), ((int)( 303.9749755859375 )) );
			}

			if ( Lang13.Bool( href_list["stat"] ) ) {
				
				if ( this.loc is Mob_Living_Carbon ) {
					location = this.loc;

					if ( ((dynamic)location).v_internal == this ) {
						((dynamic)location).v_internal = null;
						((dynamic)location).internals.icon_state = "internal0";
						GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You close the tank release valve.</span>" );

						if ( Lang13.Bool( ((dynamic)location).internals ) ) {
							((dynamic)location).internals.icon_state = "internal0";
						}
					} else if ( Lang13.Bool( ((dynamic)location).wear_mask ) && Lang13.Bool( ((dynamic)location).wear_mask.flags & 8 ) ) {
						((dynamic)location).v_internal = this;
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You open " ).the( this ).item().str( " valve.</span>" ).ToString() );

						if ( Lang13.Bool( ((dynamic)location).internals ) ) {
							((dynamic)location).internals.icon_state = "internal1";
						}
					} else {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='notice'>You need something to connect to " ).the( this ).item().str( ".</span>" ).ToString() );
					}
				}
			}
			this.add_fingerprint( Task13.User );
			return 1;
		}

		// Function from file: tanks.dm
		public override void ui_interact( dynamic user = null, string ui_key = null, Nanoui ui = null, bool? force_open = null ) {
			ui_key = ui_key ?? "main";

			bool using_internal = false;
			Ent_Static location = null;
			ByTable data = null;
			Ent_Static location2 = null;

			
			if ( this.loc is Mob_Living_Carbon ) {
				location = this.loc;

				if ( ((dynamic)location).v_internal == this ) {
					using_internal = true;
				}
			}
			data = new ByTable( 0 );
			data["tankPressure"] = Num13.Floor( Convert.ToDouble( ( Lang13.Bool( this.air_contents.return_pressure() ) ? this.air_contents.return_pressure() : ((dynamic)( 0 )) ) ) );
			data["releasePressure"] = Num13.Floor( Convert.ToDouble( ( Lang13.Bool( this.distribute_pressure ) ? this.distribute_pressure : ((dynamic)( 0 )) ) ) );
			data["defaultReleasePressure"] = Num13.Floor( 24 );
			data["maxReleasePressure"] = Num13.Floor( 303.9749755859375 );
			data["valveOpen"] = ( using_internal ? true : false );
			data["maskConnected"] = 0;

			if ( this.loc is Mob_Living_Carbon ) {
				location2 = this.loc;

				if ( ((dynamic)location2).v_internal == this || Lang13.Bool( ((dynamic)location2).wear_mask ) && Lang13.Bool( ((dynamic)location2).wear_mask.flags & 8 ) ) {
					data["maskConnected"] = 1;
				}
			}
			ui = GlobalVars.nanomanager.try_update_ui( user, this, ui_key, ui, data );

			if ( !( ui != null ) ) {
				ui = new Nanoui( user, this, ui_key, "tanks.tmpl", "Tank", 500, 300 );
				ui.set_initial_data( data );
				ui.open();
				ui.set_auto_update( true );
			}
			return;
		}

		// Function from file: tanks.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( !( this.air_contents != null ) ) {
				return null;
			}
			this.ui_interact( user );
			return null;
		}

		// Function from file: tanks.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Ent_Static icon = null;
			dynamic analyzer = null;
			dynamic LB = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );
			icon = this;

			if ( this.loc is Obj_Item_Assembly ) {
				icon = this.loc;
			}

			if ( a is Obj_Item_Device_Analyzer && Map13.GetDistance( b, this ) <= 1 ) {
				((Ent_Static)b).visible_message( new Txt( "<span class='attack'>" ).item( b ).str( " has used " ).item( a ).str( " on " ).icon( icon ).str( " " ).item( this ).str( "</span>" ).ToString(), new Txt( "<span class='attack'>You use " ).the( a ).item().str( " on " ).icon( icon ).str( " " ).item( this ).str( "</span>" ).ToString() );
				analyzer = a;
				b.show_message( ((Obj_Item_Device_Analyzer)analyzer).output_gas_scan( this.air_contents, this, false ), 1 );
				this.add_fingerprint( b );
			} else if ( a is Obj_Item_Latexballon ) {
				LB = a;
				((Obj_Item_Latexballon)LB).blow( this );
				this.add_fingerprint( b );
			}

			if ( a is Obj_Item_Device_AssemblyHolder ) {
				this.bomb_assemble( a, b );
			}
			return null;
		}

		// Function from file: tanks.dm
		public override bool blob_act( dynamic severity = null ) {
			Ent_Static location = null;

			
			if ( Rand13.PercentChance( 50 ) ) {
				location = this.loc;

				if ( !( location is Tile ) ) {
					GlobalFuncs.qdel( this );
				}

				if ( this.air_contents != null ) {
					location.assume_air( this.air_contents );
				}
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: tanks.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			Ent_Static icon = null;
			double celsius_temperature = 0;
			string descriptive = null;

			base.examine( (object)(user), size );
			icon = this;

			if ( this.loc is Obj_Item_Assembly ) {
				icon = this.loc;
			}

			if ( !GlobalFuncs.in_range( this, user ) ) {
				
				if ( icon == this ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>It's " ).a( icon ).item().icon( this ).str( "! If you want any more information you'll need to get closer.</span>" ).ToString() );
				}
				return null;
			}
			celsius_temperature = ( this.air_contents.temperature ??0) - 273.41;

			if ( celsius_temperature < 20 ) {
				descriptive = "cold";
			} else if ( celsius_temperature < 40 ) {
				descriptive = "room temperature";
			} else if ( celsius_temperature < 80 ) {
				descriptive = "lukewarm";
			} else if ( celsius_temperature < 100 ) {
				descriptive = "warm";
			} else if ( celsius_temperature < 300 ) {
				descriptive = "hot";
			} else {
				descriptive = "furiously hot";
			}
			GlobalFuncs.to_chat( user, new Txt( "<span class='info'>" ).The( icon ).item().icon( this ).str( " feels " ).item( descriptive ).str( "</span>" ).ToString() );

			if ( ( this.air_contents.volume ??0) * 10 < this.volume ) {
				GlobalFuncs.to_chat( user, "<span class='danger'>The meter on the " + this.name + " indicates you are almost out of gas!</span>" );
				GlobalFuncs.playsound( user, "sound/effects/alert.ogg", 50, 1 );
			}
			return null;
		}

		// Function from file: tanks.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Ent_Static holder = null;

			
			if ( this.air_contents != null ) {
				GlobalFuncs.qdel( this.air_contents );
				this.air_contents = null;
			}

			if ( this.loc is Obj_Machinery_PortableAtmospherics ) {
				holder = this.loc;
				((dynamic)holder).holding = null;
			}
			GlobalVars.processing_objects.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}