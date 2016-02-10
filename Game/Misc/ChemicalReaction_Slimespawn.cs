// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimespawn : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Spawn";
			this.id = "m_spawn";
			this.required_reagents = new ByTable().Set( "plasma", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Grey);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			Mob_Living_Carbon_Slime S = null;

			
			if ( holder.my_atom.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) {
				this.send_admin_alert( holder, "grey slime in a grenade" );
			} else {
				this.send_admin_alert( holder, "grey slime" );
			}
			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + GlobalFuncs.replacetext( this.name, " ", "_" ) );

			if ( holder.my_atom.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) {
				holder.my_atom.visible_message( "<span class='rose'>The grenade bursts open and a new baby slime emerges from it!</span>" );
			} else {
				holder.my_atom.visible_message( "<span class='rose'>Infused with plasma, the core begins to quiver and grow, and soon a new baby slime emerges from it!</span>" );
			}
			S = new Mob_Living_Carbon_Slime();
			S.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}