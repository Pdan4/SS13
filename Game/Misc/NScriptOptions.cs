// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NScriptOptions : Game_Data {

		// Function from file: Options.dm
		public bool IsValidID( string id = null ) {
			double i = 0;

			
			if ( !this.CanStartID( id ) ) {
				return false;
			}

			if ( Lang13.Length( id ) == 1 ) {
				return true;
			}

			foreach (dynamic _a in Lang13.IterateRange( 2, Lang13.Length( id ) )) {
				i = _a;
				

				if ( !this.IsValidIDChar( String13.SubStr( id, ((int)( i )), ((int)( i + 1 )) ) ) ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: Options.dm
		public bool IsDigit( dynamic _char = null ) {
			
			if ( !Lang13.Bool( Lang13.IsNumber( _char ) ) ) {
				_char = String13.GetCharCode( _char, null );
			}
			return Lang13.IsInRange( Convert.ToDouble( _char ), GlobalVars.ascii_ZERO, GlobalVars.ascii_NINE );
		}

		// Function from file: Options.dm
		public bool IsValidIDChar( dynamic _char = null ) {
			
			if ( !Lang13.Bool( Lang13.IsNumber( _char ) ) ) {
				_char = String13.GetCharCode( _char, null );
			}
			return this.CanStartID( _char ) || this.IsDigit( _char );
		}

		// Function from file: Options.dm
		public bool CanStartID( dynamic _char = null ) {
			
			if ( !Lang13.Bool( Lang13.IsNumber( _char ) ) ) {
				_char = String13.GetCharCode( _char, null );
			}
			return Lang13.IsInRange( Convert.ToDouble( _char ), GlobalVars.ascii_A, GlobalVars.ascii_Z ) || Lang13.IsInRange( Convert.ToDouble( _char ), GlobalVars.ascii_a, GlobalVars.ascii_z ) || _char == GlobalVars.ascii_UNDERSCORE || _char == GlobalVars.ascii_DOLLAR;
		}

	}

}