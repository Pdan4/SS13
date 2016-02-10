// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_SilenceSting : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Silence Sting";
			this.desc = "We silently sting a human, completely silencing them for a short time.";
			this.helptext = "Does not provide a warning to a victim that they have been stung, until they try to speak and cannot.";
			this.genomecost = 2;
			this.allowduringlesserform = true;
			this.verbpath = typeof(Mob).GetMethod( "changeling_silence_sting" );
		}

	}

}