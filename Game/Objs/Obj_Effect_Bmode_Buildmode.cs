// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Bmode_Buildmode : Obj_Effect_Bmode {

		public dynamic varholder = "name";
		public dynamic valueholder = "derp";
		public Type objholder = typeof(Obj_Structure_Closet);
		public Ent_Static copycat = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.screen_loc = "NORTH,WEST+2";
			this.icon_state = "buildmode1";
		}

		public Obj_Effect_Bmode_Buildmode ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: buildmode.dm
		public override bool DblClick( dynamic _object = null, string location = null, string control = null, dynamic _params = null ) {
			return this.Click( _object, location, control );
		}

		// Function from file: buildmode.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			ByTable pa = null;
			ByTable locked = null;
			dynamic thetype = null;

			pa = String13.ParseUrlParams( _params );

			if ( pa.Find( "left" ) != 0 ) {
				
				dynamic _a = ((dynamic)this.master).cl.buildmode; // Was a switch-case, sorry for the mess.
				if ( _a==1 ) {
					((dynamic)this.master).cl.buildmode = 2;
					this.icon_state = "buildmode2";
				} else if ( _a==2 ) {
					((dynamic)this.master).cl.buildmode = 3;
					this.icon_state = "buildmode3";
				} else if ( _a==3 ) {
					((dynamic)this.master).cl.buildmode = 4;
					this.icon_state = "buildmode4";
				} else if ( _a==4 ) {
					((dynamic)this.master).cl.buildmode = 1;
					this.icon_state = "buildmode1";
				}
			} else if ( pa.Find( "right" ) != 0 ) {
				
				dynamic _c = ((dynamic)this.master).cl.buildmode; // Was a switch-case, sorry for the mess.
				if ( _c==1 ) {
					return true;
				} else if ( _c==2 ) {
					this.copycat = null;
					this.objholder = Lang13.FindClass( Interface13.Input( Task13.User, "Enter typepath:", "Typepath", "/obj/structure/closet", null, InputType.Any ) );

					if ( !( this.objholder is Type ) ) {
						this.objholder = typeof(Obj_Structure_Closet);
						Interface13.Alert( "That path is not allowed." );
					} else if ( Lang13.Bool( ((dynamic)this.objholder).IsSubclassOf( typeof(Mob) ) ) && !GlobalFuncs.check_rights( 32, false ) ) {
						this.objholder = typeof(Obj_Structure_Closet);
					}
				} else if ( _c==3 ) {
					locked = new ByTable(new object [] { "vars", "key", "ckey", "client", "firemut", "ishulk", "telekinesis", "xray", "virus", "viruses", "cuffed", "ka", "last_eaten", "urine" });
					((dynamic)this.master).buildmode.varholder = Interface13.Input( Task13.User, "Enter variable name:", "Name", "name", null, InputType.Any );
					Interface13.Stat( null, ((dynamic)( locked != null && !GlobalFuncs.check_rights( 32, false ) )).Contains( ((dynamic)this.master).buildmode.varholder ) );

					if ( false ) {
						return true;
					}
					thetype = Interface13.Input( Task13.User, "Select variable type:", "Type", null, new ByTable(new object [] { "text", "number", "mob-reference", "obj-reference", "turf-reference" }), InputType.Any );

					if ( !Lang13.Bool( thetype ) ) {
						return true;
					}

					dynamic _b = thetype; // Was a switch-case, sorry for the mess.
					if ( _b=="text" ) {
						((dynamic)this.master).buildmode.valueholder = Interface13.Input( Task13.User, "Enter variable value:", "Value", "value", null, InputType.Str );
					} else if ( _b=="number" ) {
						((dynamic)this.master).buildmode.valueholder = Interface13.Input( Task13.User, "Enter variable value:", "Value", 123, null, InputType.Num );
					} else if ( _b=="mob-reference" ) {
						((dynamic)this.master).buildmode.valueholder = Interface13.Input( Task13.User, "Enter variable value:", "Value", null, GlobalVars.mob_list, InputType.Mob );
					} else if ( _b=="obj-reference" ) {
						((dynamic)this.master).buildmode.valueholder = Interface13.Input( Task13.User, "Enter variable value:", "Value", null, Game13.contents, InputType.Obj );
					} else if ( _b=="turf-reference" ) {
						((dynamic)this.master).buildmode.valueholder = Interface13.Input( Task13.User, "Enter variable value:", "Value", null, Game13.contents, InputType.Tile );
					}
				}
			}
			return true;
		}

	}

}