// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chococoin : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.food_flags = 4;
			this.bitesize = 4;
			this.icon_state = "chococoin_unwrapped";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chococoin ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 2 );
			((Reagents)this.reagents).add_reagent( "sugar", 2 );
			((Reagents)this.reagents).add_reagent( "coco", 3 );
			return;
		}

		// Function from file: snacks.dm
		public void Unwrap( dynamic user = null ) {
			this.icon_state = "chococoin_unwrapped";
			this.desc = "A thin wafer of milky, chocolatey, melt-in-your-mouth goodness. That alone is already worth a hoard.";
			GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>You remove the golden foil from " ).the( this ).item().str( ".</span>" ).ToString() );
			this.wrapped = false;
			return;
		}

		// Function from file: snacks.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.wrapped ) {
				this.Unwrap( user );
			} else {
				base.attack_self( (object)(user), (object)(flag), emp );
			}
			return null;
		}

	}

}