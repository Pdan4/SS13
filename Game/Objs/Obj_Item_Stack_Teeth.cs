// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Teeth : Obj_Item_Stack {

		public Type animal_type = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "tooth";
			this.irregular_plural = "teeth";
			this.max_amount = 50;
			this.w_class = 1;
			this.throw_speed = 4;
			this.throw_range = 10;
			this.icon = "icons/obj/butchering_products.dmi";
			this.icon_state = "tooth";
		}

		// Function from file: teeth.dm
		public Obj_Item_Stack_Teeth ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -24, 24 );
			this.pixel_y = Rand13.Int( -24, 24 );
			return;
		}

		// Function from file: teeth.dm
		public void update_name( Mob_Living parent = null ) {
			Mob_Living L = null;
			Type parent_species = null;
			dynamic parent_species_name = null;

			
			if ( !( parent != null ) ) {
				return;
			}

			if ( parent is Mob_Living ) {
				L = parent;
				parent_species = L.species_type;
				parent_species_name = Lang13.Initial( parent_species, "name" );

				if ( parent is Mob_Living_Carbon_Human ) {
					parent_species_name = "" + parent + "'s";
				}
				this.name = "" + parent_species_name + " teeth";
				this.singular_name = "" + parent_species_name + " tooth";
				this.animal_type = parent_species;
			}
			return;
		}

		// Function from file: teeth.dm
		public override dynamic copy_evidences( Ent_Static from = null ) {
			dynamic _default = null;

			Ent_Static original_teeth = null;

			_default = base.copy_evidences( from );

			if ( from is Obj_Item_Stack_Teeth ) {
				original_teeth = from;
				this.animal_type = ((dynamic)original_teeth).animal_type;
				this.name = original_teeth.name;
				this.singular_name = original_teeth.name;
			}
			return _default;
		}

		// Function from file: teeth.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			dynamic C = null;
			Obj_Item_Clothing_Mask_Necklace_Teeth X = null;

			_default = base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Stack_CableCoil ) {
				C = a;

				if ( ( this.amount ??0) < 10 ) {
					GlobalFuncs.to_chat( b, "<span class='info'>You need at least 10 teeth to create a necklace.</span>" );
					return _default;
				}

				if ( Lang13.Bool( C.use( 5 ) ) ) {
					new ByTable().Set( 1, this ).Set( "force_drop", 1 ).Apply( Lang13.BindFunc( b, "drop_item" ) );
					X = new Obj_Item_Clothing_Mask_Necklace_Teeth( GlobalFuncs.get_turf( this ) );
					X.animal_type = this.animal_type;
					X.teeth_amount = this.amount;
					X.update_name();
					((Mob)b).put_in_active_hand( X );
					GlobalFuncs.to_chat( b, new Txt( "<span class='info'>You create a " ).item( X.name ).str( " out of " ).item( this.amount ).str( " " ).item( this ).str( " and " ).the( C ).item().str( ".</span>" ).ToString() );
					GlobalFuncs.qdel( this );
				} else {
					GlobalFuncs.to_chat( b, "<span class='info'>You need at least 5 lengths of cable to do this!</span>" );
				}
			}
			return _default;
		}

		// Function from file: teeth.dm
		public override bool can_stack_with( dynamic other_stack = null ) {
			dynamic T = null;

			
			if ( !( other_stack is Obj_Item ) ) {
				return false;
			}

			if ( this.type == other_stack.type ) {
				T = other_stack;

				if ( this.animal_type == T.animal_type ) {
					return true;
				}
			}
			return false;
		}

	}

}