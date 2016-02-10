// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_BarricadeKit : Obj_Item_Weapon {

		public int kit_uses = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 3;
			this.throwforce = 3;
			this.throw_speed = 1;
			this.throw_range = 3;
			this.icon = "icons/obj/barricade.dmi";
			this.icon_state = "barricade_kit";
		}

		public Obj_Item_Weapon_BarricadeKit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: barricade_kit.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			return null;
		}

		// Function from file: barricade_kit.dm
		public override bool preattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, dynamic click_parameters = null ) {
			dynamic T = null;
			Obj_Structure S = null;
			dynamic T2 = null;
			Obj_Structure S2 = null;

			
			if ( target is Obj_Machinery_Door_Airlock || target is Obj_Structure_Window_Full ) {
				
				if ( Map13.GetDistance( user, target ) > 1 ) {
					return false;
				}
				T = GlobalFuncs.get_turf( target );

				foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Structure) )) {
					S = _a;
					

					if ( S is Obj_Structure_Window_Barricade_Full_Block ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>There already is a barricade here</span>" );
						return false;
					}
				}
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " starts barricading " ).the( target ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start barricading " ).the( target ).item().str( ".</span>" ).ToString() );

				if ( GlobalFuncs.do_after( user, T, 30 ) ) {
					new Obj_Structure_Window_Barricade_Full_Block( GlobalFuncs.get_turf( T ) );
					((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " barricades " ).the( target ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You barricade " ).the( target ).item().str( ".</span>" ).ToString() );
					this.kit_uses--;

					if ( this.kit_uses < 1 ) {
						GlobalFuncs.qdel( this );
					}
				}
				return false;
			}

			if ( target is Obj_Structure_Window && !( target is Obj_Structure_Window_Full ) ) {
				
				if ( Map13.GetDistance( user, target ) > 1 ) {
					return false;
				}
				T2 = GlobalFuncs.get_turf( target );

				foreach (dynamic _b in Lang13.Enumerate( T2, typeof(Obj_Structure) )) {
					S2 = _b;
					

					if ( S2 is Obj_Structure_Window_Barricade_Full_Block ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>There already is a barricade here</span>" );
						return false;
					}

					if ( S2 is Obj_Structure_Grille ) {
						((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " starts barricading " ).the( target ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start barricading " ).the( target ).item().str( ".</span>" ).ToString() );

						if ( GlobalFuncs.do_after( user, T2, 30 ) ) {
							new Obj_Structure_Window_Barricade_Full_Block( GlobalFuncs.get_turf( T2 ) );
							((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " barricades " ).the( target ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You barricade " ).the( target ).item().str( ".</span>" ).ToString() );
							this.kit_uses--;

							if ( this.kit_uses < 1 ) {
								GlobalFuncs.qdel( this );
							}
						}
						break;
					}
				}
				return false;
			}
			return false;
		}

		// Function from file: barricade_kit.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Structure_Window_Barricade BC = null;
			Obj_Structure_Window_Barricade BC2 = null;

			
			if ( !Lang13.Bool( user ) || !( this != null ) ) {
				return 0;
			}

			if ( !( user.loc is Tile ) ) {
				return 0;
			}

			if ( user.loc is Tile_Space ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>You can't build barricades out in space.</span>" );
				return null;
			}

			if ( !Lang13.Bool( ((Mob)user).IsAdvancedToolUser() ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return 0;
			}

			switch ((string)( Interface13.Alert( new Txt( "What do you want (" ).item( this.kit_uses ).str( " use" ).s().str( " left)" ).ToString(), "Barricade Kit", "Directional", "Full Tile", "Cancel" ) )) {
				case "Directional":
					
					if ( !( this != null ) ) {
						return 1;
					}

					if ( this.loc != user ) {
						return 1;
					}

					foreach (dynamic _a in Lang13.Enumerate( user.loc, typeof(Obj_Structure_Window_Barricade) )) {
						BC = _a;
						

						if ( !BC.is_fulltile() && BC.dir == Convert.ToInt32( user.dir ) ) {
							GlobalFuncs.to_chat( user, "<span class='warning'>There already is a barricade facing that way</span>" );
							return null;
						}
					}
					((Ent_Static)user).visible_message( "<span class='warning'>" + user + " starts building a barricade.</span>", "<span class='notice'>You start building a barricade.</span>" );

					if ( GlobalFuncs.do_after( user, this, 30 ) ) {
						GlobalFuncs.to_chat( user, "<span class='notice'>You finish the barricade.</span>" );
						BC2 = new Obj_Structure_Window_Barricade( user.loc );
						BC2.dir = Convert.ToInt32( user.dir );
						this.kit_uses--;

						if ( this.kit_uses < 1 ) {
							GlobalFuncs.qdel( this );
						}
					}
					break;
				case "Full Tile":
					
					if ( !( this != null ) ) {
						return 1;
					}

					if ( this.loc != user ) {
						return 1;
					}

					if ( this.kit_uses < 3 ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>This barricade doesn't have enough planks and nails left for that.</span>" );
						return 1;
					}

					if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Window_Barricade_Full), user.loc ) ) ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>There is a barricade in the way.</span>" );
						return 1;
					}
					((Ent_Static)user).visible_message( "<span class='warning'>" + user + " starts building a full barricade.</span>", "<span class='notice'>You start building a full barricade.</span>" );

					if ( GlobalFuncs.do_after( user, this, 50 ) ) {
						GlobalFuncs.to_chat( user, "<span class='notice'>You finish the full barricade.</span>" );
						new Obj_Structure_Window_Barricade_Full( user.loc );
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return null;
		}

		// Function from file: barricade_kit.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, "It has " + this.kit_uses + " uses left for regular barricades. It can " + ( this.kit_uses < 3 ? "no longer be used" : "also be used" ) + " for full barricades." );
			return null;
		}

	}

}