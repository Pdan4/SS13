// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Automation_Binary_Modulus : Automation_Binary {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "modulus";
			this.returntype = true;
			this.v_operator = "%";
		}

		public Automation_Binary_Modulus ( Obj_Machinery_Computer_GeneralAirControl_AtmosAutomation aa = null ) : base( aa ) {
			
		}

		// Function from file: statements.dm
		public override dynamic do_operation( dynamic a = null, dynamic b = null ) {
			
			if ( !Lang13.Bool( b ) ) {
				return Double.PositiveInfinity;
			}
			return a % b;
		}

	}

}