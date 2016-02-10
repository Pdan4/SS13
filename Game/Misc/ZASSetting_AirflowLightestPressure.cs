// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ZASSetting_AirflowLightestPressure : ZASSetting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.value = 20;
			this.name = "Airflow - Small Movement Threshold %";
			this.desc = "Percent of 1 Atm. at which items with the small weight classes will move.";
			this.valtype = 1;
		}

	}

}