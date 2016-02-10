// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MiningSurprise : Game_Data {

		public string name = "Hidden Complex";
		public ByTable floortypes = new ByTable( 0 );
		public ByTable walltypes = new ByTable( 0 );
		public ByTable spawntypes = new ByTable( 0 );
		public ByTable fluffitems = new ByTable( 0 );
		public int max_richness = 2;
		public int complex_max_size = 1;
		public int room_size_max = 5;
		public int flags = 0;
		public ByTable rooms = new ByTable();
		public ByTable goodies = new ByTable();
		public ByTable candidates = new ByTable();
		public Zone_Asteroid_Artifactroom complex_area = null;

		// Function from file: surprise.dm
		public bool spawn_room( Tile start_loc = null, int? x_size = null, int? y_size = null, bool? clean = null ) {
			clean = clean ?? false;

			dynamic wall_type = null;
			dynamic floor_type = null;
			ByTable walls = null;
			ByTable floors = null;
			int? x = null;
			int? y = null;
			Tile cur_loc = null;
			dynamic O = null;
			SurpriseRoom room = null;
			dynamic turf = null;
			SurpriseTurfInfo Ti = null;
			dynamic turf2 = null;
			SurpriseTurfInfo Ti2 = null;

			
			if ( !GlobalFuncs.check_complex_placement( start_loc, x_size, y_size ) ) {
				return false;
			}

			if ( ( this.flags & 1 ) != 0 ) {
				wall_type = GlobalFuncs.pickweight( this.walltypes );
			}

			if ( ( this.flags & 2 ) != 0 ) {
				floor_type = GlobalFuncs.pickweight( this.floortypes );
			}
			walls = new ByTable( 0 );
			floors = new ByTable( 0 );
			x = null;
			x = 0;

			while (( x ??0) < ( x_size ??0)) {
				y = null;
				y = 0;

				while (( y ??0) < ( y_size ??0)) {
					cur_loc = Map13.GetTile( start_loc.x + ( x ??0), start_loc.y + ( y ??0), start_loc.z );

					if ( clean == true ) {
						
						foreach (dynamic _a in Lang13.Enumerate( cur_loc )) {
							O = _a;
							

							if ( O is Dynamic_LightingOverlay ) {
								continue;
							}
							GlobalFuncs.qdel( O );
						}
					}

					if ( x == 0 || x == ( x_size ??0) - 1 || y == 0 || y == ( y_size ??0) - 1 ) {
						walls.Or( cur_loc );
					} else {
						floors.Or( cur_loc );
					}
					y++;
				}
				x++;
			}
			room = new SurpriseRoom();

			foreach (dynamic _b in Lang13.Enumerate( walls )) {
				turf = _b;
				

				if ( !( ( this.flags & 1 ) != 0 ) ) {
					wall_type = GlobalFuncs.pickweight( this.walltypes );
				}

				if ( GlobalFuncs.dd_hasprefix( "" + wall_type, "/obj" ) != 0 ) {
					
					if ( !( ( this.flags & 2 ) != 0 ) ) {
						floor_type = GlobalFuncs.pickweight( this.floortypes );
					}
					((Tile)turf).ChangeTurf( floor_type );
					Lang13.Call( wall_type, turf );
				} else {
					((Tile)turf).ChangeTurf( wall_type );
				}
				room.turfs.Add( turf );
				this.complex_area.contents.Add( turf );
				Ti = room.GetTurfInfo( turf );
				Ti.turf_type = true;
			}

			foreach (dynamic _c in Lang13.Enumerate( floors )) {
				turf2 = _c;
				

				if ( !( ( this.flags & 2 ) != 0 ) ) {
					floor_type = GlobalFuncs.pickweight( this.floortypes );
				}
				((Tile)turf2).ChangeTurf( floor_type );
				room.turfs.Add( turf2 );
				this.complex_area.contents.Add( turf2 );
				Ti2 = room.GetTurfInfo( turf2 );
				Ti2.turf_type = false;
			}
			room.UpdateTurfs();
			this.postProcessRoom( room );
			this.rooms.Add( room );
			GlobalFuncs.message_admins( "Room spawned at " + GlobalFuncs.formatJumpTo( start_loc ) );
			return true;
		}

		// Function from file: surprise.dm
		public virtual void postProcessComplex(  ) {
			int? i = null;
			dynamic T = null;
			dynamic thing = null;
			int? i2 = null;
			dynamic T2 = null;
			dynamic thing2 = null;

			i = null;
			i = 0;

			while (( i ??0) <= Rand13.Int( 1, this.max_richness )) {
				
				if ( !( this.candidates.len != 0 ) ) {
					return;
				}
				T = Rand13.PickFromTable( this.candidates );
				thing = GlobalFuncs.pickweight( this.spawntypes );

				if ( thing == null ) {
					
				} else {
					Lang13.Call( thing, T );
					this.candidates.Remove( T );
					GlobalFuncs.message_admins( "Goodie " + thing + " spawned at " + GlobalFuncs.formatJumpTo( T ) );
				}
				i++;
			}
			i2 = null;
			i2 = 0;

			while (( i2 ??0) <= Rand13.Int( 5, 10 )) {
				
				if ( !( this.candidates.len != 0 ) ) {
					return;
				}
				T2 = Rand13.PickFromTable( this.candidates );
				thing2 = GlobalFuncs.pickweight( this.fluffitems );

				if ( thing2 == null ) {
					
				} else {
					Lang13.Call( thing2, T2 );
				}
				i2++;
			}
			return;
		}

		// Function from file: surprise.dm
		public void postProcessRoom( SurpriseRoom room = null ) {
			dynamic floor = null;
			dynamic T = null;

			
			foreach (dynamic _b in Lang13.Enumerate( room.turfs )) {
				floor = _b;
				

				if ( floor.density ) {
					continue;
				}

				foreach (dynamic _a in Lang13.Enumerate( ((Tile)floor).AdjacentTurfs() )) {
					T = _a;
					
					Interface13.Stat( null, room.turfs.Contains( T ) );

					if ( false ) {
						
						if ( T.density ) {
							continue;
						}
						this.candidates.Or( T );
						break;
					}
				}
			}
			return;
		}

		// Function from file: surprise.dm
		public bool spawn_complex( dynamic start_loc = null ) {
			dynamic pos = null;
			int nrooms = 0;
			int maxtries = 0;
			int? l_size_x = null;
			int? l_size_y = null;
			int? sx = null;
			int? sy = null;
			int o_x = 0;
			int o_y = 0;
			Tile npos = null;

			this.name = "" + Lang13.Initial( this, "name" ) + " #" + Rand13.Int( 100, 999 );
			this.complex_area = new Zone_Asteroid_Artifactroom();
			this.complex_area.name = this.name;
			pos = start_loc;
			nrooms = this.complex_max_size;
			maxtries = 50;
			l_size_x = 0;
			l_size_y = 0;

			while (nrooms != 0 && maxtries != 0) {
				sx = Rand13.Int( 3, this.room_size_max );
				sy = Rand13.Int( 3, this.room_size_max );
				o_x = ( Lang13.Bool( l_size_x ) ? Rand13.Int( 0, l_size_x ??0 ) : 0 );
				o_y = ( Lang13.Bool( l_size_y ) ? Rand13.Int( 0, l_size_y ??0 ) : 0 );
				npos = null;

				dynamic _a = Rand13.PickFromTable( GlobalVars.cardinal ); // Was a switch-case, sorry for the mess.
				if ( _a==1 ) {
					npos = Map13.GetTile( Convert.ToInt32( pos.x + o_x ), Convert.ToInt32( pos.y + sy - 1 ), Convert.ToInt32( pos.z ) );
				} else if ( _a==2 ) {
					npos = Map13.GetTile( Convert.ToInt32( pos.x + o_x ), Convert.ToInt32( pos.y - sy + 1 ), Convert.ToInt32( pos.z ) );
				} else if ( _a==8 ) {
					npos = Map13.GetTile( Convert.ToInt32( pos.x - sx - 1 ), Convert.ToInt32( pos.y + o_y ), Convert.ToInt32( pos.z ) );
				} else if ( _a==4 ) {
					npos = Map13.GetTile( Convert.ToInt32( pos.x + sx + 1 ), Convert.ToInt32( pos.y + o_y ), Convert.ToInt32( pos.z ) );
				}

				if ( this.spawn_room( npos, sx, sy, true ) ) {
					pos = npos;
					l_size_x = sx;
					l_size_y = sy;
				} else if ( this.complex_max_size == nrooms ) {
					GlobalFuncs.qdel( this.complex_area );
					this.complex_area = null;
					return false;
				} else {
					maxtries--;
					continue;
				}
				nrooms--;
			}
			this.postProcessComplex();
			GlobalFuncs.message_admins( "Complex spawned at " + GlobalFuncs.formatJumpTo( start_loc ) );
			return true;
		}

	}

}