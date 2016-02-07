// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimebloodlust : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bloodlust";
			this.id = "m_bloodlust";
			this.required_reagents = new ByTable().Set( "blood", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Red);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Mob_Living_SimpleAnimal_Slime slime = null;
			dynamic O = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ), typeof(Mob_Living_SimpleAnimal_Slime) )) {
				slime = _b;
				
				slime.rabid = true;

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ) )) {
					O = _a;
					
					O.show_message( "<span class='danger'>The " + slime + " is driven into a frenzy!</span>", 1 );
				}
			}
			return;
		}

	}

}