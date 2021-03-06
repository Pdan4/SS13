// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimecrit : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Crit";
			this.id = "m_tele";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Gold);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic T = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			T = GlobalFuncs.get_turf( holder.my_atom );
			((Ent_Static)T).visible_message( "<span class='danger'>The slime extract begins to vibrate violently !</span>" );
			Task13.Schedule( 50, (Task13.Closure)(() => {
				this.chemical_mob_spawn( holder, 5, "Gold Slime" );
				return;
			}));
			return;
		}

	}

}