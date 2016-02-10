// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RuntimeError_DuplicateVariableDeclaration : RuntimeError {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "DuplicateVariableError";
		}

		// Function from file: Errors.dm
		public RuntimeError_DuplicateVariableDeclaration ( dynamic variable = null ) {
			this.message = "Variable '" + variable + "' was already declared.";
			return;
		}

	}

}