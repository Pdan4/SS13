// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ScriptError_DuplicateFunction : ScriptError {

		// Function from file: Errors.dm
		public ScriptError_DuplicateFunction ( dynamic name = null, dynamic t = null ) : base( (object)(name) ) {
			this.message = "Function '" + name + "' defined twice.";
			return;
		}

	}

}