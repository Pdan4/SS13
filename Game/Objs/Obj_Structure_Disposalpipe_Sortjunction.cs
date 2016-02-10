// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalpipe_Sortjunction : Obj_Structure_Disposalpipe {

		public int sortType = 0;
		public string sort_tag = null;
		public int posdir = 0;
		public int negdir = 0;
		public int sortdir = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pipe-j1s";
		}

		// Function from file: disposal.dm
		public Obj_Structure_Disposalpipe_Sortjunction ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.sortType != 0 && !Lang13.Bool( this.sort_tag ) ) {
				this.sort_tag = String13.ToUpper( GlobalVars.DEFAULT_TAGGER_LOCATIONS[this.sortType] );
			}
			this.updatedir();
			this.updatedesc();
			this.update();
			return;
		}

		// Function from file: disposal.dm
		public override Obj_Structure_Disposalpipe transfer( Obj_Structure_Disposalholder H = null ) {
			double? nextdir = null;
			Tile T = null;
			Obj_Structure_Disposalpipe P = null;
			dynamic H2 = null;

			nextdir = this.nextdir( H.dir, H.destinationTag );
			H.dir = ((int)( nextdir ??0 ));
			T = H.nextloc();
			P = H.findpipe( T );

			if ( P != null ) {
				H2 = Lang13.FindIn( typeof(Obj_Structure_Disposalholder), P );

				if ( Lang13.Bool( H2 ) && !Lang13.Bool( H2.active ) ) {
					H.merge( H2 );
				}
				H.forceMove( P );
			} else {
				H.forceMove( T );
				return null;
			}
			return P;
		}

		// Function from file: disposal.dm
		public override double? nextdir( int fromdir = 0, dynamic sortTag = null ) {
			
			if ( fromdir != this.sortdir ) {
				
				if ( this.sort_tag == sortTag ) {
					return this.sortdir;
				} else {
					return this.posdir;
				}
			} else {
				return this.posdir;
			}
			return null;
		}

		// Function from file: disposal.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			dynamic O = null;

			
			if ( a is Obj_Item_Device_DestTagger ) {
				O = a;

				if ( Lang13.Bool( O.currTag ) ) {
					this.sort_tag = String13.ToUpper( O.destinations[O.currTag] );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/twobeep.ogg", 100, 1 );
					GlobalFuncs.to_chat( b, "<span class='notice'>Changed filter to " + this.sort_tag + "</span>" );
					this.updatedesc();
				}
				return 1;
			}
			_default = base.attackby( (object)(a), (object)(b), (object)(c) );
			return _default;
		}

		// Function from file: disposal.dm
		public void updatedir(  ) {
			this.posdir = this.dir;
			this.negdir = Num13.Rotate( this.posdir, 180 );

			if ( this.icon_state == "pipe-j1s" ) {
				this.sortdir = Num13.Rotate( this.posdir, -90 );
			} else {
				this.icon_state = "pipe-j2s";
				this.sortdir = Num13.Rotate( this.posdir, 90 );
			}
			this.dpdir = this.sortdir | this.posdir | this.negdir;
			return;
		}

		// Function from file: disposal.dm
		public void updatedesc(  ) {
			this.desc = "An underfloor disposal pipe with a package sorting mechanism.";

			if ( Lang13.Bool( this.sort_tag ) ) {
				this.desc += "\nIt's tagged with " + this.sort_tag + ".";
			}
			return;
		}

	}

}