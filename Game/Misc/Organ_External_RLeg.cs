// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ_External_RLeg : Organ_External {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "r_leg";
			this.display_name = "right leg";
			this.icon_name = "r_leg";
			this.max_damage = 75;
			this.body_part = 16;
			this.icon_position = 2;
		}

		public Organ_External_RLeg ( dynamic P = null ) : base( (object)(P) ) {
			
		}

		// Function from file: organ_external.dm
		public override Obj_Item generate_dropped_organ( Obj_Item current_organ = null ) {
			
			if ( this.is_peg() != 0 ) {
				current_organ = new Obj_Item_Stack_Sheet_Wood( this.owner.loc );
			}

			if ( !( current_organ != null ) ) {
				
				if ( this.is_robotic() != 0 ) {
					current_organ = new Obj_Item_RobotParts_RLeg( this.owner.loc );
				} else {
					current_organ = new Obj_Item_Weapon_Organ_RLeg( this.owner.loc, this.owner );
				}
			}
			return current_organ;
		}

	}

}