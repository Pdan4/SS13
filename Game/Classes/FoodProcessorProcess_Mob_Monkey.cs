// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class FoodProcessorProcess_Mob_Monkey : FoodProcessorProcess_Mob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.input = typeof(Mob_Living_Carbon_Monkey);
		}

		// Function from file: processor.dm
		public override void process_food( Ent_Static loc = null, dynamic what = null, Obj_Machinery_Processor processor = null ) {
			dynamic O = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Bucket bucket_of_blood = null;
			Reagent_Blood B = null;
			Disease D = null;

			O = what;

			if ( Lang13.Bool( O.client ) ) {
				O.loc = loc;
				((Ent_Static)O).visible_message( "<span class='notice'>Suddenly " + O + " jumps out from the processor!</span>", "<span class='notice'>You jump out from the processor!</span>", "<span class='italics'>You hear chimpering.</span>" );
				return;
			}
			bucket_of_blood = new Obj_Item_Weapon_ReagentContainers_Glass_Bucket( loc );
			B = new Reagent_Blood();
			B.holder = bucket_of_blood;
			B.volume = 70;
			B.data["donor"] = O;

			foreach (dynamic _a in Lang13.Enumerate( O.viruses, typeof(Disease) )) {
				D = _a;
				

				if ( !( ( D.spread_flags & 1 ) != 0 ) ) {
					B.data["viruses"] += D.Copy();
				}
			}

			if ( Lang13.Bool( O.has_dna() ) ) {
				B.data["blood_DNA"] = O.dna.unique_enzymes;
			}

			if ( O.resistances != null && O.resistances.len != 0 ) {
				B.data["resistances"] = O.resistances.Copy();
			}
			bucket_of_blood.reagents.reagent_list.Add( B );
			bucket_of_blood.reagents.update_total();
			bucket_of_blood.on_reagent_change();
			base.process_food( loc, (object)(what), processor );
			return;
		}

	}

}