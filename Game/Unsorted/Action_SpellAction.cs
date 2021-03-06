// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_SpellAction : Action {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.background_icon_state = "bg_spell";
		}

		public Action_SpellAction ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: action.dm
		public override bool CheckRemoval( dynamic user = null ) {
			
			if ( Lang13.Bool( this.owner.mind ) ) {
				
				if ( this.owner.mind.spell_list.Contains( this.target ) ) {
					return false;
				}
			}
			return !this.owner.mob_spell_list.Contains( this.target );
		}

		// Function from file: action.dm
		public override dynamic IsAvailable(  ) {
			dynamic spell = null;

			
			if ( !Lang13.Bool( this.target ) ) {
				return 0;
			}
			spell = this.target;

			if ( Task13.User != null ) {
				return ((Obj_Effect_ProcHolder_Spell)spell).can_cast( Task13.User );
			} else if ( Lang13.Bool( this.owner ) ) {
				return ((Obj_Effect_ProcHolder_Spell)spell).can_cast( this.owner );
			}
			return 1;
		}

		// Function from file: action.dm
		public override string UpdateName(  ) {
			dynamic spell = null;

			spell = this.target;
			return spell.name;
		}

		// Function from file: action.dm
		public override bool Trigger(  ) {
			dynamic spell = null;

			
			if ( !base.Trigger() ) {
				return false;
			}

			if ( Lang13.Bool( this.target ) ) {
				spell = this.target;
				spell.Click();
				return true;
			}
			return false;
		}

	}

}