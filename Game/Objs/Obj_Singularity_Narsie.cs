// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Singularity_Narsie : Obj_Singularity {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -89;
			this.pixel_y = -85;
			this.current_size = 9;
			this.contained = false;
			this.dissipate = false;
			this.grav_pull = 5;
			this.consume_range = 6;
			this.icon = "icons/obj/magic_terror.dmi";
		}

		public Obj_Singularity_Narsie ( dynamic loc = null, int? starting_energy = null, bool? temp = null ) : base( (object)(loc), starting_energy, temp ) {
			
		}

		// Function from file: narsie.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

		// Function from file: narsie.dm
		public override bool consume( dynamic A = null ) {
			((Ent_Static)A).narsie_act();
			return false;
		}

		// Function from file: narsie.dm
		public override void mezzer(  ) {
			Mob_Living_Carbon M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewersExcludeThis( this, 8 ), typeof(Mob_Living_Carbon) )) {
				M = _a;
				

				if ( M.stat == 0 ) {
					
					if ( !GlobalFuncs.iscultist( M ) ) {
						M.WriteMsg( "<span class='cultsmall'>You feel conscious thought crumble away in an instant as you gaze upon " + this.name + "...</span>" );
						M.apply_effect( 3, "stun" );
					}
				}
			}
			return;
		}

		// Function from file: narsie.dm
		public void narsie_spawn_animation(  ) {
			this.icon = "icons/obj/narsie_spawn_anim.dmi";
			this.dir = ((int)( GlobalVars.SOUTH ));
			this.move_self = false;
			Icon13.Flick( "narsie_spawn_anim", this );
			Task13.Sleep( 11 );
			this.move_self = true;
			this.icon = Lang13.Initial( this, "icon" );
			return;
		}

		// Function from file: narsie.dm
		public void acquire( dynamic food = null ) {
			
			if ( food == this.target ) {
				return;
			}
			this.target.WriteMsg( "<span class='cultsmall'>NAR-SIE HAS LOST INTEREST IN YOU.</span>" );
			this.target = food;

			if ( this.target is Mob_Living ) {
				this.target.WriteMsg( "<span class ='cult'>NAR-SIE HUNGERS FOR YOUR SOUL.</span>" );
			} else {
				this.target.WriteMsg( "<span class ='cult'>NAR-SIE HAS CHOSEN YOU TO LEAD HER TO HER NEXT MEAL.</span>" );
			}
			return;
		}

		// Function from file: narsie.dm
		public void pickcultist(  ) {
			ByTable cultists = null;
			ByTable noncultists = null;
			Mob_Living_Carbon food = null;
			dynamic pos = null;
			Mob_Dead_Observer ghost = null;
			dynamic pos2 = null;

			cultists = new ByTable();
			noncultists = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_Carbon) )) {
				food = _a;
				
				pos = GlobalFuncs.get_turf( food );

				if ( Convert.ToInt32( pos.z ) != this.z ) {
					continue;
				}

				if ( GlobalFuncs.iscultist( food ) ) {
					cultists.Add( food );
				} else {
					noncultists.Add( food );
				}

				if ( cultists.len != 0 ) {
					this.acquire( Rand13.PickFromTable( cultists ) );
					return;
				}

				if ( noncultists.len != 0 ) {
					this.acquire( Rand13.PickFromTable( noncultists ) );
					return;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Dead_Observer) )) {
				ghost = _b;
				

				if ( !( ghost.client != null ) ) {
					continue;
				}
				pos2 = GlobalFuncs.get_turf( ghost );

				if ( Convert.ToInt32( pos2.z ) != this.z ) {
					continue;
				}
				cultists.Add( ghost );
			}

			if ( cultists.len != 0 ) {
				this.acquire( Rand13.PickFromTable( cultists ) );
				return;
			}
			return;
		}

		// Function from file: narsie.dm
		public void godsmack( dynamic A = null ) {
			dynamic O = null;
			dynamic T = null;

			
			if ( A is Obj ) {
				O = A;
				((Ent_Static)O).ex_act( 1 );

				if ( Lang13.Bool( O ) ) {
					GlobalFuncs.qdel( O );
				}
			} else if ( A is Tile ) {
				T = A;
				((Tile)T).ChangeTurf( typeof(Tile_Simulated_Floor_Plasteel_Cult) );
			}
			return;
		}

		// Function from file: narsie.dm
		public override bool Bumped( dynamic AM = null ) {
			this.godsmack( AM );
			return false;
		}

		// Function from file: narsie.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null ) {
			this.godsmack( Obstacle );
			return null;
		}

		// Function from file: narsie.dm
		public override int? process( dynamic seconds = null ) {
			this.eat();

			if ( !Lang13.Bool( this.target ) || Rand13.PercentChance( 5 ) ) {
				this.pickcultist();
			}
			this.move();

			if ( Rand13.PercentChance( 25 ) ) {
				this.mezzer();
			}
			return null;
		}

	}

}