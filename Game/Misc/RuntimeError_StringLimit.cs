// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RuntimeError_StringLimit : RuntimeError {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "StringSizeOverflow";
			this.message = "Maximum string size reached";
		}

	}

}