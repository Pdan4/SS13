// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dynamic_Virtualspeaker : Ent_Dynamic {

		public dynamic job = null;
		public dynamic source = null;
		public dynamic radio = null;

		public Dynamic_Virtualspeaker ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: say.dm
		public override dynamic Destroy(  ) {
			base.Destroy();
			return 5;
		}

		// Function from file: say.dm
		public override dynamic GetRadio(  ) {
			return this.radio;
		}

		// Function from file: say.dm
		public override dynamic GetSource(  ) {
			return this.source;
		}

		// Function from file: say.dm
		public override dynamic GetJob(  ) {
			return this.job;
		}

	}

}