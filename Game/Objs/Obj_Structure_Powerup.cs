// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Powerup : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/bomberman.dmi";
			this.icon_state = "powerup";
		}

		// Function from file: bomberman.dm
		public Obj_Structure_Powerup ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.bombermangear.Add( this );
			return;
		}

		// Function from file: bomberman.dm
		public override bool singuloCanEat(  ) {
			return false;
		}

		// Function from file: bomberman.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: bomberman.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			this.pulverized();
			return false;
		}

		// Function from file: bomberman.dm
		public void pulverized(  ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: bomberman.dm
		public virtual void apply_power( dynamic dispenser = null ) {
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/bomberman/powerup.ogg", 50, 1 );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: bomberman.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			dynamic dispenser = null;

			
			if ( AM is Mob_Living || AM is Obj_Mecha || AM is Obj_Structure_Bed_Chair || AM is Obj_Structure_Bomberflame ) {
				this.density = false;
				Map13.Step( (Ent_Dynamic)(AM), Map13.GetDistance( AM, this ) );
				Task13.Schedule( 1, (Task13.Closure)(() => {
					this.density = true;
					return;
				}));
			}
			dispenser = Lang13.FindIn( typeof(Obj_Item_Weapon_Bomberman), AM );

			if ( Lang13.Bool( dispenser ) ) {
				this.apply_power( dispenser );
			}

			if ( AM is Obj_Structure_Bomberflame ) {
				this.icon_state = "powerup_break";
				Task13.Schedule( 5, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			}
			base.Bumped( AM, (object)(yes) );
			return false;
		}

		// Function from file: bomberman.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Bomberman ) {
				this.apply_power( a );
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: bomberman.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalVars.bombermangear.Remove( this );
			return null;
		}

	}

}