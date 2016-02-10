// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Advance_VoiceChange : Disease_Advance {

		// Function from file: presets.dm
		public Disease_Advance_VoiceChange ( bool? process = null, Disease_Advance D = null, bool? copy = null ) : base( process, D ) {
			process = process ?? true;
			copy = copy ?? false;

			
			if ( !( D != null ) ) {
				this.name = "Epiglottis Mutation";
				this.symptoms = new ByTable(new object [] { new Symptom_VoiceChange() });
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}