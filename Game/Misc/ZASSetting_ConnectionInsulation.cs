// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ZASSetting_ConnectionInsulation : ZASSetting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.value = 0.4;
			this.name = "Connections - Insulation";
			this.desc = "How insulative a connection is, in terms of heat transfer.  1 is perfectly insulative, and 0 is perfectly conductive.";
			this.valtype = 1;
		}

	}

}