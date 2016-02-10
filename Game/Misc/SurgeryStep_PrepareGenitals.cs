// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_PrepareGenitals : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_tools = new ByTable().Set( typeof(Obj_Item_Weapon_Retractor), 100 ).Set( typeof(Obj_Item_Weapon_Crowbar), 75 ).Set( typeof(Obj_Item_Weapon_Kitchen_Utensil_Fork), 50 );
			this.priority = 1;
			this.min_duration = 40;
			this.max_duration = 60;
		}

		// Function from file: genderchange.dm
		public override bool? fail_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( "<span class='warning'>" + user + " accidentally tears " + target + "'s genitals!</span>" );
			((Mob_Living)target).apply_damage( 10, "brute", "groin", 1 );
			return true;
		}

		// Function from file: genderchange.dm
		public override bool end_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( "<span class='notice'>" + user + " pulls " + target + "'s genitals into place for reshaping!</span>" );
			target.op_stage.genitals = true;
			return true;
		}

		// Function from file: genderchange.dm
		public override bool begin_step( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null, dynamic surgery = null ) {
			((Ent_Static)user).visible_message( "<span class='notice'>" + user + " prepares " + target + "'s genitals for reshaping.</span>" );
			return false;
		}

		// Function from file: genderchange.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			dynamic affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );

			if ( Lang13.Bool( target.species.flags & 32768 ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>" + target + " has no genitalia to prepare.</span>" );
				return 0;
			}
			return target_zone == "groin" && GlobalFuncs.hasorgans( target ) && Convert.ToDouble( affected.open ) >= 2 && Lang13.Bool( affected.stage ) == false ?1:0;
		}

	}

}