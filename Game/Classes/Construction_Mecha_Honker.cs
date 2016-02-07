// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Mecha_Honker : Construction_Mecha {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.result = "/obj/mecha/combat/honker";
			this.steps = new ByTable(new object [] { 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Bikehorn) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Clothing_Shoes_ClownShoes) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Bikehorn) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Clothing_Mask_Gas_ClownHat) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Bikehorn) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Circuitboard_Mecha_Honker_Targeting) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Bikehorn) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Circuitboard_Mecha_Honker_Peripherals) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Bikehorn) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Circuitboard_Mecha_Honker_Main) ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Bikehorn) )
			 });
		}

		public Construction_Mecha_Honker ( Game_Data atom = null ) : base( atom ) {
			
		}

		// Function from file: mecha_construction_paths.dm
		public override void spawn_result(  ) {
			base.spawn_result();
			GlobalFuncs.feedback_inc( "mecha_honker_created", 1 );
			return;
		}

		// Function from file: mecha_construction_paths.dm
		public override bool custom_action( int? index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			
			if ( !base.custom_action( index, (object)(diff), (object)(used_atom), (object)(user) ) ) {
				return false;
			}

			if ( diff is Obj_Item_Weapon_Bikehorn ) {
				GlobalFuncs.playsound( this.holder, "sound/items/bikehorn.ogg", 50, 1 );
				((Ent_Static)used_atom).visible_message( "HONK!" );
			}

			switch ((int?)( index )) {
				case 10:
					((Ent_Static)used_atom).visible_message( "" + used_atom + " installs the central control module into the " + this.holder + ".", "<span class='notice'>You install the central control module into the " + this.holder + ".</span>" );
					GlobalFuncs.qdel( diff );
					break;
				case 8:
					((Ent_Static)used_atom).visible_message( "" + used_atom + " installs the peripherals control module into the " + this.holder + ".", "<span class='notice'>You install the peripherals control module into the " + this.holder + ".</span>" );
					GlobalFuncs.qdel( diff );
					break;
				case 6:
					((Ent_Static)used_atom).visible_message( "" + used_atom + " installs the weapon control module into the " + this.holder + ".", "<span class='notice'>You install the weapon control module into the " + this.holder + ".</span>" );
					GlobalFuncs.qdel( diff );
					break;
				case 4:
					((Ent_Static)used_atom).visible_message( "" + used_atom + " puts clown wig and mask on the " + this.holder + ".", "<span class='notice'>You put clown wig and mask on the " + this.holder + ".</span>" );
					GlobalFuncs.qdel( diff );
					break;
				case 2:
					((Ent_Static)used_atom).visible_message( "" + used_atom + " puts clown boots on the " + this.holder + ".", "<span class='notice'>You put clown boots on the " + this.holder + ".</span>" );
					GlobalFuncs.qdel( diff );
					break;
			}
			return true;
		}

		// Function from file: mecha_construction_paths.dm
		public override bool action( dynamic used_atom = null, dynamic user = null ) {
			return this.check_step( used_atom, user );
		}

	}

}