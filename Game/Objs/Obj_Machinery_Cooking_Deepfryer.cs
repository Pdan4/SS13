// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Cooking_Deepfryer : Obj_Machinery_Cooking {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state_on = "fryer_on";
			this.foodChoices = null;
			this.cookTime = 170;
			this.recursive_ingredients = true;
			this.cks_max_volume = 400;
			this.cooks_in_reagents = true;
			this.icon_state = "fryer_off";
		}

		public Obj_Machinery_Cooking_Deepfryer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cooking_machines.dm
		public override dynamic makeFood( dynamic foodType = null ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Deepfryholder D = null;
			dynamic H = null;

			
			if ( this.ingredient is Obj_Item_Weapon_ReagentContainers_Food_Snacks ) {
				
				if ( this.cooks_in_reagents ) {
					this.transfer_reagents_to_food( this.ingredient );
				}
				this.ingredient.name = "deep fried " + this.ingredient.name;
				this.ingredient.color = "#FFAD33";
				this.ingredient.loc = this.loc;
			} else {
				D = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Deepfryholder( this.loc );

				if ( this.cooks_in_reagents ) {
					this.transfer_reagents_to_food( D );
				}
				D.name = "deep fried " + this.ingredient.name;
				D.color = "#FFAD33";
				D.icon = this.ingredient.icon;
				D.icon_state = this.ingredient.icon_state;
				D.overlays = this.ingredient.overlays;

				if ( this.ingredient is Obj_Item_Weapon_Holder ) {
					H = this.ingredient;

					if ( H.stored_mob != null ) {
						((dynamic)H.stored_mob).ghostize();
						((dynamic)H.stored_mob).death();
						GlobalFuncs.qdel( H.stored_mob );
					}
				}
				GlobalFuncs.qdel( this.ingredient );
			}
			this.ingredient = null;
			this.empty_icon();
			return null;
		}

		// Function from file: cooking_machines.dm
		public override string validateIngredient( dynamic I = null ) {
			string _default = null;

			_default = base.validateIngredient( (object)(I) );

			if ( _default == "valid" && !GlobalVars.foodNesting ) {
				
				if ( String13.FindIgnoreCase( I.name, "fried", 1, 0 ) != 0 ) {
					_default = "It's already deep-fried.";
				} else if ( String13.FindIgnoreCase( I.name, "grilled", 1, 0 ) != 0 ) {
					_default = "It's already grilled.";
				}
			}
			return _default;
		}

		// Function from file: cooking_machines.dm
		public override dynamic takeIngredient( dynamic I = null, dynamic user = null ) {
			
			if ( ( this.reagents.total_volume ??0) < 50 ) {
				GlobalFuncs.to_chat( user, new Txt().The( this ).item().str( " doesn't have enough oil to fry in." ).ToString() );
				return null;
			} else {
				return base.takeIngredient( (object)(I), (object)(user) );
			}
		}

		// Function from file: cooking_machines.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(a), (object)(b), (object)(c) );
			this.empty_icon();
			return _default;
		}

		// Function from file: cooking_machines.dm
		public void empty_icon(  ) {
			((Reagents)this.reagents).update_total();

			if ( Lang13.Bool( this.ingredient ) ) {
				this.icon_state = "fryer_on";
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/deep_fryer.ogg", 100, 1 );
			} else if ( ( this.reagents.total_volume ??0) < 50 ) {
				this.icon_state = "fryer_empty";
			} else {
				this.icon_state = Lang13.Initial( this, "icon_state" );
			}
			return;
		}

		// Function from file: cooking_machines.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			base.initialize( suppress_icon_check );
			((Reagents)this.reagents).add_reagent( "cornoil", 300 );
			return false;
		}

		// Function from file: cooking_machines.dm
		[Verb]
		[VerbInfo( name: "Remove ingredients", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public override void flush_reagents(  ) {
			base.flush_reagents();
			this.empty_icon();
			return;
		}

	}

}