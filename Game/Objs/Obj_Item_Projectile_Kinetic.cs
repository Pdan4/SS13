// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Kinetic : Obj_Item_Projectile {

		public int range = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 15;
			this.flag = "energy";
			this.icon_state = "energy";
		}

		// Function from file: special.dm
		public Obj_Item_Projectile_Kinetic ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic proj_turf = null;
			GasMixture environment = null;
			dynamic pressure = null;

			proj_turf = GlobalFuncs.get_turf( this );

			if ( !( proj_turf is Tile ) ) {
				return;
			}
			environment = ((Ent_Static)proj_turf).return_air();
			pressure = environment.return_pressure();

			if ( Convert.ToDouble( pressure ) < 50 ) {
				this.name = "full strength kinetic force";
				this.damage = 30;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: special.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			dynamic target_turf = null;
			dynamic M = null;

			
			if ( !( this.loc != null ) ) {
				return null;
			}

			if ( Obstacle == this.firer ) {
				this.loc = Obstacle.loc;
				return null;
			}

			if ( this != null ) {
				
				if ( Obstacle != null ) {
					target_turf = GlobalFuncs.get_turf( Obstacle );

					if ( target_turf is Tile_Unsimulated_Mineral ) {
						M = target_turf;
						((Tile_Unsimulated_Mineral)M).GetDrilled();
					}

					if ( !( Obstacle is Tile ) ) {
						base.Bump( Obstacle );
					}
					GlobalFuncs.returnToPool( this );
					return 1;
				}
			} else {
				GlobalFuncs.returnToPool( this );
				return 0;
			}
			return null;
		}

		// Function from file: special.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			blocked = blocked ?? 0;

			dynamic target_turf = null;
			dynamic M = null;

			
			if ( !( this.loc != null ) ) {
				return false;
			}
			target_turf = GlobalFuncs.get_turf( atarget );

			if ( target_turf is Tile_Unsimulated_Mineral ) {
				M = target_turf;
				((Tile_Unsimulated_Mineral)M).GetDrilled();
			}
			new Obj_Item_Effect_KineticBlast( target_turf );
			base.on_hit( (object)(atarget), blocked );
			return false;
		}

	}

}