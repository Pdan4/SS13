// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		public int ingMax = 100;
		public ByTable ingredients = new ByTable();
		public bool stackIngredients = false;
		public bool fullyCustom = false;
		public bool addTop = false;
		public Image topping = null;
		public Image filling = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bitesize = 2;
		}

		// Function from file: customizables.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable ( dynamic loc = null, dynamic ingredient = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.topping = new Image( this.icon, null, "" + Lang13.Initial( this, "icon_state" ) + "_top" );
			this.filling = new Image( this.icon, null, "" + Lang13.Initial( this, "icon_state" ) + "_filling" );
			((Reagents)this.reagents).add_reagent( "nutriment", 3 );
			this.updateName();
			return;
		}

		// Function from file: customizables.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			dynamic _default = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.ingredients )) {
				_default = _a;
				
				GlobalFuncs.qdel( _default );
			}
			return base.Destroy( (object)(brokenup) );
		}

		// Function from file: customizables.dm
		public void drawTopping(  ) {
			Image I = null;

			I = this.topping;
			I.pixel_y = ( this.ingredients.len + 1 ) * 2;
			this.overlays.Add( I );
			return;
		}

		// Function from file: customizables.dm
		public string updateName(  ) {
			int i = 0;
			string new_name = null;
			Obj_Item S = null;

			i = 1;

			foreach (dynamic _a in Lang13.Enumerate( this.ingredients, typeof(Obj_Item) )) {
				S = _a;
				

				if ( i == 1 ) {
					new_name += "" + S.name;
				} else if ( i == this.ingredients.len ) {
					new_name += " and " + S.name;
				} else {
					new_name += ", " + S.name;
				}
				i++;
			}
			new_name = "" + new_name + " " + Lang13.Initial( this, "name" );

			if ( Lang13.Length( new_name ) >= 150 ) {
				this.name = "something yummy";
			} else {
				this.name = new_name;
			}
			return new_name;
		}

		// Function from file: customizables.dm
		public Image generateFilling( dynamic S = null, dynamic _params = null ) {
			Image I = null;
			Icon C = null;
			double? clicked_x = null;

			
			if ( this.fullyCustom ) {
				C = GlobalFuncs.getFlatIcon( S, Lang13.DoubleNullable( S.dir ), 0 );
				I = new Image( C );
				I.pixel_y = ((int)( 12 - ( GlobalFuncs.empty_Y_space( C ) ??0) ));
			} else {
				I = this.filling;

				if ( S is Obj_Item_Weapon_ReagentContainers_Food_Snacks && S.filling_color != "#FFFFFF" ) {
					I.color = S.filling_color;
				} else {
					I.color = GlobalFuncs.AverageColor( GlobalFuncs.getFlatIcon( S, Lang13.DoubleNullable( S.dir ), 0 ), true, true );
				}

				if ( this.stackIngredients ) {
					I.pixel_y = this.ingredients.len * 2;
				} else {
					this.overlays.len = 0;
				}
			}

			if ( this.fullyCustom || this.stackIngredients ) {
				clicked_x = String13.ParseNumber( String13.ParseUrlParams( _params )["icon-x"] );

				if ( clicked_x == null ) {
					I.pixel_x = 0;
				} else if ( ( clicked_x ??0) < 9 ) {
					I.pixel_x = -2;
				} else if ( ( clicked_x ??0) < 14 ) {
					I.pixel_x = -1;
				} else if ( ( clicked_x ??0) < 19 ) {
					I.pixel_x = 0;
				} else if ( ( clicked_x ??0) < 25 ) {
					I.pixel_x = 1;
				} else {
					I.pixel_x = 2;
				}
			}
			return I;
		}

		// Function from file: customizables.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			dynamic S = null;
			dynamic SC = null;
			string newcolor = null;

			
			if ( a is Obj_Item_Weapon_ReagentContainers_Food_Snacks ) {
				
				if ( this.contents.len >= this.ingMax || this.contents.len >= Convert.ToDouble( GlobalVars.ingredientLimit ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>That's already looking pretty stuffed.</span>" );
					return _default;
				}
				S = a;

				if ( S is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable ) {
					SC = S;

					if ( this.fullyCustom && SC.fullyCustom ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>You slap yourself on the back of the head for thinking that stacking plates is an interesting dish.</span>" );
						GlobalFuncs.message_admins( "<span class='warning'>POSSIBLE EXPLOIT ATTEMPT:</span> " + GlobalFuncs.key_name_admin( b ) + " tried to stack multiple plates together, which used to generate excessive atom names, resulting in crashes. See <a href='https://github.com/d3athrow/vgstation13/issues/6402'>#6402</a>." );
						return _default;
					}
				}

				if ( !GlobalVars.recursiveFood && a is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + Rand13.Pick(new object [] { "Sorry, no recursive food.", "That would be a straining topological exercise.", "This world just isn't ready for your cooking genius.", "It's possible that you may have a problem.", "It won't fit.", "You don't think that would taste very good.", "Quit goofin' around." }) + "</span>" );
					return _default;
				}

				if ( !Lang13.Bool( b.drop_item( a, this ) ) ) {
					b.WriteMsg( new Txt( "<span class='warning'>" ).The( a ).item().str( " is stuck to your hands!</span>" ).ToString() );
					return _default;
				}
				((Reagents)S.reagents).trans_to( this, S.reagents.total_volume );
				this.ingredients.Add( S );

				if ( this.addTop ) {
					this.overlays.Remove( this.topping );
				}

				if ( !this.fullyCustom && !this.stackIngredients && this.overlays.len != 0 ) {
					this.overlays.Remove( this.filling );
					newcolor = ( S.filling_color != "#FFFFFF" ? S.filling_color : GlobalFuncs.AverageColor( GlobalFuncs.getFlatIcon( S, Lang13.DoubleNullable( S.dir ), 0 ), true, true ) );
					this.filling.color = GlobalFuncs.BlendRGB( this.filling.color, newcolor, 1 / this.ingredients.len );
					this.overlays.Add( this.filling );
				} else {
					this.overlays.Add( this.generateFilling( S, c ) );
				}

				if ( this.addTop ) {
					this.drawTopping();
				}
				this.updateName();
				GlobalFuncs.to_chat( b, "<span class='notice'>You add the " + a.name + " to the " + this.name + ".</span>" );
			} else {
				_default = base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return _default;
		}

	}

}