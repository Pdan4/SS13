// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_BigDelivery : Obj_Structure {

		public dynamic wrapped = null;
		public bool giftwrapped = false;
		public double? sortTag = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mouse_drag_pointer = 1;
			this.icon = "icons/obj/storage.dmi";
			this.icon_state = "deliverycloset";
		}

		public Obj_Structure_BigDelivery ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: sortingmachinery.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic O = null;
			string tag = null;
			string str = null;
			dynamic WP = null;

			
			if ( A is Obj_Item_Device_DestTagger ) {
				O = A;

				if ( this.sortTag != O.currTag ) {
					tag = String13.ToUpper( GlobalVars.TAGGERLOCATIONS[O.currTag] );
					user.WriteMsg( "<span class='notice'>*" + tag + "*</span>" );
					this.sortTag = O.currTag;
					GlobalFuncs.playsound( this.loc, "sound/machines/twobeep.ogg", 100, 1 );
				}
			} else if ( A is Obj_Item_Weapon_Pen ) {
				str = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( user, "Label text?", "Set label", "", null, InputType.Any ) ), 1, 26 );

				if ( !Lang13.Bool( str ) || !( Lang13.Length( str ) != 0 ) ) {
					user.WriteMsg( "<span class='warning'>Invalid text!</span>" );
					return null;
				}
				((Ent_Static)user).visible_message( "" + user + " labels " + this + " as " + str + "." );
				this.name = "" + this.name + " (" + str + ")";
			} else if ( A is Obj_Item_Stack_WrappingPaper && !this.giftwrapped ) {
				WP = A;

				if ( Lang13.Bool( WP.use( 3 ) ) ) {
					((Ent_Static)user).visible_message( "" + user + " wraps the package in festive paper!" );
					this.giftwrapped = true;

					if ( this.wrapped is Obj_Structure_Closet_Crate ) {
						this.icon_state = "giftcrate";
					} else {
						this.icon_state = "giftcloset";
					}

					if ( Convert.ToDouble( WP.amount ) <= 0 && !( WP.loc != null ) ) {
						new Obj_Item_Weapon_CTube( GlobalFuncs.get_turf( user ) );
					}
				} else {
					user.WriteMsg( "<span class='warning'>You need more paper!</span>" );
				}
			}
			return null;
		}

		// Function from file: sortingmachinery.dm
		public override dynamic Destroy(  ) {
			dynamic O = null;
			dynamic T = null;
			Ent_Dynamic AM = null;

			
			if ( Lang13.Bool( this.wrapped ) ) {
				this.wrapped.loc = GlobalFuncs.get_turf( this.loc );

				if ( this.wrapped is Obj_Structure_Closet ) {
					O = this.wrapped;
					O.welded = 0;
				}
			}
			T = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				AM.loc = T;
			}
			return base.Destroy();
		}

		// Function from file: sortingmachinery.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			GlobalFuncs.playsound( this.loc, "sound/items/poster_ripped.ogg", 50, 1 );
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}