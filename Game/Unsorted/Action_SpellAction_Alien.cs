// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_SpellAction_Alien : Action_SpellAction {

		public Action_SpellAction_Alien ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: alien_powers.dm
		public override bool CheckRemoval( dynamic user = null ) {
			dynamic C = null;

			
			if ( !( this.owner is Mob_Living_Carbon ) ) {
				return true;
			}
			C = this.owner;

			if ( this.target.loc != null && !C.internal_organs.Contains( this.target.loc ) ) {
				return true;
			}
			return false;
		}

		// Function from file: alien_powers.dm
		public override dynamic IsAvailable(  ) {
			dynamic ab = null;

			
			if ( !Lang13.Bool( this.target ) ) {
				return 0;
			}
			ab = this.target;

			if ( Task13.User != null ) {
				return ((Obj_Effect_ProcHolder_Alien)ab).cost_check( ab.check_turf, Task13.User, true );
			} else if ( Lang13.Bool( this.owner ) ) {
				return ((Obj_Effect_ProcHolder_Alien)ab).cost_check( ab.check_turf, this.owner, true );
			}
			return 1;
		}

		// Function from file: alien_powers.dm
		public override string UpdateName(  ) {
			dynamic ab = null;

			ab = this.target;
			return ab.name;
		}

	}

}