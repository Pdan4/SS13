// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Acid : Obj_Effect {

		public dynamic target = null;
		public int ticks = 0;
		public int target_strength = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "acid";
		}

		// Function from file: aliens.dm
		public Obj_Effect_Acid ( dynamic loc = null, dynamic targ = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.target = targ;
			this.pixel_x = Convert.ToInt32( this.target.pixel_x );
			this.pixel_y = Convert.ToInt32( this.target.pixel_y );

			if ( this.target is Tile ) {
				this.target_strength = 640;
			} else {
				this.target_strength = 320;
			}
			this.tick();
			return;
		}

		// Function from file: aliens.dm
		public void tick(  ) {
			dynamic T = null;
			dynamic M = null;
			dynamic F = null;
			dynamic W = null;

			
			if ( !Lang13.Bool( this.target ) ) {
				GlobalFuncs.qdel( this );
			}
			this.ticks++;

			if ( this.ticks >= this.target_strength ) {
				((Ent_Static)this.target).visible_message( "<span class='warning'>" + this.target + " collapses under its own weight into a puddle of goop and undigested debris!</span>" );

				if ( this.target is Obj_Structure_Closet ) {
					T = this.target;
					((Obj_Structure_Closet)T).dump_contents();
					GlobalFuncs.qdel( this.target );
				}

				if ( this.target is Tile_Simulated_Mineral ) {
					M = this.target;
					((Tile)M).ChangeTurf( M.baseturf );
				}

				if ( this.target is Tile_Simulated_Floor ) {
					F = this.target;
					((Tile)F).ChangeTurf( F.baseturf );
				}

				if ( this.target is Tile_Simulated_Wall ) {
					W = this.target;
					((Tile_Simulated_Wall)W).dismantle_wall( true );
				} else {
					GlobalFuncs.qdel( this.target );
				}
				GlobalFuncs.qdel( this );
				return;
			}
			this.x = Convert.ToInt32( this.target.x );
			this.y = Convert.ToInt32( this.target.y );
			this.z = Convert.ToInt32( this.target.z );

			switch ((int)( this.target_strength - this.ticks )) {
				case 480:
					this.visible_message( "<span class='warning'>" + this.target + " is holding up against the acid!</span>" );
					break;
				case 320:
					this.visible_message( "<span class='warning'>" + this.target + " is being melted by the acid!</span>" );
					break;
				case 160:
					this.visible_message( "<span class='warning'>" + this.target + " is struggling to withstand the acid!</span>" );
					break;
				case 80:
					this.visible_message( "<span class='warning'>" + this.target + " begins to crumble under the acid!</span>" );
					break;
			}
			Task13.Schedule( 1, (Task13.Closure)(() => {
				
				if ( this != null ) {
					this.tick();
				}
				return;
			}));
			return;
		}

	}

}