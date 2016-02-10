// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Space : Tile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 1;
			this.explosion_resistance = 10;
			this.temperature = 2.73;
			this.thermal_conductivity = 0.4;
			this.heat_capacity = 700000;
			this.intact = false;
			this.dynamic_lighting = false;
			this.can_border_transition = true;
			this.icon = "icons/turf/space.dmi";
			this.icon_state = "0";
		}

		// Function from file: space.dm
		public Tile_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			Ent_Static A = null;

			
			if ( this.loc != null ) {
				A = this.loc;
				((dynamic)A).area_turfs += this;
			}
			this.icon_state = "" + ( this.x + this.y ^ ~( this.x * this.y ) + this.z ) % 25;
			return;
		}

		// Function from file: splash_simulation.dm
		public override bool can_leave_liquid( dynamic from_direction = null ) {
			return true;
		}

		// Function from file: splash_simulation.dm
		public override bool can_accept_liquid( int from_direction = 0 ) {
			return true;
		}

		// Function from file: space.dm
		public override void lighting_build_overlays(  ) {
			return;
		}

		// Function from file: space.dm
		public override dynamic ChangeTurf( dynamic N = null, bool? tell_universe = null, bool? force_lighting_update = null, bool? allow = null ) {
			tell_universe = tell_universe ?? true;
			force_lighting_update = force_lighting_update ?? false;
			allow = allow ?? true;

			return base.ChangeTurf( (object)(N), tell_universe, true, allow );
		}

		// Function from file: space.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			return 0;
		}

		// Function from file: space.dm
		public void Sandbox_Spacemove( Ent_Dynamic A = null ) {
			int cur_x = 0;
			int cur_y = 0;
			int next_x = 0;
			int next_y = 0;
			dynamic target_z = null;
			ByTable y_arr = null;
			dynamic cur_pos = null;
			dynamic cur_pos2 = null;
			dynamic cur_pos3 = null;
			dynamic cur_pos4 = null;

			
			if ( this.x <= 1 ) {
				
				if ( A is Obj_Effect_Meteor || A is Obj_Effect_SpaceDust ) {
					GlobalFuncs.qdel( A );
					A = null;
					return;
				}
				cur_pos = this.get_global_map_pos();

				if ( !Lang13.Bool( cur_pos ) ) {
					return;
				}
				cur_x = Convert.ToInt32( cur_pos["x"] );
				cur_y = Convert.ToInt32( cur_pos["y"] );
				next_x = --cur_x != 0 || GlobalVars.global_map.len != 0 ?1:0;
				y_arr = GlobalVars.global_map[next_x];
				target_z = y_arr[cur_y];

				if ( Lang13.Bool( target_z ) ) {
					A.z = Convert.ToInt32( target_z );
					A.x = Game13.map_size_x - 2;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						
						if ( A != null && A.loc != null ) {
							A.loc.Entered( A );
						}
						return;
					}));
				}
			} else if ( this.x >= Game13.map_size_x ) {
				
				if ( A is Obj_Effect_Meteor ) {
					GlobalFuncs.qdel( A );
					A = null;
					return;
				}
				cur_pos2 = this.get_global_map_pos();

				if ( !Lang13.Bool( cur_pos2 ) ) {
					return;
				}
				cur_x = Convert.ToInt32( cur_pos2["x"] );
				cur_y = Convert.ToInt32( cur_pos2["y"] );
				next_x = ( ++cur_x > GlobalVars.global_map.len ? 1 : cur_x );
				y_arr = GlobalVars.global_map[next_x];
				target_z = y_arr[cur_y];

				if ( Lang13.Bool( target_z ) ) {
					A.z = Convert.ToInt32( target_z );
					A.x = 3;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						
						if ( A != null && A.loc != null ) {
							A.loc.Entered( A );
						}
						return;
					}));
				}
			} else if ( this.y <= 1 ) {
				
				if ( A is Obj_Effect_Meteor ) {
					GlobalFuncs.qdel( A );
					A = null;
					return;
				}
				cur_pos3 = this.get_global_map_pos();

				if ( !Lang13.Bool( cur_pos3 ) ) {
					return;
				}
				cur_x = Convert.ToInt32( cur_pos3["x"] );
				cur_y = Convert.ToInt32( cur_pos3["y"] );
				y_arr = GlobalVars.global_map[cur_x];
				next_y = --cur_y != 0 || y_arr.len != 0 ?1:0;
				target_z = y_arr[next_y];

				if ( Lang13.Bool( target_z ) ) {
					A.z = Convert.ToInt32( target_z );
					A.y = Game13.map_size_y - 2;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						
						if ( A != null && A.loc != null ) {
							A.loc.Entered( A );
						}
						return;
					}));
				}
			} else if ( this.y >= Game13.map_size_y ) {
				
				if ( A is Obj_Effect_Meteor || A is Obj_Effect_SpaceDust ) {
					GlobalFuncs.qdel( A );
					A = null;
					return;
				}
				cur_pos4 = this.get_global_map_pos();

				if ( !Lang13.Bool( cur_pos4 ) ) {
					return;
				}
				cur_x = Convert.ToInt32( cur_pos4["x"] );
				cur_y = Convert.ToInt32( cur_pos4["y"] );
				y_arr = GlobalVars.global_map[cur_x];
				next_y = ( ++cur_y > y_arr.len ? 1 : cur_y );
				target_z = y_arr[next_y];

				if ( Lang13.Bool( target_z ) ) {
					A.z = Convert.ToInt32( target_z );
					A.y = 3;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						
						if ( A != null && A.loc != null ) {
							A.loc.Entered( A );
						}
						return;
					}));
				}
			}
			return;
		}

		// Function from file: space.dm
		public override dynamic Entered( Ent_Dynamic Obj = null, Ent_Static oldloc = null ) {
			base.Entered( Obj, oldloc );
			this.inertial_drift( Obj );
			return null;
		}

		// Function from file: space.dm
		public override int canBuildPlating( Obj_Item_Stack_Tile_Wood material = null ) {
			
			if ( this.x >= Game13.map_size_x - 7 || this.x <= 7 ) {
				return 0;
			} else if ( this.y >= ( Game13.map_size_y - 7 != 0 || this.y <= 7 ?1:0) ) {
				return 0;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice), this.contents ) ) && !( material is Obj_Item_Stack_Tile_Wood ) ) {
				return 1;
			}
			return 0;
		}

		// Function from file: space.dm
		public override bool canBuildLattice( Obj_Item_Stack material = null ) {
			
			if ( this.x >= Game13.map_size_x - 7 || this.x <= 7 ) {
				return false;
			} else if ( this.y >= ( Game13.map_size_y - 7 != 0 || this.y <= 7 ?1:0) ) {
				return false;
			} else if ( !Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice), this.contents ) ) && !( material is Obj_Item_Stack_Sheet_Wood ) ) {
				return true;
			}
			return false;
		}

		// Function from file: space.dm
		public override dynamic canBuildCatwalk(  ) {
			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Catwalk), this.contents ) ) ) {
				return 0;
			}
			return Lang13.FindIn( typeof(Obj_Structure_Lattice), this.contents );
		}

		// Function from file: space.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: turf.dm
		public override void levelupdate(  ) {
			Obj O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
				O = _a;
				

				if ( O.level == 1 ) {
					O.hide( false );
				}
			}
			return;
		}

	}

}