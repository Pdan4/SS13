// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_FakeFlood : Obj_Effect_Hallucination {

		public ByTable flood_images = new ByTable();
		public ByTable flood_turfs = new ByTable();
		public string image_icon = "icons/effects/tile_effects.dmi";
		public string image_state = "plasma";
		public int? radius = 0;
		public int next_expand = 0;

		// Function from file: Hallucination.dm
		public Obj_Effect_Hallucination_FakeFlood ( dynamic loc = null, Mob_Living_Carbon T = null ) : base( (object)(loc) ) {
			Obj_Machinery_Atmospherics_Components_Unary_VentPump U = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.target = T;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this.target, 7 ), typeof(Obj_Machinery_Atmospherics_Components_Unary_VentPump) )) {
				U = _a;
				

				if ( !( U.welded == true ) ) {
					this.loc = U.loc;
					break;
				}
			}
			this.image_state = Rand13.Pick(new object [] { "plasma", "sleeping_agent" });
			this.flood_images.Add( new Image( this.image_icon, this, this.image_state, GlobalVars.MOB_LAYER ) );
			this.flood_turfs.Add( GlobalFuncs.get_turf( this.loc ) );

			if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
				((dynamic)this.target).client.images.Or( this.flood_images );
			}
			this.next_expand = Game13.time + 30;
			GlobalVars.SSobj.processing.Or( this );
			return;
		}

		// Function from file: Hallucination.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSobj.processing.Remove( this );
			GlobalFuncs.qdel( this.flood_turfs );
			this.flood_turfs = new ByTable();

			if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
				((dynamic)this.target).client.images.Remove( this.flood_images );
			}
			this.target = null;
			GlobalFuncs.qdel( this.flood_images );
			this.flood_images = new ByTable();
			return base.Destroy();
		}

		// Function from file: Hallucination.dm
		public void Expand(  ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.circlerangeturfs( this.loc, this.radius ) )) {
				T = _a;
				

				if ( this.flood_turfs.Contains( T ) || T.blocks_air ) {
					continue;
				}
				this.flood_images.Add( new Image( this.image_icon, T, this.image_state, GlobalVars.MOB_LAYER ) );
				this.flood_turfs.Add( T );
			}

			if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
				((dynamic)this.target).client.images.Or( this.flood_images );
			}
			return;
		}

		// Function from file: Hallucination.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.next_expand <= Game13.time ) {
				this.radius++;

				if ( ( this.radius ??0) > 7 ) {
					GlobalFuncs.qdel( this );
					return null;
				}
				this.Expand();
				this.next_expand = Game13.time + 30;
			}
			return null;
		}

	}

}