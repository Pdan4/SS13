// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_Mecha_MechCycleEquip : Action_Innate_Mecha {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cycle Equipment";
			this.button_icon_state = "mech_cycle_equip_off";
		}

		public Action_Innate_Mecha_MechCycleEquip ( dynamic Target = null ) : base( (object)(Target) ) {
			
		}

		// Function from file: mecha.dm
		public override void Activate(  ) {
			int number = 0;
			dynamic A = null;

			
			if ( !Lang13.Bool( this.owner ) || !( this.chassis != null ) || this.chassis.occupant != this.owner ) {
				return;
			}

			if ( this.chassis.equipment.len == 0 ) {
				this.chassis.occupant_message( "No equipment available." );
				return;
			}

			if ( !Lang13.Bool( this.chassis.selected ) ) {
				this.chassis.selected = this.chassis.equipment[1];
				this.chassis.occupant_message( "You select " + this.chassis.selected );
				GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", "eq_list", this.chassis.get_equipment_list() );
				this.button_icon_state = "mech_cycle_equip_on";
				return;
			}
			number = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.chassis.equipment )) {
				A = _a;
				
				number++;

				if ( A == this.chassis.selected ) {
					
					if ( this.chassis.equipment.len == number ) {
						this.chassis.selected = null;
						this.chassis.occupant_message( "You switch to no equipment" );
						this.button_icon_state = "mech_cycle_equip_off";
					} else {
						this.chassis.selected = this.chassis.equipment[number + 1];
						this.chassis.occupant_message( "You switch to " + this.chassis.selected );
						this.button_icon_state = "mech_cycle_equip_on";
					}
					GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", "eq_list", this.chassis.get_equipment_list() );
					return;
				}
			}
			return;
		}

	}

}