// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Gender : Game_Data {

		public string name = "";
		public string subject = "";
		public string objective = "";
		public string reflexive = "";
		public string possessive = "";
		public string possessivePronoun = "";
		public bool? _complex = false;

		// Function from file: gender.dm
		public Gender ( string label = null, string subj = null, string obj = null, string _ref = null, string pos = null, string pp = null, bool? complex = null ) {
			complex = complex ?? false;

			this.name = label;
			this.subject = subj;
			this.objective = obj;
			this.reflexive = _ref;
			this.possessive = pos;
			this.possessivePronoun = pp;
			this._complex = complex;
			return;
		}

		// Function from file: gender.dm
		public string replace( string s = null ) {
			
			if ( String13.FindIgnoreCase( s, "$sub", 1, 0 ) != 0 ) {
				s = GlobalFuncs.replacetextEx( s, "$sub", this.subject );
				s = GlobalFuncs.replacetextEx( s, "$Sub", GlobalFuncs.capitalize( this.subject ) );
				s = GlobalFuncs.replacetextEx( s, "$SUB", String13.ToUpper( this.subject ) );
			}

			if ( String13.FindIgnoreCase( s, "$obj", 1, 0 ) != 0 ) {
				s = GlobalFuncs.replacetextEx( s, "$obj", this.objective );
				s = GlobalFuncs.replacetextEx( s, "$Obj", GlobalFuncs.capitalize( this.objective ) );
				s = GlobalFuncs.replacetextEx( s, "$OBJ", String13.ToUpper( this.objective ) );
			}

			if ( String13.FindIgnoreCase( s, "$ref", 1, 0 ) != 0 ) {
				s = GlobalFuncs.replacetextEx( s, "$ref", this.reflexive );
				s = GlobalFuncs.replacetextEx( s, "$Ref", GlobalFuncs.capitalize( this.reflexive ) );
				s = GlobalFuncs.replacetextEx( s, "$REF", String13.ToUpper( this.reflexive ) );
			}

			if ( String13.FindIgnoreCase( s, "$posp", 1, 0 ) != 0 ) {
				s = GlobalFuncs.replacetextEx( s, "$posp", this.possessivePronoun );
				s = GlobalFuncs.replacetextEx( s, "$Posp", GlobalFuncs.capitalize( this.possessivePronoun ) );
				s = GlobalFuncs.replacetextEx( s, "$POSP", String13.ToUpper( this.possessivePronoun ) );
			}

			if ( String13.FindIgnoreCase( s, "$pos", 1, 0 ) != 0 ) {
				s = GlobalFuncs.replacetextEx( s, "$pos", this.possessive );
				s = GlobalFuncs.replacetextEx( s, "$Pos", GlobalFuncs.capitalize( this.possessive ) );
				s = GlobalFuncs.replacetextEx( s, "$POS", String13.ToUpper( this.possessive ) );
			}

			if ( !( this._complex == true ) ) {
				
				if ( String13.FindIgnoreCase( s, "$himself", 1, 0 ) != 0 ) {
					s = GlobalFuncs.replacetextEx( s, "$himself", this.getHimself() );
					s = GlobalFuncs.replacetextEx( s, "$Himself", GlobalFuncs.capitalize( this.getHimself() ) );
					s = GlobalFuncs.replacetextEx( s, "$HIMSELF", String13.ToUpper( this.getHimself() ) );
				}

				if ( String13.FindIgnoreCase( s, "$him", 1, 0 ) != 0 ) {
					s = GlobalFuncs.replacetextEx( s, "$him", this.getHim() );
					s = GlobalFuncs.replacetextEx( s, "$Him", GlobalFuncs.capitalize( this.getHim() ) );
					s = GlobalFuncs.replacetextEx( s, "$HIM", String13.ToUpper( this.getHim() ) );
				}

				if ( String13.FindIgnoreCase( s, "$his", 1, 0 ) != 0 ) {
					s = GlobalFuncs.replacetextEx( s, "$his", this.getHis() );
					s = GlobalFuncs.replacetextEx( s, "$His", GlobalFuncs.capitalize( this.getHis() ) );
					s = GlobalFuncs.replacetextEx( s, "$HIS", String13.ToUpper( this.getHis() ) );
				}

				if ( String13.FindIgnoreCase( s, "$he", 1, 0 ) != 0 ) {
					s = GlobalFuncs.replacetextEx( s, "$he", this.getHe() );
					s = GlobalFuncs.replacetextEx( s, "$He", GlobalFuncs.capitalize( this.getHe() ) );
					s = GlobalFuncs.replacetextEx( s, "$HE", String13.ToUpper( this.getHe() ) );
				}

				if ( String13.FindIgnoreCase( s, "$hers", 1, 0 ) != 0 ) {
					s = GlobalFuncs.replacetextEx( s, "$hers", this.getHers() );
					s = GlobalFuncs.replacetextEx( s, "$Hers", GlobalFuncs.capitalize( this.getHers() ) );
					s = GlobalFuncs.replacetextEx( s, "$HERS", String13.ToUpper( this.getHers() ) );
				}
			}
			return s;
		}

		// Function from file: gender.dm
		public string getHe(  ) {
			
			if ( this._complex == true ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getHe() unsupported for gender " + this.name + "}" ) );
				return "";
			}
			return this.subject;
		}

		// Function from file: gender.dm
		public string getHers(  ) {
			
			if ( this._complex == true ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getHers() unsupported for gender " + this.name + "}" ) );
				return "";
			}
			return this.possessivePronoun;
		}

		// Function from file: gender.dm
		public string getHimself(  ) {
			
			if ( this._complex == true ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getHimself() unsupported for gender " + this.name + "}" ) );
				return "";
			}
			return this.reflexive;
		}

		// Function from file: gender.dm
		public string getHis(  ) {
			
			if ( this._complex == true ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getHis() unsupported for gender " + this.name + "}" ) );
				return "";
			}
			return this.possessive;
		}

		// Function from file: gender.dm
		public string getHim(  ) {
			
			if ( this._complex == true ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "getHim() unsupported for gender " + this.name + "}" ) );
				return "";
			}
			return this.objective;
		}

	}

}