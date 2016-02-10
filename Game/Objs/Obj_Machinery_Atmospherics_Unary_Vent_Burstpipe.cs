// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Unary_Vent_Burstpipe : Obj_Machinery_Atmospherics_Unary_Vent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.volume = 1000;
			this.icon = "icons/obj/pipes.dmi";
			this.icon_state = "burst";
		}

		// Function from file: burstpipe.dm
		public Obj_Machinery_Atmospherics_Unary_Vent_Burstpipe ( dynamic _loc = null, double? setdir = null ) : base( (object)(_loc) ) {
			setdir = setdir ?? GlobalVars.SOUTH;

			this.dir = ((int)( setdir ??0 ));
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: burstpipe.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic T = null;

			
			if ( !( a is Obj_Item_Weapon_Wrench ) ) {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			T = GlobalFuncs.get_turf( this );
			GlobalFuncs.playsound( T, "sound/items/Ratchet.ogg", 50, 1 );
			GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You begin to remove " ).the( this ).item().str( "...</span>" ).ToString() );

			if ( GlobalFuncs.do_after( b, this, 40 ) ) {
				((Ent_Static)b).visible_message( new Txt().item( b ).str( " removes " ).the( this ).item().str( "." ).ToString(), new Txt( "<span class='notice'>You have removed " ).the( this ).item().str( ".</span>" ).ToString(), "You hear a ratchet." );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: burstpipe.dm
		public void do_connect(  ) {
			Ent_Static T = null;

			this.initialize_directions = this.dir;
			T = this.loc;
			this.level = ( Lang13.Bool( ((dynamic)T).intact ) ? 2 : 1 );
			this.initialize();
			this.build_network();

			if ( this.node != null ) {
				this.node.initialize();
				this.node.build_network();
			}
			return;
		}

		// Function from file: burstpipe.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

		// Function from file: burstpipe.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.alpha = ( this.invisibility != 0 ? 128 : 255 );

			if ( !( this.node != null ) || Lang13.Bool( ((dynamic)this.type).IsInstanceOfType( this.node ) ) ) {
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: burstpipe.dm
		public override void hide( bool? h = null ) {
			
			if ( this.level == 1 && this.loc is Tile_Simulated ) {
				this.invisibility = ( h == true ? 101 : 0 );
			}
			this.update_icon();
			return;
		}

	}

}