// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NKeyword_NSKeyword_KwReturn : NKeyword_NSKeyword {

		public NKeyword_NSKeyword_KwReturn ( bool? inline = null ) : base( inline ) {
			
		}

		// Function from file: Keywords.dm
		public override int Parse( NParser parser = null ) {
			int _default = 0;

			Node_Statement_ReturnStatement stmt = null;

			_default = GlobalVars.KW_PASS ?1:0;

			if ( parser.curBlock is Node_BlockDefinition_GlobalBlock ) {
				parser.tokens.len = parser.index;
				return _default;
			}
			stmt = new Node_Statement_ReturnStatement();
			parser.NextToken();
			stmt.value = ((dynamic)parser).ParseExpression();
			parser.curBlock.statements.Add( stmt );
			return _default;
		}

	}

}