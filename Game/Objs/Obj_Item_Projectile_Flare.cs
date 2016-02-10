// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Flare : Obj_Item_Projectile {

		public bool embed = true;
		public dynamic shotloc = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 15;
			this.damage_type = "fire";
			this.light_color = "#FA644B";
			this.light_range = 5;
			this.icon_state = "flareround";
		}

		// Function from file: flare.dm
		public Obj_Item_Projectile_Flare ( dynamic loc = null ) : base( (object)(loc) ) {
			this.shotloc = GlobalFuncs.get_turf( this.shot_from );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: flare.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			Tile newloc = null;
			Obj_Item_Device_Flashlight_Flare newflare = null;

			base.Bump( Obstacle );

			if ( this != null ) {
				newloc = Map13.GetStep( this.loc, Map13.GetDistance( this.loc, this.shotloc ) );
				newflare = new Obj_Item_Device_Flashlight_Flare( newloc );
				newflare.Light();
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}