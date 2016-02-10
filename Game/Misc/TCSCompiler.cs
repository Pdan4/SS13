// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TCSCompiler : Game_Data {

		public NInterpreter_TCSInterpreter interpreter = null;
		public Obj_Machinery_Telecomms_Server Holder = null;
		public bool ready = true;

		// Function from file: Telecomms.dm
		public void Run( Game_Data signal = null ) {
			dynamic setname = null;

			
			if ( !this.ready ) {
				return;
			}

			if ( !( this.interpreter != null ) ) {
				return;
			}
			this.interpreter.container = this;
			this.interpreter.SetVar( "PI", 3.1415927410125732 );
			this.interpreter.SetVar( "E", 2.7182817459106445 );
			this.interpreter.SetVar( "SQURT2", 1.4142135381698608 );
			this.interpreter.SetVar( "FALSE", 0 );
			this.interpreter.SetVar( "false", 0 );
			this.interpreter.SetVar( "TRUE", 1 );
			this.interpreter.SetVar( "true", 1 );
			this.interpreter.SetVar( "NORTH", GlobalVars.NORTH );
			this.interpreter.SetVar( "SOUTH", GlobalVars.SOUTH );
			this.interpreter.SetVar( "EAST", GlobalVars.EAST );
			this.interpreter.SetVar( "WEST", GlobalVars.WEST );
			this.interpreter.SetVar( "$common", 1459 );
			this.interpreter.SetVar( "$science", 1351 );
			this.interpreter.SetVar( "$command", 1353 );
			this.interpreter.SetVar( "$medical", 1355 );
			this.interpreter.SetVar( "$engineering", 1357 );
			this.interpreter.SetVar( "$security", 1359 );
			this.interpreter.SetVar( "$supply", 1347 );
			this.interpreter.SetVar( "$content", ((dynamic)signal).data["message"] );
			this.interpreter.SetVar( "$freq", ((dynamic)signal).frequency );
			this.interpreter.SetVar( "$source", ((dynamic)signal).data["name"] );
			this.interpreter.SetVar( "$job", ((dynamic)signal).data["job"] );
			this.interpreter.SetVar( "$sign", signal );
			this.interpreter.SetVar( "$pass", !Lang13.Bool( ((dynamic)signal).data["reject"] ) );
			this.interpreter.SetProc( "broadcast", "tcombroadcast", signal, new ByTable(new object [] { "message", "freq", "source", "job" }) );
			this.interpreter.SetProc( "signal", "signaler", signal, new ByTable(new object [] { "freq", "code" }) );
			this.interpreter.SetProc( "mem", "mem", signal, new ByTable(new object [] { "address", "value" }) );
			this.interpreter.SetProc( "sleep", typeof(GlobalFuncs).GetMethod( "delay" ) );
			this.interpreter.SetProc( "replace", typeof(GlobalFuncs).GetMethod( "replacetext" ) );
			this.interpreter.SetProc( "find", typeof(GlobalFuncs).GetMethod( "smartfind" ) );
			this.interpreter.SetProc( "length", typeof(GlobalFuncs).GetMethod( "smartlength" ) );
			this.interpreter.SetProc( "vector", typeof(GlobalFuncs).GetMethod( "n_list" ) );
			this.interpreter.SetProc( "at", typeof(GlobalFuncs).GetMethod( "n_listpos" ) );
			this.interpreter.SetProc( "copy", typeof(GlobalFuncs).GetMethod( "n_listcopy" ) );
			this.interpreter.SetProc( "push_back", typeof(GlobalFuncs).GetMethod( "n_listadd" ) );
			this.interpreter.SetProc( "remove", typeof(GlobalFuncs).GetMethod( "n_listremove" ) );
			this.interpreter.SetProc( "cut", typeof(GlobalFuncs).GetMethod( "n_listcut" ) );
			this.interpreter.SetProc( "swap", typeof(GlobalFuncs).GetMethod( "n_listswap" ) );
			this.interpreter.SetProc( "insert", typeof(GlobalFuncs).GetMethod( "n_listinsert" ) );
			this.interpreter.SetProc( "pick", typeof(GlobalFuncs).GetMethod( "n_pick" ) );
			this.interpreter.SetProc( "prob", typeof(GlobalFuncs).GetMethod( "prob_chance" ) );
			this.interpreter.SetProc( "substr", typeof(GlobalFuncs).GetMethod( "docopytext" ) );
			this.interpreter.SetProc( "shuffle", typeof(GlobalFuncs).GetMethod( "shuffle" ) );
			this.interpreter.SetProc( "uniquevector", typeof(GlobalFuncs).GetMethod( "uniquelist" ) );
			this.interpreter.SetProc( "text2vector", typeof(GlobalFuncs).GetMethod( "text2list" ) );
			this.interpreter.SetProc( "text2vectorEx", typeof(GlobalFuncs).GetMethod( "text2listEx" ) );
			this.interpreter.SetProc( "vector2text", typeof(GlobalFuncs).GetMethod( "vg_list2text" ) );
			this.interpreter.SetProc( "lower", typeof(GlobalFuncs).GetMethod( "n_lower" ) );
			this.interpreter.SetProc( "upper", typeof(GlobalFuncs).GetMethod( "n_upper" ) );
			this.interpreter.SetProc( "explode", typeof(GlobalFuncs).GetMethod( "string_explode" ) );
			this.interpreter.SetProc( "repeat", typeof(GlobalFuncs).GetMethod( "n_repeat" ) );
			this.interpreter.SetProc( "reverse", typeof(GlobalFuncs).GetMethod( "reverse_text" ) );
			this.interpreter.SetProc( "tonum", typeof(GlobalFuncs).GetMethod( "n_str2num" ) );
			this.interpreter.SetProc( "capitalize", typeof(GlobalFuncs).GetMethod( "capitalize" ) );
			this.interpreter.SetProc( "replacetextEx", typeof(GlobalFuncs).GetMethod( "replacetextEx" ) );
			this.interpreter.SetProc( "tostring", typeof(GlobalFuncs).GetMethod( "n_num2str" ) );
			this.interpreter.SetProc( "sqrt", typeof(GlobalFuncs).GetMethod( "n_sqrt" ) );
			this.interpreter.SetProc( "abs", typeof(GlobalFuncs).GetMethod( "n_abs" ) );
			this.interpreter.SetProc( "floor", typeof(GlobalFuncs).GetMethod( "Floor" ) );
			this.interpreter.SetProc( "ceil", typeof(GlobalFuncs).GetMethod( "Ceiling" ) );
			this.interpreter.SetProc( "round", typeof(GlobalFuncs).GetMethod( "n_round" ) );
			this.interpreter.SetProc( "clamp", typeof(GlobalFuncs).GetMethod( "n_clamp" ) );
			this.interpreter.SetProc( "inrange", typeof(GlobalFuncs).GetMethod( "IsInRange" ) );
			this.interpreter.SetProc( "rand", typeof(GlobalFuncs).GetMethod( "rand_chance" ) );
			this.interpreter.SetProc( "arctan", typeof(GlobalFuncs).GetMethod( "Atan2" ) );
			this.interpreter.SetProc( "lcm", typeof(GlobalFuncs).GetMethod( "Lcm" ) );
			this.interpreter.SetProc( "gcd", typeof(GlobalFuncs).GetMethod( "Gcd" ) );
			this.interpreter.SetProc( "mean", typeof(GlobalFuncs).GetMethod( "Mean" ) );
			this.interpreter.SetProc( "root", typeof(GlobalFuncs).GetMethod( "Root" ) );
			this.interpreter.SetProc( "sin", typeof(GlobalFuncs).GetMethod( "n_sin" ) );
			this.interpreter.SetProc( "cos", typeof(GlobalFuncs).GetMethod( "n_cos" ) );
			this.interpreter.SetProc( "arcsin", typeof(GlobalFuncs).GetMethod( "n_asin" ) );
			this.interpreter.SetProc( "arccos", typeof(GlobalFuncs).GetMethod( "n_acos" ) );
			this.interpreter.SetProc( "tan", typeof(GlobalFuncs).GetMethod( "Tan" ) );
			this.interpreter.SetProc( "csc", typeof(GlobalFuncs).GetMethod( "Csc" ) );
			this.interpreter.SetProc( "cot", typeof(GlobalFuncs).GetMethod( "Cot" ) );
			this.interpreter.SetProc( "sec", typeof(GlobalFuncs).GetMethod( "Sec" ) );
			this.interpreter.SetProc( "todegrees", typeof(GlobalFuncs).GetMethod( "ToDegrees" ) );
			this.interpreter.SetProc( "toradians", typeof(GlobalFuncs).GetMethod( "ToRadians" ) );
			this.interpreter.SetProc( "lerp", typeof(GlobalFuncs).GetMethod( "mix" ) );
			this.interpreter.SetProc( "max", typeof(GlobalFuncs).GetMethod( "n_max" ) );
			this.interpreter.SetProc( "min", typeof(GlobalFuncs).GetMethod( "n_min" ) );
			this.interpreter.SetProc( "time", typeof(GlobalFuncs).GetMethod( "time" ) );
			this.interpreter.SetProc( "timestamp", typeof(GlobalFuncs).GetMethod( "timestamp" ) );
			this.interpreter.Run();
			((dynamic)signal).data["message"] = this.interpreter.GetCleanVar( "$content", ((dynamic)signal).data["message"] );
			((dynamic)signal).frequency = this.interpreter.GetCleanVar( "$freq", ((dynamic)signal).frequency );
			setname = this.interpreter.GetCleanVar( "$source", ((dynamic)signal).data["name"] );

			if ( ((dynamic)signal).data["name"] != setname ) {
				((dynamic)signal).data["realname"] = setname;
			}
			((dynamic)signal).data["name"] = setname;
			((dynamic)signal).data["job"] = this.interpreter.GetCleanVar( "$job", ((dynamic)signal).data["job"] );
			((dynamic)signal).data["reject"] = !Lang13.Bool( this.interpreter.GetCleanVar( "$pass" ) );

			if ( ((dynamic)signal).data["message"] == "" || !Lang13.Bool( ((dynamic)signal).data["message"] ) ) {
				((dynamic)signal).data["reject"] = 1;
			}
			return;
		}

		// Function from file: Telecomms.dm
		public ByTable Compile( string code = null ) {
			NScriptOptions_NSOptions options = null;
			NScanner_NSScanner scanner = null;
			ByTable tokens = null;
			NParser_NSParser parser = null;
			Node_BlockDefinition_GlobalBlock program = null;
			ByTable returnerrors = null;

			options = new NScriptOptions_NSOptions();
			scanner = new NScanner_NSScanner( code, options );
			tokens = scanner.Scan();
			parser = new NParser_NSParser( tokens, options );
			program = parser.Parse();
			returnerrors = new ByTable();
			returnerrors.Add( scanner.errors );
			returnerrors.Add( parser.errors );

			if ( returnerrors.len != 0 ) {
				return returnerrors;
			}
			this.interpreter = new NInterpreter_TCSInterpreter( program );
			this.interpreter.persist = true;
			this.interpreter.Compiler = this;
			return returnerrors;
		}

		// Function from file: Telecomms.dm
		public void GC(  ) {
			this.Holder = null;

			if ( this.interpreter != null ) {
				this.interpreter.GC();
			}
			return;
		}

	}

}