// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimeoverload : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime EMP";
			this.id = "m_emp";
			this.required_reagents = new ByTable().Set( "blood", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Yellow);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + GlobalFuncs.replacetext( this.name, " ", "_" ) );

			if ( !( holder.my_atom.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) ) {
				this.send_admin_alert( holder, "yellow slime + blood (EMP)" );
			} else {
				this.send_admin_alert( holder, "yellow slime + blood (EMP) in a grenade" );
			}
			GlobalFuncs.empulse( GlobalFuncs.get_turf( holder.my_atom ), 3, 7 );
			return;
		}

	}

}