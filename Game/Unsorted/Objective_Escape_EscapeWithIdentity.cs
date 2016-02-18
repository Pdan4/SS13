// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Escape_EscapeWithIdentity : Objective_Escape {

		public string target_real_name = null;
		public bool target_missing_id = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dangerrating = 10;
		}

		public Objective_Escape_EscapeWithIdentity ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override int check_completion(  ) {
			Mob_Living_Carbon_Human H = null;

			
			if ( !Lang13.Bool( this.target_real_name ) ) {
				return 1;
			}

			if ( !( this.owner.current is Mob_Living_Carbon_Human ) ) {
				return 0;
			}
			H = this.owner.current;

			if ( base.check_completion() != 0 ) {
				
				if ( H.dna.real_name == this.target_real_name ) {
					
					if ( H.get_id_name() == this.target_real_name || this.target_missing_id ) {
						return 1;
					}
				}
			}
			return 0;
		}

		// Function from file: objective.dm
		public override void update_explanation_text(  ) {
			Mob_Living_Carbon_Human H = null;

			
			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) ) {
				this.target_real_name = this.target.current.real_name;
				this.explanation_text = "Escape on the shuttle or an escape pod with the identity of " + this.target_real_name + ", the " + this.target.assigned_role;

				if ( this.target.current is Mob_Living_Carbon_Human ) {
					H = this.target.current;
				}

				if ( H != null && H.get_id_name() != this.target_real_name ) {
					this.target_missing_id = true;
				} else {
					this.explanation_text += " while wearing their identification card";
				}
				this.explanation_text += ".";
			} else {
				this.explanation_text = "Free Objective.";
			}
			return;
		}

		// Function from file: objective.dm
		public override dynamic find_target(  ) {
			this.target = base.find_target();
			this.update_explanation_text();
			return null;
		}

	}

}