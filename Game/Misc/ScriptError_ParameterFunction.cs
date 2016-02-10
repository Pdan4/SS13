// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ScriptError_ParameterFunction : ScriptError {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.message = "You cannot use a function inside a parameter.";
		}

		// Function from file: Errors.dm
		public ScriptError_ParameterFunction ( Base_Data t = null ) : base( t ) {
			string line = null;

			line = "?";

			if ( t != null ) {
				line = ((dynamic)t).line;
			}
			this.message = "" + line + ": " + this.message;
			return;
		}

	}

}