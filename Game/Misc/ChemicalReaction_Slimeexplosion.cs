// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimeexplosion : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Explosion";
			this.id = "m_explosion";
			this.required_reagents = new ByTable().Set( "plasma", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Oil);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + GlobalFuncs.replacetext( this.name, " ", "_" ) );

			if ( !( holder.my_atom.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) ) {
				holder.my_atom.visible_message( "<span class='warning'>The slime extract begins to vibrate violently !</span>" );
				this.send_admin_alert( holder, "oil slime + plasma (Explosion)" );
				Task13.Sleep( 50 );
			} else {
				this.send_admin_alert( holder, "oil slime + plasma (Explosion) in a grenade" );
			}
			GlobalFuncs.explosion( GlobalFuncs.get_turf( holder.my_atom ), 1, 3, 6 );
			return;
		}

	}

}