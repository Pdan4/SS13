// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_EnergyField : Obj_Effect {

		public double strength = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 101;
			this.anchored = 1;
			this.icon = "code/WorkInProgress/Cael_Aislinn/ShieldGen/shielding.dmi";
			this.icon_state = "shieldsparkles";
			this.layer = 4.1;
		}

		public Obj_Effect_EnergyField ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: energy_field.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			return !this.density;
		}

		// Function from file: energy_field.dm
		public void Strengthen( double severity = 0 ) {
			this.strength += severity;

			if ( this.strength >= 1 ) {
				this.invisibility = 0;
				this.density = true;
			} else if ( this.strength < 1 ) {
				this.invisibility = 101;
				this.density = false;
			}
			return;
		}

		// Function from file: energy_field.dm
		public void Stress( double severity = 0 ) {
			this.strength -= severity;

			if ( this.strength < 1 ) {
				this.invisibility = 101;
				this.density = false;
			} else if ( this.strength >= 1 ) {
				this.invisibility = 0;
				this.density = true;
			}
			return;
		}

		// Function from file: energy_field.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.Stress( Convert.ToDouble( Proj.damage / 10 ) );
			return null;
		}

		// Function from file: energy_field.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			this.Stress( ( severity ??0) + 0.5 );
			return false;
		}

	}

}