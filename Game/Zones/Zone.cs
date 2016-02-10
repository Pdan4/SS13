// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Zone : Base_Zone {

		public bool global_uid = false;
		public bool lighting_use_dynamic = true;
		public int uid = 0;
		public Obj_Machinery_Power_Apc areaapc = null;
		public ByTable area_turfs = null;
		public bool fire = false;
		public bool atmos = true;
		public int atmosalm = 0;
		public bool poweralm = true;
		public bool? party = null;
		public bool radalert = false;
		public bool lightswitch = true;
		public bool eject = false;
		public bool requires_power = true;
		public bool always_unpowered = false;
		public bool power_equip = true;
		public bool power_light = true;
		public bool power_environ = true;
		public string music = null;
		public double used_equip = 0;
		public double used_light = 0;
		public double used_environ = 0;
		public dynamic static_equip = null;
		public int static_light = 0;
		public dynamic static_environ = null;
		public bool? has_gravity = true;
		public dynamic no_air = null;
		public ByTable all_doors = new ByTable();
		public int door_alerts = 0;
		public bool doors_down = false;
		public int jammed = 0;
		public bool anti_ethereal = false;
		public Type general_area = typeof(Zone_Station);
		public string general_area_name = "Station";
		public Obj_Machinery_Alarm master_air_alarm = null;
		public ByTable air_vent_names = new ByTable();
		public ByTable air_scrub_names = new ByTable();
		public ByTable air_vent_info = new ByTable();
		public ByTable air_scrub_info = new ByTable();
		public Obj_Machinery_Media media_source = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 0;
			this.icon = "icons/turf/areas.dmi";
			this.icon_state = "unknown";
			this.layer = 10;
		}

		// Function from file: areas.dm
		public Zone ( dynamic loc = null ) : base( (object)(loc) ) {
			this.area_turfs = new ByTable();
			this.icon_state = "";
			this.layer = 10;
			this.uid = ++GlobalVars.global_uid;

			if ( this.x != 0 ) {
				GlobalVars.areas.Or( this );
			}

			if ( this.type == typeof(Zone) ) {
				this.requires_power = true;
				this.always_unpowered = true;
				this.lighting_use_dynamic = false;
				this.power_light = false;
				this.power_equip = false;
				this.power_environ = false;
			}

			if ( !this.requires_power ) {
				this.power_light = false;
				this.power_equip = false;
				this.power_environ = false;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.power_change();
			return;
		}

		// Function from file: areas.dm
		public override dynamic Entered( Ent_Dynamic Obj = null, Ent_Static oldloc = null ) {
			dynamic oldArea = null;
			Ent_Dynamic M = null;
			dynamic sound = null;

			oldArea = Obj.areaMaster;
			Obj.areaMaster = this;

			if ( !( Obj is Mob ) ) {
				return null;
			}
			M = Obj;
			GlobalFuncs.CallHook( "MobAreaChange", new ByTable().Set( "mob", M ).Set( "new", Obj.areaMaster ).Set( "old", oldArea ) );

			if ( ((dynamic)M).client == null ) {
				return null;
			}

			if ( Lang13.Bool( ((dynamic)M).client.prefs.toggles & 4 ) ) {
				
				if ( M.areaMaster.media_source == null && !((dynamic)M).client.ambience_playing ) {
					((dynamic)M).client.ambience_playing = true;
					sound = "sound/ambience/shipambience.ogg";

					if ( Rand13.PercentChance( 35 ) ) {
						
						if ( this is Zone_Chapel ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambicha1.ogg", "sound/ambience/ambicha2.ogg", "sound/ambience/ambicha3.ogg", "sound/ambience/ambicha4.ogg" });
						} else if ( this is Zone_Medical_Morgue ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambimo1.ogg", "sound/ambience/ambimo2.ogg", "sound/music/main.ogg" });
						} else if ( this.type == typeof(Zone) ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambispace.ogg", "sound/music/space.ogg", "sound/music/main.ogg", "sound/music/traitor.ogg", "sound/ambience/spookyspace1.ogg", "sound/ambience/spookyspace2.ogg" });
						} else if ( this is Zone_Engineering ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambisin1.ogg", "sound/ambience/ambisin2.ogg", "sound/ambience/ambisin3.ogg", "sound/ambience/ambisin4.ogg" });
						} else if ( this is Zone_AIsattele || this is Zone_TurretProtected_Ai || this is Zone_TurretProtected_AiUpload || this is Zone_TurretProtected_AiUploadFoyer ) {
							sound = Rand13.PickFromTable( "sound/ambience/ambimalf.ogg" );
						} else if ( this is Zone_Maintenance_Ghettobar ) {
							sound = Rand13.PickFromTable( "sound/ambience/ghetto.ogg" );
						} else if ( this is Zone_Shuttle_Salvage_Derelict ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/derelict1.ogg", "sound/ambience/derelict2.ogg", "sound/ambience/derelict3.ogg", "sound/ambience/derelict4.ogg" });
						} else if ( this is Zone_Mine_Explored || this is Zone_Mine_Unexplored ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambimine.ogg", "sound/ambience/song_game.ogg", "sound/music/torvus.ogg" });
						} else if ( this is Zone_Maintenance_Fsmaint2 || this is Zone_Maintenance_Port || this is Zone_Maintenance_Aft || this is Zone_Maintenance_Asmaint ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/spookymaint1.ogg", "sound/ambience/spookymaint2.ogg" });
						} else if ( this is Zone_Tcommsat || this is Zone_TurretProtected_Tcomwest || this is Zone_TurretProtected_Tcomeast || this is Zone_TurretProtected_Tcomfoyer || this is Zone_TurretProtected_Tcomsat ) {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambisin2.ogg", "sound/ambience/signal.ogg", "sound/ambience/signal.ogg", "sound/ambience/ambigen10.ogg" });
						} else {
							sound = Rand13.Pick(new object [] { "sound/ambience/ambigen1.ogg", "sound/ambience/ambigen3.ogg", "sound/ambience/ambigen4.ogg", "sound/ambience/ambigen5.ogg", "sound/ambience/ambigen6.ogg", "sound/ambience/ambigen7.ogg", "sound/ambience/ambigen8.ogg", "sound/ambience/ambigen9.ogg", "sound/ambience/ambigen10.ogg", "sound/ambience/ambigen11.ogg", "sound/ambience/ambigen12.ogg", "sound/ambience/ambigen14.ogg" });
						}
					}
					((dynamic)M).WriteMsg( new Sound( sound, false, false, 485, 25 ) );
					Task13.Schedule( 600, (Task13.Closure)(() => {
						
						if ( M != null && Lang13.Bool( ((dynamic)M).client ) ) {
							((dynamic)M).client.ambience_playing = false;
						}
						return;
					}));
				}
			}
			return null;
		}

		// Function from file: areas.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.areaapc = null;
			return null;
		}

		// Function from file: adjacent.dm
		public override bool Adjacent( dynamic neighbor = null, dynamic recurse = null ) {
			Task13.Crash( "Call to /area/Adjacent(), unimplemented proc" );
			return false;
		}

		// Function from file: areas.dm
		public bool move_contents_to( dynamic A = null, dynamic turftoleave = null, double? direction = null ) {
			ByTable turfs_src = null;
			ByTable turfs_trg = null;
			bool src_min_x = false;
			bool src_min_y = false;
			dynamic T = null;
			bool trg_min_x = false;
			bool trg_min_y = false;
			dynamic T2 = null;
			ByTable refined_src = null;
			dynamic T3 = null;
			Coords C = null;
			ByTable refined_trg = null;
			dynamic T4 = null;
			Coords C2 = null;
			ByTable fromupdate = null;
			ByTable toupdate = null;
			dynamic T5 = null;
			dynamic AA = null;
			Coords C_src = null;
			dynamic B = null;
			Coords C_trg = null;
			dynamic old_dir1 = null;
			dynamic old_icon_state1 = null;
			dynamic old_icon1 = null;
			Image undlay = null;
			Type prevtype = null;
			dynamic X = null;
			dynamic key = null;
			dynamic L = null;
			dynamic ST = null;
			dynamic SX = null;
			Obj corner = null;
			Tile nextturf = null;
			Obj O = null;
			dynamic M = null;
			ByTable doors = null;
			Tile_Simulated T1 = null;
			Obj_Machinery_Door D2 = null;
			Tile_Simulated T22 = null;
			Obj_Machinery_Door D22 = null;
			Obj_Machinery_Door D = null;

			
			if ( !Lang13.Bool( A ) || !( this != null ) ) {
				return false;
			}
			turfs_src = GlobalFuncs.get_area_turfs( this.type );
			turfs_trg = GlobalFuncs.get_area_turfs( A.type );
			src_min_x = false;
			src_min_y = false;

			foreach (dynamic _a in Lang13.Enumerate( turfs_src )) {
				T = _a;
				

				if ( Convert.ToDouble( T.x ) < ( src_min_x ?1:0) || !src_min_x ) {
					src_min_x = Lang13.Bool( T.x );
				}

				if ( Convert.ToDouble( T.y ) < ( src_min_y ?1:0) || !src_min_y ) {
					src_min_y = Lang13.Bool( T.y );
				}
			}
			trg_min_x = false;
			trg_min_y = false;

			foreach (dynamic _b in Lang13.Enumerate( turfs_trg )) {
				T2 = _b;
				

				if ( Convert.ToDouble( T2.x ) < ( trg_min_x ?1:0) || !trg_min_x ) {
					trg_min_x = Lang13.Bool( T2.x );
				}

				if ( Convert.ToDouble( T2.y ) < ( trg_min_y ?1:0) || !trg_min_y ) {
					trg_min_y = Lang13.Bool( T2.y );
				}
			}
			refined_src = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( turfs_src )) {
				T3 = _c;
				
				refined_src.Add( T3 );
				refined_src[T3] = new Coords();
				C = refined_src[T3];
				C.x_pos = Lang13.DoubleNullable( T3.x - src_min_x );
				C.y_pos = Lang13.DoubleNullable( T3.y - src_min_y );
			}
			refined_trg = new ByTable();

			foreach (dynamic _d in Lang13.Enumerate( turfs_trg )) {
				T4 = _d;
				
				refined_trg.Add( T4 );
				refined_trg[T4] = new Coords();
				C2 = refined_trg[T4];
				C2.x_pos = Lang13.DoubleNullable( T4.x - trg_min_x );
				C2.y_pos = Lang13.DoubleNullable( T4.y - trg_min_y );
			}
			fromupdate = new ByTable();
			toupdate = new ByTable();

			foreach (dynamic _j in Lang13.Enumerate( refined_src )) {
				T5 = _j;
				
				AA = GlobalFuncs.get_area( T5 );
				C_src = refined_src[T5];
				string _loop_ctrl_1 = null;

				foreach (dynamic _i in Lang13.Enumerate( refined_trg )) {
					B = _i;
					
					C_trg = refined_trg[B];

					if ( C_src.x_pos == C_trg.x_pos && C_src.y_pos == C_trg.y_pos ) {
						old_dir1 = T5.dir;
						old_icon_state1 = T5.icon_state;
						old_icon1 = T5.icon;
						undlay = new Image( B.icon, null, B.icon_state, null, B.dir );
						undlay.overlays = B.overlays;
						prevtype = B.type;
						X = ((Tile)B).ChangeTurf( T5.type, null, null, true );

						foreach (dynamic _e in Lang13.Enumerate( T5.vars )) {
							key = _e;
							
							Interface13.Stat( null, GlobalVars.ignored_keys.Contains( key ) );

							if ( false ) {
								continue;
							}

							if ( T5.vars[key] is ByTable ) {
								L = T5.vars[key];
								X.vars[key] = L.Copy();
							} else {
								X.vars[key] = T5.vars[key];
							}
						}

						if ( Lang13.Bool( ((dynamic)prevtype).IsSubclassOf( typeof(Tile_Space) ) ) ) {
							
							if ( T5.underlays.len != 0 ) {
								X.underlays = T5.underlays;
							} else {
								X.underlays += undlay;
							}
						} else {
							X.underlays += undlay;
						}
						X.dir = old_dir1;
						X.icon_state = old_icon_state1;
						X.icon = old_icon1;
						ST = T5;

						if ( ST is Tile_Simulated && Lang13.Bool( ST.zone ) ) {
							SX = X;

							if ( !Lang13.Bool( SX.air ) ) {
								((Tile)SX).make_air();
							}
							SX.air.copy_from( ST.zone.air );
							((_Zone)ST.zone).remove( ST );
						}

						if ( Lang13.Bool( direction ) && String13.FindIgnoreCase( X.icon_state, "swall_s", 1, 0 ) != 0 ) {
							corner = new Obj();
							corner.forceMove( X );
							corner.density = true;
							corner.anchored = 1;
							corner.icon = X.icon;
							corner.icon_state = GlobalFuncs.replacetext( X.icon_state, "_s", "_f" );
							corner.tag = "delete me";
							corner.name = "wall";
							nextturf = Map13.GetStep( corner, ((int)( direction ??0 )) );

							if ( !( nextturf != null ) || !( nextturf is Tile_Space ) ) {
								nextturf = Map13.GetStep( corner, Num13.Rotate( direction, 180 ) );
							}
							X.icon = nextturf.icon;
							X.icon_state = nextturf.icon_state;
						}

						foreach (dynamic _f in Lang13.Enumerate( T5, typeof(Obj) )) {
							O = _f;
							

							if ( O.tag == "delete me" ) {
								X.icon = "icons/turf/shuttle.dmi";
								X.icon_state = GlobalFuncs.replacetext( O.icon_state, "_f", "_s" );
								X.name = "wall";
								GlobalFuncs.qdel( O );
								O = null;
								continue;
							}

							if ( !( O is Obj ) ) {
								continue;
							}
							O.forceMove( X );
						}

						foreach (dynamic _g in Lang13.Enumerate( T5 )) {
							M = _g;
							

							if ( !((Ent_Dynamic)M).can_shuttle_move() ) {
								continue;
							}
							((Ent_Dynamic)M).forceMove( X );
						}
						toupdate.Add( X );

						if ( Lang13.Bool( turftoleave ) ) {
							fromupdate.Add( ((Tile)T5).ChangeTurf( turftoleave, null, null, true ) );
						} else if ( Lang13.Bool( ((dynamic)AA.type).IsSubclassOf( typeof(Zone_SyndicateStation_Start) ) ) ) {
							((Tile)T5).ChangeTurf( typeof(Tile_Unsimulated_Floor), null, null, true );
							T5.icon = "icons/turf/snow.dmi";
							T5.icon_state = "snow";
						} else {
							((Tile)T5).ChangeTurf( GlobalFuncs.get_base_turf( T5.z ), null, null, true );

							if ( T5 is Tile_Space ) {
								
								dynamic _h = GlobalVars.universe.name; // Was a switch-case, sorry for the mess.
								if ( _h=="Hell Rising" ) {
									T5.overlays += "hell01";
								} else if ( _h=="Supermatter Cascade" ) {
									T5.overlays += "end01";
								}
							}
						}
						refined_src.Remove( T5 );
						refined_trg.Remove( B );
						_loop_ctrl_1 = "continue";
						break;
					}
				}

				if ( _loop_ctrl_1 == "break" ) {
					break;
				} else if ( _loop_ctrl_1 == "continue" ) {
					continue;
				}
			}
			doors = new ByTable();

			if ( toupdate.len != 0 ) {
				
				foreach (dynamic _l in Lang13.Enumerate( toupdate, typeof(Tile_Simulated) )) {
					T1 = _l;
					

					foreach (dynamic _k in Lang13.Enumerate( T1, typeof(Obj_Machinery_Door) )) {
						D2 = _k;
						
						doors.Add( D2 );
					}
				}
			}

			if ( fromupdate.len != 0 ) {
				
				foreach (dynamic _n in Lang13.Enumerate( fromupdate, typeof(Tile_Simulated) )) {
					T22 = _n;
					

					foreach (dynamic _m in Lang13.Enumerate( T22, typeof(Obj_Machinery_Door) )) {
						D22 = _m;
						
						doors.Add( D22 );
					}
				}
			}

			foreach (dynamic _o in Lang13.Enumerate( doors, typeof(Obj_Machinery_Door) )) {
				D = _o;
				
				D.update_nearby_tiles();
			}
			return false;
		}

		// Function from file: areas.dm
		public void add_turfs( dynamic L = null ) {
			dynamic T = null;
			dynamic old_area = null;
			Ent_Dynamic AM = null;

			
			foreach (dynamic _b in Lang13.Enumerate( L )) {
				T = _b;
				
				Interface13.Stat( null, L.Contains( T ) );

				if ( false ) {
					continue;
				}
				old_area = GlobalFuncs.get_area( T );
				L += T;
				((Ent_Static)T).change_area( old_area, this );

				foreach (dynamic _a in Lang13.Enumerate( T.contents, typeof(Ent_Dynamic) )) {
					AM = _a;
					
					AM.change_area( old_area, this );
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void displace_contents(  ) {
			ByTable dstturfs = null;
			int throwy = 0;
			dynamic T = null;
			dynamic T2 = null;
			Tile D = null;
			dynamic AM = null;

			dstturfs = new ByTable();
			throwy = Game13.map_size_y;

			foreach (dynamic _a in Lang13.Enumerate( this )) {
				T = _a;
				
				dstturfs.Add( T );

				if ( Convert.ToDouble( T.y ) < throwy ) {
					throwy = Convert.ToInt32( T.y );
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( dstturfs )) {
				T2 = _c;
				
				D = Map13.GetTile( Convert.ToInt32( T2.x ), throwy - 1, 1 );

				foreach (dynamic _b in Lang13.Enumerate( T2 )) {
					AM = _b;
					
					AM.Move( D );
				}

				if ( T2 is Tile_Simulated ) {
					GlobalFuncs.qdel( T2 );
				}
			}
			return;
		}

		// Function from file: areas.dm
		public Shuttle get_shuttle(  ) {
			Shuttle S = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.shuttles, typeof(Shuttle) )) {
				S = _a;
				

				if ( S.linked_area == this ) {
					return S;
				}
			}
			return null;
		}

		// Function from file: areas.dm
		public ByTable get_atoms(  ) {
			ByTable L = null;
			Ent_Static A = null;

			L = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Static) )) {
				A = _a;
				
				L.Or( A );
			}
			return L;
		}

		// Function from file: areas.dm
		public ByTable get_turfs(  ) {
			ByTable L = null;
			dynamic T = null;

			L = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.contents )) {
				T = _a;
				
				L.Or( T );
			}
			return L;
		}

		// Function from file: areas.dm
		public void remove_apc( Obj_Machinery_Power_Apc apctoremove = null ) {
			
			if ( this.areaapc == apctoremove ) {
				this.areaapc = null;
			}
			return;
		}

		// Function from file: areas.dm
		public void set_apc( Obj_Machinery_Power_Apc apctoset = null ) {
			this.areaapc = apctoset;
			return;
		}

		// Function from file: areas.dm
		public void gravitychange( bool? gravitystate = null, dynamic A = null ) {
			gravitystate = gravitystate ?? false;

			Mob_Living_Carbon_Human H = null;

			A.has_gravity = gravitystate;

			if ( gravitystate == true ) {
				
				foreach (dynamic _a in Lang13.Enumerate( A, typeof(Mob_Living_Carbon_Human) )) {
					H = _a;
					

					if ( GlobalFuncs.get_turf( H ) is Tile_Space ) {
						continue;
					}

					if ( H.shoes is Obj_Item_Clothing_Shoes_Magboots && Lang13.Bool( H.shoes.flags & 1024 ) ) {
						continue;
					}

					if ( Lang13.Bool( H.locked_to ) ) {
						continue;
					}
					H.AdjustStunned( 5 );
					GlobalFuncs.to_chat( H, "<span class='warning'>Gravity!</span>" );
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void use_power( dynamic amount = null, bool? chan = null ) {
			
			switch ((bool?)( chan )) {
				case 1:
					this.used_equip += Convert.ToDouble( amount );
					break;
				case 2:
					this.used_light += Convert.ToDouble( amount );
					break;
				case 3:
					this.used_environ += Convert.ToDouble( amount );
					break;
			}
			return;
		}

		// Function from file: areas.dm
		public void clear_usage(  ) {
			this.used_equip = 0;
			this.used_light = 0;
			this.used_environ = 0;
			return;
		}

		// Function from file: areas.dm
		public void addStaticPower( int value = 0, int powerchannel = 0 ) {
			
			switch ((int)( powerchannel )) {
				case 5:
					this.static_equip += value;
					break;
				case 6:
					this.static_light += value;
					break;
				case 7:
					this.static_environ += value;
					break;
			}
			return;
		}

		// Function from file: areas.dm
		public double usage( int chan = 0 ) {
			
			switch ((int)( chan )) {
				case 2:
					return this.used_light;
					break;
				case 1:
					return this.used_equip;
					break;
				case 3:
					return this.used_environ;
					break;
				case 4:
					return this.used_light + this.used_equip + this.used_environ;
					break;
				case 5:
					return Convert.ToDouble( this.static_equip );
					break;
				case 6:
					return this.static_light;
					break;
				case 7:
					return Convert.ToDouble( this.static_environ );
					break;
			}
			return 0;
		}

		// Function from file: areas.dm
		public void power_change(  ) {
			Obj_Machinery M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery) )) {
				M = _a;
				
				M.power_change();
			}

			if ( this.fire || this.eject || this.party == true ) {
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public bool powered( dynamic chan = null ) {
			
			if ( !this.requires_power ) {
				return true;
			}

			if ( this.always_unpowered ) {
				return false;
			}

			dynamic _a = chan; // Was a switch-case, sorry for the mess.
			if ( _a==1 ) {
				return this.power_equip;
			} else if ( _a==2 ) {
				return this.power_light;
			} else if ( _a==3 ) {
				return this.power_environ;
			}
			return false;
		}

		// Function from file: areas.dm
		public void updateicon(  ) {
			
			if ( ( this.fire || this.eject || this.party == true || this.radalert ) && ( !this.requires_power ? !this.requires_power : this.power_environ ) ) {
				
				if ( this.radalert && !this.fire ) {
					this.icon_state = "radiation";
				} else if ( this.fire && !this.radalert && !this.eject && !( this.party == true ) ) {
					this.icon_state = "blue";
				} else if ( !this.fire && this.eject && !( this.party == true ) ) {
					this.icon_state = "red";
				} else if ( this.party == true && !this.fire && !this.eject ) {
					this.icon_state = "party";
				} else {
					this.icon_state = "blue-red";
				}
			} else {
				this.icon_state = null;
			}
			return;
		}

		// Function from file: areas.dm
		public void partyreset(  ) {
			
			if ( this.party == true ) {
				this.party = false;
				this.mouse_opacity = 0;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void partyalert(  ) {
			
			if ( this.type == typeof(Zone) ) {
				return;
			}

			if ( !( this.party == true ) ) {
				this.party = true;
				this.updateicon();
				this.mouse_opacity = 0;
			}
			return;
		}

		// Function from file: areas.dm
		public void readyreset(  ) {
			
			if ( this.eject ) {
				this.eject = false;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void readyalert(  ) {
			
			if ( this.type == typeof(Zone) ) {
				return;
			}

			if ( !this.eject ) {
				this.eject = true;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void reset_radiation_alert(  ) {
			
			if ( this.type == typeof(Zone) ) {
				return;
			}

			if ( this.radalert ) {
				this.radalert = false;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void radiation_alert(  ) {
			
			if ( this.type == typeof(Zone) ) {
				return;
			}

			if ( !this.radalert ) {
				this.radalert = true;
				this.updateicon();
			}
			return;
		}

		// Function from file: areas.dm
		public void firereset(  ) {
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon_Ai aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;

			
			if ( this.fire ) {
				this.fire = false;
				this.mouse_opacity = 0;
				this.updateicon();

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Camera) )) {
					C = _a;
					
					C.network.Remove( "Fire Alarms" );
				}

				foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
					aiPlayer = _b;
					
					aiPlayer.cancelAlarm( "Fire", this, this );
				}

				foreach (dynamic _c in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
					a = _c;
					
					Interface13.Stat( null, a.covered_areas.Contains( this ) );

					if ( a is Obj_Machinery_Computer_StationAlert ) {
						a.cancelAlarm( "Fire", this, this );
					}
				}
				this.door_alerts &= 65533;
				this.UpdateFirelocks();
			}
			return;
		}

		// Function from file: areas.dm
		public void send_firealert( Obj_Machinery_Computer_StationAlert a = null ) {
			
			if ( this.fire ) {
				a.triggerAlarm( "Fire", this, null, this );
			}
			return;
		}

		// Function from file: areas.dm
		public void firealert(  ) {
			ByTable cameras = null;
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon_Ai aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;

			
			if ( this.type == typeof(Zone) ) {
				return;
			}

			if ( !this.fire ) {
				this.fire = true;
				this.updateicon();
				this.mouse_opacity = 0;
				this.door_alerts |= 2;
				this.UpdateFirelocks();
				cameras = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Camera) )) {
					C = _a;
					
					cameras.Add( C );
					C.network.Add( "Fire Alarms" );
				}

				foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon_Ai) )) {
					aiPlayer = _b;
					
					aiPlayer.triggerAlarm( "Fire", this, cameras, this );
				}

				foreach (dynamic _c in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
					a = _c;
					
					Interface13.Stat( null, a.covered_areas.Contains( this ) );

					if ( a is Obj_Machinery_Computer_StationAlert ) {
						a.triggerAlarm( "Fire", this, cameras, this );
					}
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void OpenFirelocks(  ) {
			Obj_Machinery_Door_Firedoor D = null;

			
			if ( !this.doors_down ) {
				return;
			}
			this.doors_down = false;

			foreach (dynamic _a in Lang13.Enumerate( this.all_doors, typeof(Obj_Machinery_Door_Firedoor) )) {
				D = _a;
				

				if ( !D.blocked ) {
					
					if ( D.operating != 0 ) {
						D.nextstate = 1;
					} else if ( D.density ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							D.open();
							return;
						}));
					}
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void CloseFirelocks(  ) {
			Obj_Machinery_Door_Firedoor D = null;

			
			if ( this.doors_down ) {
				return;
			}
			this.doors_down = true;

			foreach (dynamic _a in Lang13.Enumerate( this.all_doors, typeof(Obj_Machinery_Door_Firedoor) )) {
				D = _a;
				

				if ( !D.blocked ) {
					
					if ( D.operating != 0 ) {
						D.nextstate = GlobalVars.CLOSED;
					} else if ( !D.density ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							D.close();
							return;
						}));
					}
				}
			}
			return;
		}

		// Function from file: areas.dm
		public void UpdateFirelocks(  ) {
			
			if ( this.door_alerts != 0 ) {
				this.CloseFirelocks();
			} else {
				this.OpenFirelocks();
			}
			return;
		}

		// Function from file: areas.dm
		public void sendDangerLevel( Obj_Machinery_Computer_StationAlert a = null ) {
			int danger_level = 0;
			Obj_Machinery_Alarm AA = null;
			int reported_danger_level = 0;

			danger_level = 0;

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Alarm) )) {
				AA = _a;
				

				if ( ( AA.stat & 3 ) != 0 || AA.shorted || AA.buildstage != 2 ) {
					continue;
				}
				reported_danger_level = AA.local_danger_level;

				if ( AA.alarmActivated ) {
					reported_danger_level = 2;
				}

				if ( reported_danger_level > danger_level ) {
					danger_level = reported_danger_level;
				}
			}

			if ( danger_level == 2 ) {
				a.triggerAlarm( "Atmosphere", this, null, this );
			}
			return;
		}

		// Function from file: areas.dm
		public bool updateDangerLevel(  ) {
			int danger_level = 0;
			Obj_Machinery_Alarm AA = null;
			int reported_danger_level = 0;
			ByTable cameras = null;
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;
			Obj_Machinery_Camera C2 = null;
			Mob_Living_Silicon aiPlayer2 = null;
			Obj_Machinery_Computer_StationAlert a2 = null;
			Obj_Machinery_Alarm AA2 = null;

			danger_level = 0;

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Alarm) )) {
				AA = _a;
				

				if ( ( AA.stat & 3 ) != 0 || AA.shorted || AA.buildstage != 2 ) {
					continue;
				}
				reported_danger_level = AA.local_danger_level;

				if ( AA.alarmActivated ) {
					reported_danger_level = 2;
				}

				if ( reported_danger_level > danger_level ) {
					danger_level = reported_danger_level;
				}
			}

			if ( danger_level != this.atmosalm ) {
				
				if ( danger_level == 2 ) {
					cameras = new ByTable();

					foreach (dynamic _b in Lang13.Enumerate( this, typeof(Obj_Machinery_Camera) )) {
						C = _b;
						
						cameras.Add( C );
						C.network.Add( "Atmosphere Alarms" );
					}

					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
						aiPlayer = _c;
						
						aiPlayer.triggerAlarm( "Atmosphere", this, cameras, this );
					}

					foreach (dynamic _d in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						a = _d;
						
						Interface13.Stat( null, a.covered_areas.Contains( this ) );

						if ( a is Obj_Machinery_Computer_StationAlert ) {
							a.triggerAlarm( "Atmosphere", this, cameras, this );
						}
					}
					this.door_alerts |= 1;
					this.UpdateFirelocks();
				} else if ( this.atmosalm == 2 ) {
					
					foreach (dynamic _e in Lang13.Enumerate( this, typeof(Obj_Machinery_Camera) )) {
						C2 = _e;
						
						C2.network.Remove( "Atmosphere Alarms" );
					}

					foreach (dynamic _f in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
						aiPlayer2 = _f;
						
						aiPlayer2.cancelAlarm( "Atmosphere", this, this );
					}

					foreach (dynamic _g in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						a2 = _g;
						
						Interface13.Stat( null, a2.covered_areas.Contains( this ) );

						if ( a2 is Obj_Machinery_Computer_StationAlert ) {
							a2.cancelAlarm( "Atmosphere", this, this );
						}
					}
					this.door_alerts &= 65534;
					this.UpdateFirelocks();
				}
				this.atmosalm = danger_level;

				foreach (dynamic _h in Lang13.Enumerate( this, typeof(Obj_Machinery_Alarm) )) {
					AA2 = _h;
					

					if ( !( ( AA2.stat & 3 ) != 0 ) && !AA2.shorted ) {
						AA2.update_icon();
					}
				}
				return true;
			}
			return false;
		}

		// Function from file: areas.dm
		public void send_poweralert( Obj_Machinery_Computer_StationAlert a = null ) {
			
			if ( !this.poweralm ) {
				a.triggerAlarm( "Power", this, null, this );
			}
			return;
		}

		// Function from file: areas.dm
		public virtual void poweralert( bool state = false, Ent_Static source = null ) {
			ByTable cameras = null;
			Obj_Machinery_Camera C = null;
			Mob_Living_Silicon aiPlayer = null;
			Obj_Machinery_Computer_StationAlert a = null;

			
			if ( GlobalVars.suspend_alert ) {
				return;
			}

			if ( state != this.poweralm ) {
				this.poweralm = state;

				if ( source is Obj ) {
					cameras = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Machinery_Camera) )) {
						C = _a;
						
						cameras.Add( C );

						if ( state ) {
							C.network.Remove( "Power Alarms" );
						} else {
							C.network.Add( "Power Alarms" );
						}
					}

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Silicon) )) {
						aiPlayer = _b;
						

						if ( aiPlayer.z == source.z ) {
							
							if ( state ) {
								aiPlayer.cancelAlarm( "Power", this, source );
							} else {
								aiPlayer.triggerAlarm( "Power", this, cameras, source );
							}
						}
					}

					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_StationAlert) )) {
						a = _c;
						
						Interface13.Stat( null, a.covered_areas.Contains( this ) );

						if ( a is Obj_Machinery_Computer_StationAlert ) {
							
							if ( state ) {
								a.cancelAlarm( "Power", this, source );
							} else {
								a.triggerAlarm( "Power", this, cameras, source );
							}
						}
					}
				}
			}
			return;
		}

		// Function from file: unsorted.dm
		public dynamic copy_contents_to( dynamic A = null, bool? platingRequired = null ) {
			platingRequired = platingRequired ?? false;

			ByTable turfs_src = null;
			ByTable turfs_trg = null;
			bool src_min_x = false;
			bool src_min_y = false;
			dynamic T = null;
			bool trg_min_x = false;
			bool trg_min_y = false;
			dynamic T2 = null;
			ByTable refined_src = null;
			dynamic T3 = null;
			Coords C = null;
			ByTable refined_trg = null;
			dynamic T4 = null;
			Coords C2 = null;
			ByTable toupdate = null;
			ByTable copiedobjs = null;
			dynamic T5 = null;
			Coords C_src = null;
			dynamic B = null;
			Coords C_trg = null;
			dynamic old_dir1 = null;
			dynamic old_icon_state1 = null;
			dynamic old_icon1 = null;
			dynamic X = null;
			ByTable objs = null;
			ByTable newobjs = null;
			ByTable mobs = null;
			ByTable newmobs = null;
			Obj O = null;
			Obj O2 = null;
			Obj O3 = null;
			dynamic M = null;
			dynamic M2 = null;
			dynamic M3 = null;
			dynamic V = null;
			ByTable doors = null;
			Tile_Simulated T1 = null;
			Obj_Machinery_Door D2 = null;
			Obj O4 = null;

			
			if ( !Lang13.Bool( A ) || !( this != null ) ) {
				return 0;
			}
			turfs_src = GlobalFuncs.get_area_turfs( this.type );
			turfs_trg = GlobalFuncs.get_area_turfs( A.type );
			src_min_x = false;
			src_min_y = false;

			foreach (dynamic _a in Lang13.Enumerate( turfs_src )) {
				T = _a;
				

				if ( Convert.ToDouble( T.x ) < ( src_min_x ?1:0) || !src_min_x ) {
					src_min_x = Lang13.Bool( T.x );
				}

				if ( Convert.ToDouble( T.y ) < ( src_min_y ?1:0) || !src_min_y ) {
					src_min_y = Lang13.Bool( T.y );
				}
			}
			trg_min_x = false;
			trg_min_y = false;

			foreach (dynamic _b in Lang13.Enumerate( turfs_trg )) {
				T2 = _b;
				

				if ( Convert.ToDouble( T2.x ) < ( trg_min_x ?1:0) || !trg_min_x ) {
					trg_min_x = Lang13.Bool( T2.x );
				}

				if ( Convert.ToDouble( T2.y ) < ( trg_min_y ?1:0) || !trg_min_y ) {
					trg_min_y = Lang13.Bool( T2.y );
				}
			}
			refined_src = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( turfs_src )) {
				T3 = _c;
				
				refined_src.Add( T3 );
				refined_src[T3] = new Coords();
				C = refined_src[T3];
				C.x_pos = Lang13.DoubleNullable( T3.x - src_min_x );
				C.y_pos = Lang13.DoubleNullable( T3.y - src_min_y );
			}
			refined_trg = new ByTable();

			foreach (dynamic _d in Lang13.Enumerate( turfs_trg )) {
				T4 = _d;
				
				refined_trg.Add( T4 );
				refined_trg[T4] = new Coords();
				C2 = refined_trg[T4];
				C2.x_pos = Lang13.DoubleNullable( T4.x - trg_min_x );
				C2.y_pos = Lang13.DoubleNullable( T4.y - trg_min_y );
			}
			toupdate = new ByTable();
			copiedobjs = new ByTable();

			foreach (dynamic _m in Lang13.Enumerate( refined_src )) {
				T5 = _m;
				
				C_src = refined_src[T5];
				string _loop_ctrl_1 = null;

				foreach (dynamic _l in Lang13.Enumerate( refined_trg )) {
					B = _l;
					
					C_trg = refined_trg[B];

					if ( C_src.x_pos == C_trg.x_pos && C_src.y_pos == C_trg.y_pos ) {
						old_dir1 = T5.dir;
						old_icon_state1 = T5.icon_state;
						old_icon1 = T5.icon;

						if ( platingRequired == true ) {
							
							if ( B is Tile_Space ) {
								_loop_ctrl_1 = "continue";
								break;
							}
						}
						X = ((Tile)B).ChangeTurf( T5.type );
						X.dir = old_dir1;
						X.icon_state = old_icon_state1;
						X.icon = old_icon1;
						objs = new ByTable();
						newobjs = new ByTable();
						mobs = new ByTable();
						newmobs = new ByTable();

						foreach (dynamic _e in Lang13.Enumerate( T5, typeof(Obj) )) {
							O = _e;
							

							if ( !( O is Obj ) ) {
								continue;
							}
							objs.Add( O );
						}

						foreach (dynamic _f in Lang13.Enumerate( objs, typeof(Obj) )) {
							O2 = _f;
							
							newobjs.Add( GlobalFuncs.DuplicateObject( O2, true ) );
						}

						foreach (dynamic _g in Lang13.Enumerate( newobjs, typeof(Obj) )) {
							O3 = _g;
							
							O3.loc = X;
						}

						foreach (dynamic _h in Lang13.Enumerate( T5 )) {
							M = _h;
							

							if ( !((Ent_Dynamic)M).can_shuttle_move() ) {
								continue;
							}
							mobs.Add( M );
						}

						foreach (dynamic _i in Lang13.Enumerate( mobs )) {
							M2 = _i;
							
							newmobs.Add( GlobalFuncs.DuplicateObject( M2, true ) );
						}

						foreach (dynamic _j in Lang13.Enumerate( newmobs )) {
							M3 = _j;
							
							M3.loc = X;
						}
						copiedobjs.Add( newobjs );
						copiedobjs.Add( newmobs );

						foreach (dynamic _k in Lang13.Enumerate( T5.vars )) {
							V = _k;
							
							Interface13.Stat( null, new ByTable(new object [] { "type", "loc", "locs", "vars", "parent", "parent_type", "verbs", "ckey", "key", "x", "y", "z", "contents", "luminosity" }).Contains( V ) );

							if ( !false ) {
								X.vars[V] = T5.vars[V];
							}
						}
						toupdate.Add( X );
						refined_src.Remove( T5 );
						refined_trg.Remove( B );
						_loop_ctrl_1 = "continue";
						break;
					}
				}

				if ( _loop_ctrl_1 == "break" ) {
					break;
				} else if ( _loop_ctrl_1 == "continue" ) {
					continue;
				}
			}
			doors = new ByTable();

			if ( toupdate.len != 0 ) {
				
				foreach (dynamic _o in Lang13.Enumerate( toupdate, typeof(Tile_Simulated) )) {
					T1 = _o;
					

					foreach (dynamic _n in Lang13.Enumerate( T1, typeof(Obj_Machinery_Door) )) {
						D2 = _n;
						
						doors.Add( D2 );
					}
				}
			}

			foreach (dynamic _p in Lang13.Enumerate( doors, typeof(Obj) )) {
				O4 = _p;
				
				((Obj_Structure_WindoorAssembly)O4).update_nearby_tiles();
			}
			return copiedobjs;
		}

		// Function from file: unsorted.dm
		public void addSorted(  ) {
			GlobalVars.sortedAreas.Add( this );
			GlobalFuncs.sortTim( GlobalVars.sortedAreas, typeof(GlobalFuncs).GetMethod( "cmp_name_asc" ) );
			return;
		}

	}

}