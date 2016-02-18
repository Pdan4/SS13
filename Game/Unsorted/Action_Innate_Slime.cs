// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_Slime : Action_Innate {

		public int adult_action = -1;
		public bool needs_growth = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.check_flags = 8;
			this.background_icon_state = "bg_alien";
		}

		public Action_Innate_Slime ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: powers.dm
		public override dynamic IsAvailable(  ) {
			dynamic S = null;

			
			if ( Lang13.Bool( base.IsAvailable() ) ) {
				S = this.owner;

				if ( this.needs_growth ) {
					
					if ( Convert.ToDouble( S.amount_grown ) >= 10 ) {
						return 1;
					}
					return 0;
				}
				return 1;
			}
			return null;
		}

		// Function from file: powers.dm
		public override bool CheckRemoval( dynamic user = null ) {
			dynamic S = null;

			
			if ( !( this.owner is Mob_Living_SimpleAnimal_Slime ) ) {
				return true;
			}
			S = this.owner;

			if ( this.adult_action != -1 ) {
				
				if ( this.adult_action == 1 && !S.is_adult ) {
					return true;
				} else if ( this.adult_action == 0 && S.is_adult ) {
					return true;
				}
			}
			return false;
		}

	}

}