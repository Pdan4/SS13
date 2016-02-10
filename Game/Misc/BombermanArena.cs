// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class BombermanArena : Game_Data {

		public string name = "Bomberman Arena";
		public int status = 0;
		public dynamic shape = "";
		public bool violence = true;
		public bool opacity = false;
		public int min_number_of_players = 2;
		public Zone arena = null;
		public dynamic under = null;
		public dynamic center = null;
		public ByTable planners = new ByTable();
		public ByTable cameras = new ByTable();
		public ByTable spawns = new ByTable();
		public ByTable turfs = new ByTable();
		public ByTable swalls = new ByTable();
		public ByTable gladiators = new ByTable();
		public ByTable tools = new ByTable();
		public int auto_start = 60;
		public bool counting = false;

		// Function from file: bomberman.dm
		public BombermanArena ( dynamic a_center = null, dynamic size = null, Mob user = null ) {
			size = size ?? "";

			BombermanSpawn S = null;
			Obj_Structure_Planner_Spawnpoint P = null;

			
			if ( !Lang13.Bool( a_center ) ) {
				return;
			}

			if ( !Lang13.Bool( size ) ) {
				return;
			}

			if ( !( user != null ) ) {
				return;
			}
			this.center = a_center;
			this.name += " #" + Rand13.Int( 1, 999 );
			this.open( size, user );
			GlobalVars.arenas.Add( this );
			this.status = 1;
			this.shape = size;

			foreach (dynamic _a in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
				S = _a;
				
				P = new Obj_Structure_Planner_Spawnpoint( S.spawnpoint, this, S );
				S.icon = P;
				this.planners.Add( P );
			}
			return;
		}

		// Function from file: bomberman.dm
		public bool planner( dynamic size = null, Mob user = null ) {
			bool choice = false;
			Obj_Structure_Planner pencil = null;
			int w = 0;
			int h = 0;
			int x = 0;
			int y = 0;
			Ent_Static T = null;
			Obj_Structure_Planner P = null;
			string achoice = null;
			dynamic T2 = null;
			Obj_Structure_Planner P2 = null;
			string achoice2 = null;
			Obj_Structure_Planner pencil2 = null;
			int w2 = 0;
			int h2 = 0;
			int x2 = 0;
			int y2 = 0;
			Ent_Static T3 = null;
			Obj_Structure_Planner P3 = null;
			string achoice3 = null;
			Obj_Structure_Planner P4 = null;

			choice = false;

			dynamic _b = size; // Was a switch-case, sorry for the mess.
			if ( _b=="15x13 (2 players)" ) {
				pencil = new Obj_Structure_Planner( this.center, this );
				w = 14;
				h = 12;
				pencil.x -= ((int)( w / 2 ));
				pencil.y -= ((int)( h / 2 ));
				x = pencil.x;
				y = pencil.y;
				T = null;

				while (pencil.y <= y + h) {
					pencil.x = x;

					while (pencil.x <= x + w) {
						T = pencil.loc;
						P = new Obj_Structure_Planner( T, this );

						if ( P.loc != null ) {
							this.planners.Add( P );
						}
						pencil.x++;
					}
					pencil.y++;
				}
				GlobalFuncs.qdel( pencil );

				if ( this.planners.len == 195 ) {
					achoice = Interface13.Alert( user, "All those green tiles (that only ghosts can see) will be part of the arena. Do you want to proceed?", "Arena Creation", "Confirm", "Cancel" );

					if ( achoice == "Confirm" ) {
						choice = true;
					}
				}
			} else if ( _b=="15x15 (4 players)" ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( 7, this.center ) )) {
					T2 = _a;
					
					P2 = new Obj_Structure_Planner( T2, this );

					if ( P2.loc != null ) {
						this.planners.Add( P2 );
					}
				}

				if ( this.planners.len == 225 ) {
					achoice2 = Interface13.Alert( user, "All those green tiles (that only ghosts can see) will be part of the arena. Do you want to proceed?", "Arena Creation", "Confirm", "Cancel" );

					if ( achoice2 == "Confirm" ) {
						choice = true;
					}
				} else {
					GlobalFuncs.to_chat( user, "<span class='warning'>Part of the arena was outside the Z-Level.</span>" );
				}
			} else if ( _b=="39x23 (10 players)" ) {
				pencil2 = new Obj_Structure_Planner( this.center, this );
				w2 = 38;
				h2 = 22;
				pencil2.x -= ((int)( w2 / 2 ));
				pencil2.y -= ((int)( h2 / 2 ));
				x2 = pencil2.x;
				y2 = pencil2.y;
				T3 = null;

				while (pencil2.y <= y2 + h2) {
					pencil2.x = x2;

					while (pencil2.x <= x2 + w2) {
						T3 = pencil2.loc;
						P3 = new Obj_Structure_Planner( T3, this );

						if ( P3.loc != null ) {
							this.planners.Add( P3 );
						}
						pencil2.x++;
					}
					pencil2.y++;
				}
				GlobalFuncs.qdel( pencil2 );

				if ( this.planners.len == 897 ) {
					achoice3 = Interface13.Alert( user, "All those green tiles (that only ghosts can see) will be part of the arena. Do you want to proceed?", "Arena Creation", "Confirm", "Cancel" );

					if ( achoice3 == "Confirm" ) {
						choice = true;
					}
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( this.planners, typeof(Obj_Structure_Planner) )) {
				P4 = _c;
				
				GlobalFuncs.qdel( P4 );
			}
			return choice;
		}

		// Function from file: bomberman.dm
		public void countin(  ) {
			Obj_Structure_Planner_Spawnpoint S = null;
			Obj_Structure_Planner_Spawnpoint S2 = null;

			
			if ( this.counting ) {
				this.auto_start--;

				foreach (dynamic _a in Lang13.Enumerate( this.arena, typeof(Obj_Structure_Planner_Spawnpoint) )) {
					S = _a;
					
					S.update_overlay( this.auto_start );
				}

				if ( this.auto_start <= 0 ) {
					this.counting = false;
					this.auto_start = 60;

					foreach (dynamic _b in Lang13.Enumerate( this.arena, typeof(Obj_Structure_Planner_Spawnpoint) )) {
						S2 = _b;
						
						S2.overlays.len = 0;
					}
					this.start();
					return;
				}
				Task13.Sleep( 10 );
				this.countin();
			}
			return;
		}

		// Function from file: bomberman.dm
		public void update_ready(  ) {
			ByTable ready = null;
			int slots = 0;
			BombermanSpawn S = null;
			Obj_Structure_Planner_Spawnpoint S2 = null;

			ready = new ByTable();
			slots = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
				S = _a;
				
				slots++;

				if ( S.player_client != null ) {
					
					if ( S.player_client.mob is Mob_Dead_Observer ) {
						ready.Add( S.player_client );
					} else {
						S.icon.ghost_unsubscribe( S.player_client.mob );
					}
				}
			}

			if ( slots == ready.len ) {
				this.start(  );
			} else if ( ready.len >= this.min_number_of_players ) {
				
				if ( !this.counting ) {
					this.counting = true;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.countin();
						return;
					}));
				}
			} else if ( this.counting ) {
				this.counting = false;
				this.auto_start = 60;

				foreach (dynamic _b in Lang13.Enumerate( this.arena, typeof(Obj_Structure_Planner_Spawnpoint) )) {
					S2 = _b;
					
					S2.overlays.len = 0;
				}
			}
			return;
		}

		// Function from file: bomberman.dm
		public void close( bool? open_space = null ) {
			open_space = open_space ?? true;

			Obj_Structure_Planner P = null;
			Obj_Machinery_Camera C = null;
			Obj_Structure_Softwall W = null;
			Obj T = null;
			Mob_Living M = null;
			Obj_Item_Weapon_Organ O = null;
			Obj_Effect_Decal_Cleanable C2 = null;
			BombermanSpawn S = null;
			dynamic T2 = null;
			Ent_Dynamic AM = null;

			this.status = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.planners, typeof(Obj_Structure_Planner) )) {
				P = _a;
				
				GlobalFuncs.qdel( P );
			}

			foreach (dynamic _b in Lang13.Enumerate( this.cameras, typeof(Obj_Machinery_Camera) )) {
				C = _b;
				
				GlobalFuncs.qdel( C );
			}
			this.cameras = new ByTable();

			foreach (dynamic _c in Lang13.Enumerate( this.swalls, typeof(Obj_Structure_Softwall) )) {
				W = _c;
				
				GlobalFuncs.qdel( W );
			}
			this.swalls = new ByTable();

			foreach (dynamic _d in Lang13.Enumerate( this.tools, typeof(Obj) )) {
				T = _d;
				
				GlobalFuncs.qdel( T );
			}
			this.tools = new ByTable();

			foreach (dynamic _e in Lang13.Enumerate( this.gladiators, typeof(Mob_Living) )) {
				M = _e;
				

				if ( M != null ) {
					GlobalFuncs.qdel( M );
				}
			}
			this.gladiators = new ByTable();

			foreach (dynamic _f in Lang13.Enumerate( this.arena, typeof(Obj_Item_Weapon_Organ) )) {
				O = _f;
				
				GlobalFuncs.qdel( O );
			}

			foreach (dynamic _g in Lang13.Enumerate( this.arena, typeof(Obj_Effect_Decal_Cleanable) )) {
				C2 = _g;
				
				GlobalFuncs.qdel( C2 );
			}

			foreach (dynamic _h in Lang13.Enumerate( this.arena, typeof(BombermanSpawn) )) {
				S = _h;
				
				GlobalVars.arena_spawnpoints.Remove( S );

				if ( S.player_client != null ) {
					GlobalVars.ready_gladiators.Remove( S.player_client );
				}
				S.player_client = null;
				S.player_mob = null;
			}
			this.under.contents.Add( this.turfs );

			foreach (dynamic _j in Lang13.Enumerate( this.turfs )) {
				T2 = _j;
				

				foreach (dynamic _i in Lang13.Enumerate( T2, typeof(Ent_Dynamic) )) {
					AM = _i;
					
					AM.areaMaster = GlobalFuncs.get_area_master( T2 );
				}

				if ( open_space == true && this.under.name == "Space" ) {
					((Tile)T2).ChangeTurf( GlobalFuncs.get_base_turf( T2.z ) );
				} else {
					((Tile)T2).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
				}
				T2.maptext = null;
			}
			this.turfs = new ByTable();
			GlobalVars.arenas.Remove( this );
			return;
		}

		// Function from file: bomberman.dm
		public void reset(  ) {
			Obj_Structure_Planner_Spawnpoint S = null;
			BombermanSpawn S2 = null;
			Obj_Structure_Powerup P = null;
			Obj_Item_Clothing C = null;
			Obj_Item_Weapon_Organ O = null;
			Mob_Living M = null;
			Obj_Structure_Softwall W = null;
			Obj T = null;
			Obj_Structure_Planner pencil = null;
			int w = 0;
			int h = 0;
			int x = 0;
			int y = 0;
			Ent_Static T2 = null;
			Obj_Structure_Softwall W2 = null;
			BombermanSpawn S3 = null;
			Obj_Structure_Softwall W3 = null;

			this.status = 0;

			if ( this.counting ) {
				this.counting = false;
				this.auto_start = 60;

				foreach (dynamic _a in Lang13.Enumerate( this.arena, typeof(Obj_Structure_Planner_Spawnpoint) )) {
					S = _a;
					
					S.overlays.len = 0;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
				S2 = _b;
				
				S2.availability = false;
				S2.icon.icon_state = "planner_ready";
			}

			foreach (dynamic _c in Lang13.Enumerate( this.arena, typeof(Obj_Structure_Powerup) )) {
				P = _c;
				
				GlobalFuncs.qdel( P );
			}

			foreach (dynamic _d in Lang13.Enumerate( this.arena, typeof(Obj_Item_Clothing) )) {
				C = _d;
				
				GlobalFuncs.qdel( C );
			}

			foreach (dynamic _e in Lang13.Enumerate( this.arena, typeof(Obj_Item_Weapon_Organ) )) {
				O = _e;
				
				GlobalFuncs.qdel( O );
			}

			foreach (dynamic _f in Lang13.Enumerate( this.gladiators, typeof(Mob_Living) )) {
				M = _f;
				

				if ( M != null ) {
					GlobalFuncs.qdel( M );
				}
			}
			this.gladiators = new ByTable();

			foreach (dynamic _g in Lang13.Enumerate( this.swalls, typeof(Obj_Structure_Softwall) )) {
				W = _g;
				
				GlobalFuncs.qdel( W );
			}
			this.swalls = new ByTable();

			foreach (dynamic _h in Lang13.Enumerate( this.tools, typeof(Obj) )) {
				T = _h;
				
				GlobalFuncs.qdel( T );
			}
			this.tools = new ByTable();
			pencil = new Obj_Structure_Planner( this.center, this );
			w = 1;
			h = 1;

			dynamic _i = this.shape; // Was a switch-case, sorry for the mess.
			if ( _i=="15x13 (2 players)" ) {
				w = 14;
				h = 12;
			} else if ( _i=="15x15 (4 players)" ) {
				w = 14;
				h = 14;
			} else if ( _i=="39x23 (10 players)" ) {
				w = 38;
				h = 22;
			}
			pencil.x -= ((int)( w / 2 ));
			pencil.y -= ((int)( h / 2 ));
			x = pencil.x;
			y = pencil.y;
			T2 = null;
			Task13.Sleep( 40 );

			while (pencil.y <= y + h) {
				pencil.x = x;

				while (pencil.x <= x + w) {
					T2 = pencil.loc;

					if ( T2 is Tile_Simulated_Floor_Plating ) {
						
						if ( Rand13.PercentChance( 60 ) ) {
							T2 = pencil.loc;
							W2 = new Obj_Structure_Softwall( T2 );
							this.swalls.Add( W2 );

							if ( this.opacity ) {
								W2.opacity = true;
							}
						}
					}
					pencil.x++;
				}
				Task13.Sleep( 2 );
				pencil.y++;
			}
			GlobalFuncs.qdel( pencil );

			foreach (dynamic _k in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
				S3 = _k;
				

				foreach (dynamic _j in Lang13.Enumerate( Map13.FetchInRange( 1, S3.spawnpoint ), typeof(Obj_Structure_Softwall) )) {
					W3 = _j;
					
					this.swalls.Remove( W3 );
					GlobalFuncs.qdel( W3 );
				}

				if ( S3.player_client != null ) {
					GlobalVars.ready_gladiators.Remove( S3.player_client );
				}
				S3.player_mob = null;
				S3.player_client = null;
				S3.availability = true;
				S3.icon.icon_state = "planner";
			}
			this.status = 1;
			return;
		}

		// Function from file: bomberman.dm
		public void end(  ) {
			Ent_Static winner = null;
			Obj_Item_Weapon_Bomberman W = null;
			dynamic M = null;

			
			if ( this.tools.len > 1 ) {
				return;
			}

			if ( this.status == 3 ) {
				return;
			}
			this.status = 3;
			winner = null;

			foreach (dynamic _a in Lang13.Enumerate( this.tools, typeof(Obj_Item_Weapon_Bomberman) )) {
				W = _a;
				
				W.hurt_players = true;

				if ( W.loc is Mob_Living ) {
					winner = W.loc;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.arena )) {
				M = _b;
				

				if ( winner != null && Lang13.Bool( ((dynamic)winner).client ) ) {
					GlobalFuncs.to_chat( M, "" + ( winner != null ? "<b>" + ((dynamic)winner).client.key + "</b> as <b>" + winner.name + "</b> wins this round! " : "" ) + "Resetting arena in 20 seconds." );
				} else {
					GlobalFuncs.to_chat( M, "Couldn't find a winner. Resetting arena in 20 seconds." );
				}
			}

			if ( winner != null ) {
				Interface13.Stat( null, GlobalVars.arena_leaderboard.Contains( ((dynamic)winner).client.key ) );

				if ( false ) {
					GlobalVars.arena_leaderboard[((dynamic)winner).client.key] = GlobalVars.arena_leaderboard[((dynamic)winner).client.key] + 1;
				} else {
					GlobalVars.arena_leaderboard.Add( ((dynamic)winner).client.key );
					GlobalVars.arena_leaderboard[((dynamic)winner).client.key] = 1;
				}
			}
			GlobalVars.arena_rounds++;
			Task13.Sleep( 200 );
			this.reset();
			return;
		}

		// Function from file: bomberman.dm
		public void start(  ) {
			Obj_Structure_Planner_Spawnpoint S = null;
			Obj_Structure_Planner_Spawnpoint P = null;
			int readied = 0;
			BombermanSpawn S2 = null;
			Client C = null;
			Mob client_mob = null;
			Mob_Living_Carbon_Human M = null;
			dynamic M2 = null;
			dynamic M3 = null;
			BombermanSpawn S3 = null;
			dynamic M4 = null;
			Obj_Machinery_Computer_Security_Telescreen_Entertainment E = null;
			Mob_Dead_Observer O = null;
			dynamic M5 = null;

			this.status = 2;

			if ( this.counting ) {
				this.counting = false;
				this.auto_start = 60;

				foreach (dynamic _a in Lang13.Enumerate( this.arena, typeof(Obj_Structure_Planner_Spawnpoint) )) {
					S = _a;
					
					S.overlays.len = 0;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( this.planners, typeof(Obj_Structure_Planner_Spawnpoint) )) {
				P = _b;
				
				P.icon_state = "planner_ready";
			}
			readied = 0;

			foreach (dynamic _c in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
				S2 = _c;
				
				S2.availability = false;
				S2.icon.icon_state = "planner_ready";

				if ( !( S2.player_client != null ) ) {
					continue;
				}
				C = S2.player_client;
				client_mob = C.mob;
				Interface13.Stat( null, GlobalVars.ready_gladiators.Contains( C ) );

				if ( !( S2.player_client != null ) ) {
					GlobalVars.ready_gladiators.Remove( C );
				}

				if ( !( client_mob is Mob_Dead_Observer ) ) {
					continue;
				}
				M = this.spawn_player( S2.spawnpoint );
				this.dress_player( M );
				M.stunned = 3;
				M.ckey = C.ckey;
				this.gladiators.Add( M );

				if ( S2.player_mob != null ) {
					GlobalFuncs.qdel( S2.player_mob );
				}
				S2.player_mob = M;

				if ( Lang13.Bool( S2.player_mob.ckey ) ) {
					readied++;
				}
			}

			if ( readied < this.min_number_of_players ) {
				this.status = 1;

				foreach (dynamic _d in Lang13.Enumerate( this.arena )) {
					M2 = _d;
					
					GlobalFuncs.to_chat( M2, "<span class='danger'>Not enough players. Round canceled.</span>" );
				}

				foreach (dynamic _e in Lang13.Enumerate( this.gladiators )) {
					M3 = _e;
					
					GlobalFuncs.qdel( M3 );
				}
				this.gladiators = new ByTable();

				foreach (dynamic _f in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
					S3 = _f;
					
					S3.player_mob = null;
					S3.player_client = null;
					S3.availability = true;
					S3.icon.icon_state = "planner";
				}
				return;
			}

			foreach (dynamic _g in Lang13.Enumerate( this.arena )) {
				M4 = _g;
				

				if ( this.violence ) {
					GlobalFuncs.to_chat( M4, "Violence Mode activated! Bombs hurt players! Suits offer no protections! Initial Flame Range increased!" );
				}

				if ( Lang13.Bool( M4.client ) ) {
					GlobalFuncs.to_chat( M4.client, new Sound( "sound/bomberman/start.ogg" ) );
				}
				GlobalFuncs.to_chat( M4, "<b>READY?</b>" );
			}

			foreach (dynamic _h in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Computer_Security_Telescreen_Entertainment) )) {
				E = _h;
				
				E.visible_message( new Txt( "<span style='color:grey'>" ).icon( E ).str( " " ).The( E ).item().str( " brightens as it appears that a round is starting in " ).item( this.name ).str( ".</span>" ).ToString() );
				Icon13.Flick( "entertainment_arena", E );
			}

			foreach (dynamic _i in Lang13.Enumerate( GlobalVars.observers, typeof(Mob_Dead_Observer) )) {
				O = _i;
				
				GlobalFuncs.to_chat( O, new Txt( "<b>A round has began in <A HREF='?src=" ).Ref( O ).str( ";jumptoarenacood=1;X=" ).item( this.center.x ).str( ";Y=" ).item( this.center.y ).str( ";Z=" ).item( this.center.z ).str( "'>" ).item( this.name ).str( "</A>!</b>" ).ToString() );
			}
			Task13.Sleep( 40 );

			foreach (dynamic _j in Lang13.Enumerate( this.arena )) {
				M5 = _j;
				
				GlobalFuncs.to_chat( M5, "<span class='danger'>GO!</span>" );
			}
			return;
		}

		// Function from file: bomberman.dm
		public void dress_player( Mob_Living_Carbon_Human M = null ) {
			Obj_Item_Clothing_Suit_Space_Bomberman bombsuit = null;
			Obj_Item_Weapon_Bomberman B = null;
			Obj_Item_Clothing C = null;

			M.equip_to_slot_or_del( new Obj_Item_Clothing_Under_Darkblue( M ), 14 );
			M.equip_to_slot_or_del( new Obj_Item_Clothing_Shoes_Purple( M ), 12 );
			M.equip_to_slot_or_del( new Obj_Item_Clothing_Head_Helmet_Space_Bomberman( M ), 11 );
			bombsuit = new Obj_Item_Clothing_Suit_Space_Bomberman( M );
			M.equip_to_slot_or_del( bombsuit, 13 );
			M.equip_to_slot_or_del( new Obj_Item_Clothing_Gloves_Purple( M ), 10 );
			B = new Obj_Item_Weapon_Bomberman( M );
			this.tools.Add( B );
			B.arena = this;

			if ( this.violence ) {
				B.hurt_players = true;
				B.bombpower = 2;
			} else {
				B.hurt_players = false;
			}
			B.destroy_environnement = false;
			M.equip_to_slot_or_del( B, 17 );
			bombsuit.slowdown = 1;

			foreach (dynamic _a in Lang13.Enumerate( M, typeof(Obj_Item_Clothing) )) {
				C = _a;
				
				C.canremove = false;

				if ( this.violence ) {
					C.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
				}
			}
			return;
		}

		// Function from file: bomberman.dm
		public Mob_Living_Carbon_Human spawn_player( Ent_Static T = null ) {
			Mob_Living_Carbon_Human M = null;
			ByTable randomhexes = null;

			M = new Mob_Living_Carbon_Human( T );
			M.name = "Bomberman #" + Rand13.Int( 1, 999 );
			M.real_name = M.name;
			randomhexes = new ByTable(new object [] { "7", "8", "9", "a", "b", "c", "d", "e", "f" });
			M.color = "#" + Rand13.PickFromTable( randomhexes ) + Rand13.PickFromTable( randomhexes ) + Rand13.PickFromTable( randomhexes ) + Rand13.PickFromTable( randomhexes ) + Rand13.PickFromTable( randomhexes ) + Rand13.PickFromTable( randomhexes );
			return M;
		}

		// Function from file: bomberman.dm
		public void open( dynamic size = null, Mob user = null ) {
			int x = 0;
			int y = 0;
			int w = 0;
			int h = 0;
			Obj_Machinery_Camera_Arena C = null;
			Obj_Structure_Planner pencil = null;
			Ent_Static T = null;
			BombermanSpawn sp1 = null;
			BombermanSpawn sp2 = null;
			BombermanSpawn sp3 = null;
			BombermanSpawn sp4 = null;
			BombermanSpawn sp5 = null;
			BombermanSpawn sp6 = null;
			BombermanSpawn sp7 = null;
			BombermanSpawn sp8 = null;
			BombermanSpawn sp9 = null;
			BombermanSpawn sp10 = null;
			Obj_Structure_Softwall W = null;
			BombermanSpawn S = null;
			Obj_Structure_Softwall W2 = null;
			Zone A = null;
			dynamic F = null;
			Ent_Dynamic AM = null;
			Mob_Dead_Observer O = null;

			x = 1;
			y = 1;
			w = 1;
			h = 1;

			dynamic _a = size; // Was a switch-case, sorry for the mess.
			if ( _a=="15x13 (2 players)" ) {
				w = 14;
				h = 12;
			} else if ( _a=="15x15 (4 players)" ) {
				w = 14;
				h = 14;
			} else if ( _a=="39x23 (10 players)" ) {
				w = 38;
				h = 22;
			}

			if ( this.planner( size, user ) ) {
				C = new Obj_Machinery_Camera_Arena( this.center );
				this.cameras.Add( C );
				C.name = this.name;
				C.c_tag = this.name;
				C.network = new ByTable(new object [] { "thunder", "SS13" });
				pencil = new Obj_Structure_Planner( this.center, this );
				pencil.x -= ((int)( w / 2 ));
				pencil.y -= ((int)( h / 2 ));
				x = pencil.x;
				y = pencil.y;
				T = null;
				this.under = GlobalFuncs.get_area( pencil );

				while (pencil.y <= y + h) {
					pencil.x = x;

					while (pencil.x <= x + w) {
						T = pencil.loc;

						if ( pencil.y == y || pencil.y == y + h ) {
							((dynamic)T).ChangeTurf( typeof(Tile_Unsimulated_Wall_Bomberman) );
							T.opacity = true;
							this.turfs.Add( T );
						} else if ( pencil.x == x || pencil.x == x + w ) {
							((dynamic)T).ChangeTurf( typeof(Tile_Unsimulated_Wall_Bomberman) );
							T.opacity = true;
							this.turfs.Add( T );
						} else if ( ( pencil.x - x ) % 2 == 0 && ( pencil.y - y ) % 2 == 0 ) {
							((dynamic)T).ChangeTurf( typeof(Tile_Unsimulated_Wall_Bomberman) );
							this.turfs.Add( T );

							if ( this.opacity ) {
								T.opacity = true;
							}
						} else {
							((dynamic)T).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
							this.turfs.Add( T );
						}
						pencil.x++;
					}
					Task13.Sleep( 2 );
					pencil.y++;
				}
				pencil.x = x;
				pencil.y = y;
				pencil.x++;
				pencil.y++;
				T = pencil.loc;

				if ( !( size == "15x13 (2 players)" ) ) {
					sp1 = new BombermanSpawn();
					sp1.spawnpoint = T;
					this.spawns.Add( sp1 );
				}
				pencil.x = x + w - 1;
				T = pencil.loc;
				sp2 = new BombermanSpawn();
				sp2.spawnpoint = T;
				this.spawns.Add( sp2 );
				pencil.y = y + h - 1;
				T = pencil.loc;

				if ( !( size == "15x13 (2 players)" ) ) {
					sp3 = new BombermanSpawn();
					sp3.spawnpoint = T;
					this.spawns.Add( sp3 );
				}
				pencil.x = x + 1;
				T = pencil.loc;
				sp4 = new BombermanSpawn();
				sp4.spawnpoint = T;
				this.spawns.Add( sp4 );

				if ( size == "39x23 (10 players)" ) {
					pencil.x = x + 10;
					pencil.y = y + 7;
					T = pencil.loc;
					sp5 = new BombermanSpawn();
					sp5.spawnpoint = T;
					this.spawns.Add( sp5 );
					pencil.x = x + 10;
					pencil.y = y + 15;
					T = pencil.loc;
					sp6 = new BombermanSpawn();
					sp6.spawnpoint = T;
					this.spawns.Add( sp6 );
					pencil.x = x + 19;
					pencil.y = y + 1;
					T = pencil.loc;
					sp7 = new BombermanSpawn();
					sp7.spawnpoint = T;
					this.spawns.Add( sp7 );
					pencil.x = x + 19;
					pencil.y = y + h - 1;
					T = pencil.loc;
					sp8 = new BombermanSpawn();
					sp8.spawnpoint = T;
					this.spawns.Add( sp8 );
					pencil.x = x + 28;
					pencil.y = y + 7;
					T = pencil.loc;
					sp9 = new BombermanSpawn();
					sp9.spawnpoint = T;
					this.spawns.Add( sp9 );
					pencil.x = x + 28;
					pencil.y = y + 15;
					T = pencil.loc;
					sp10 = new BombermanSpawn();
					sp10.spawnpoint = T;
					this.spawns.Add( sp10 );
				}
				pencil.x = x;
				pencil.y = y;

				while (pencil.y <= y + h) {
					pencil.x = x;

					while (pencil.x <= x + w) {
						T = pencil.loc;

						if ( T is Tile_Simulated_Floor_Plating ) {
							
							if ( Rand13.PercentChance( 60 ) ) {
								T = pencil.loc;
								W = new Obj_Structure_Softwall( T );
								this.swalls.Add( W );

								if ( this.opacity ) {
									W.opacity = true;
								}
							}
						}
						pencil.x++;
					}
					Task13.Sleep( 2 );
					pencil.y++;
				}
				pencil.x = x;
				pencil.y = y + h;
				T = pencil.loc;
				T.maptext = this.name;
				T.maptext_width = 256;
				GlobalFuncs.qdel( pencil );

				foreach (dynamic _c in Lang13.Enumerate( this.spawns, typeof(BombermanSpawn) )) {
					S = _c;
					

					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( 1, S.spawnpoint ), typeof(Obj_Structure_Softwall) )) {
						W2 = _b;
						
						this.swalls.Remove( W2 );
						GlobalFuncs.qdel( W2 );
					}
					S.availability = true;
				}
				A = new Zone();
				A.name = this.name;
				A.tag = "" + A.type + "/" + Num13.Md5( this.name );
				A.power_equip = false;
				A.power_light = false;
				A.power_environ = false;
				A.always_unpowered = false;
				A.jammed = 2;
				A.addSorted();
				this.arena = A;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					A.contents.Add( this.turfs );

					foreach (dynamic _e in Lang13.Enumerate( this.turfs )) {
						F = _e;
						

						foreach (dynamic _d in Lang13.Enumerate( F, typeof(Ent_Dynamic) )) {
							AM = _d;
							
							AM.areaMaster = GlobalFuncs.get_area_master( F );
						}
					}
					return;
				}));
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user.client ) + " created a \"" + size + "\" Bomberman arena at " + this.center.loc.name + " (" + this.center.x + "," + this.center.y + "," + this.center.z + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + this.center.x + ";Y=" + this.center.y + ";Z=" + this.center.z + "'>JMP</A>)" );
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + GlobalFuncs.key_name_admin( user.client ) + " created a \"" + size + "\" Bomberman arena at " + this.center.loc.name + " (" + this.center.x + "," + this.center.y + "," + this.center.z + ") " ) ) );

				foreach (dynamic _f in Lang13.Enumerate( GlobalVars.observers, typeof(Mob_Dead_Observer) )) {
					O = _f;
					
					GlobalFuncs.to_chat( O, new Txt( "<spawn class='notice'><b>" ).item( user.client.key ).str( " created a \"" ).item( size ).str( "\" Bomberman arena at " ).item( this.center.loc.name ).str( ". <A HREF='?src=" ).Ref( O ).str( ";jumptoarenacood=1;targetarena=" ).Ref( this ).str( "'>Click here to JUMP to it.</A></b></span>" ).ToString() );
				}
			} else {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: bomberman.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.arena = null;
			this.under = null;
			this.center = null;
			this.planners = null;
			this.cameras = null;
			this.spawns = null;
			this.turfs = null;
			this.swalls = null;
			this.gladiators = null;
			this.tools = null;
			return null;
		}

	}

}