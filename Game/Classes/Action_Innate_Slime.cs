// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

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

		public Action_Innate_Slime ( dynamic Target = null ) : base( (object)(Target) ) {
			
		}

		// Function from file: powers.dm
		public override bool IsAvailable(  ) {
			dynamic S = null;

			
			if ( base.IsAvailable() ) {
				S = this.owner;

				if ( this.needs_growth ) {
					
					if ( Convert.ToDouble( S.amount_grown ) >= 10 ) {
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
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