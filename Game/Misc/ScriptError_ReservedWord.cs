// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ScriptError_ReservedWord : ScriptError_BadToken {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.message = "Identifer using reserved word: ";
		}

		public ScriptError_ReservedWord ( Base_Data t = null ) : base( t ) {
			
		}

	}

}