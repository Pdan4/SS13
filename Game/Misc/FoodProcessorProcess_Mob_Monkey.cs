// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class FoodProcessorProcess_Mob_Monkey : FoodProcessorProcess_Mob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.input = typeof(Mob_Living_Carbon_Monkey);
		}

		// Function from file: processor.dm
		public override void process( Ent_Static loc = null, Ent_Dynamic what = null ) {
			Ent_Dynamic O = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Bucket bucket_of_blood = null;
			Reagent_Blood B = null;
			Disease D = null;

			O = what;

			if ( Lang13.Bool( ((dynamic)O).client ) ) {
				O.loc = loc;
				O.visible_message( "<span class='notice'>" + O + " suddenly jumps out of " + this + "!</span>", "You jump out from the processor", "You hear a slimy sound" );
				return;
			}
			bucket_of_blood = new Obj_Item_Weapon_ReagentContainers_Glass_Bucket( loc );
			B = new Reagent_Blood();
			B.holder = bucket_of_blood;
			B.volume = 70;
			B.data["donor"] = O;

			foreach (dynamic _a in Lang13.Enumerate( ((dynamic)O).viruses, typeof(Disease) )) {
				D = _a;
				

				if ( D.spread_type != -1 ) {
					B.data["viruses"] += D.Copy();
				}
			}
			B.data["blood_DNA"] = String13.SubStr( ((dynamic)O).dna.unique_enzymes, 1, 0 );

			if ( Lang13.Bool( ((dynamic)O).resistances ) && ((dynamic)O).resistances.len != 0 ) {
				B.data["resistances"] = ((dynamic)O).resistances.Copy();
			}
			bucket_of_blood.reagents.reagent_list += B;
			((Reagents)bucket_of_blood.reagents).update_total();
			bucket_of_blood.on_reagent_change();
			base.process( loc, what );
			return;
		}

	}

}