// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_RemoveFat : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "remove loose fat";
			this.implements = new ByTable().Set( typeof(Obj_Item_Weapon_Retractor), 100 ).Set( typeof(Obj_Item_Weapon_Screwdriver), 45 ).Set( typeof(Obj_Item_Weapon_Wirecutters), 35 );
			this.time = 32;
		}

		// Function from file: lipoplasty.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			double removednutriment = 0;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human newmeat = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human meatslab = null;

			((Ent_Static)user).visible_message( "" + user + " extracts " + target + "'s fat!", "<span class='notice'>You extract " + target + "'s fat.</span>" );
			target.overeatduration = 0;
			removednutriment = target.nutrition;
			target.nutrition = 450;
			removednutriment -= 450;
			newmeat = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Human();
			newmeat.name = "fatty meat";
			newmeat.desc = "Extremely fatty tissue taken from a patient.";
			newmeat.reagents.add_reagent( "nutriment", removednutriment / 15 );
			meatslab = newmeat;
			meatslab.loc = target.loc;
			return true;
		}

		// Function from file: lipoplasty.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " begins to extract " + target + "'s loose fat!", "<span class='notice'>You begin to extract " + target + "'s loose fat...</span>" );
			return 0;
		}

	}

}