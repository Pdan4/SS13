// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Planner_Spawnpoint : Obj_Structure_Planner {

		public BombermanSpawn spawnpoint = null;

		// Function from file: bomberman.dm
		public Obj_Structure_Planner_Spawnpoint ( dynamic loc = null, BombermanArena a = null, BombermanSpawn bs = null ) : base( (object)(loc), a ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.arena = a;
			this.spawnpoint = bs;
			return;
		}

		// Function from file: bomberman.dm
		public void update_overlay( int currentcount = 0 ) {
			int first = 0;
			int second = 0;
			Image I1 = null;
			Image I2 = null;

			this.overlays.len = 0;

			if ( this.arena.counting ) {
				first = Num13.Floor( currentcount / 10 );
				second = currentcount % 10;
				I1 = new Image( "icons/obj/centcomm_stuff.dmi", this, "" + first, 30 );
				I2 = new Image( "icons/obj/centcomm_stuff.dmi", this, "" + second, 30 );
				I1.pixel_x += 10;
				I2.pixel_x += 17;
				I1.pixel_y -= 11;
				I2.pixel_y -= 11;
				this.overlays.Add( I1 );
				this.overlays.Add( I2 );
			}
			return;
		}

		// Function from file: bomberman.dm
		public void ghost_unsubscribe( Mob user = null ) {
			this.spawnpoint.player_client = null;
			GlobalVars.ready_gladiators.Remove( user.client );
			this.spawnpoint.availability = true;
			this.icon_state = "planner";
			return;
		}

		// Function from file: bomberman.dm
		public void ghost_subscribe( Mob_Dead_Observer user = null ) {
			this.spawnpoint.player_client = user.client;
			GlobalVars.ready_gladiators.Add( user.client );
			this.spawnpoint.availability = false;
			this.icon_state = "planner_ready";
			return;
		}

		// Function from file: bomberman.dm
		public override dynamic attack_ghost( Mob_Dead_Observer user = null ) {
			
			if ( this.arena.status != 1 ) {
				return null;
			}

			if ( this.spawnpoint.availability ) {
				Interface13.Stat( null, GlobalVars.never_gladiators.Contains( user.client ) );

				if ( !false && !false ) {
					this.ghost_subscribe( user );
				}
			} else if ( this.spawnpoint.player_client == user.client ) {
				this.ghost_unsubscribe( user );
			}
			this.arena.update_ready();
			return null;
		}

		// Function from file: bomberman.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.spawnpoint = null;
			return null;
		}

	}

}