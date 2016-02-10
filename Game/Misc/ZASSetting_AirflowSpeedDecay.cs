// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ZASSetting_AirflowSpeedDecay : ZASSetting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.value = 1.5;
			this.name = "Airflow Speed Decay";
			this.desc = "How rapidly the speed gained from airflow decays.";
			this.valtype = 1;
		}

	}

}