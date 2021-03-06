// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Signal : Game_Data {

		public Obj source = null;
		public int transmission_method = 0;
		public ByTable data = new ByTable();
		public double encryption = 0;
		public dynamic frequency = 0;

		// Function from file: communications.dm
		public Signal (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.pointers.Add( new Txt().Ref( this ).ToString() );
			return;
		}

		// Function from file: communications.dm
		public void sanitize_data(  ) {
			dynamic d = null;
			string val = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.data )) {
				d = _a;
				
				val = this.data[d];

				if ( val is string ) {
					this.data[d] = String13.HtmlEncode( val );
				}
			}
			return;
		}

		// Function from file: communications.dm
		public string debug_print(  ) {
			string _default = null;

			dynamic i = null;
			dynamic L = null;
			dynamic t = null;

			
			if ( this.source != null ) {
				_default = "signal = {source = '" + this.source + "' (" + this.source.x + "," + this.source.y + "," + this.source.z + ")\n";
			} else {
				_default = "signal = {source = '" + this.source + "' ()\n";
			}

			foreach (dynamic _b in Lang13.Enumerate( this.data )) {
				i = _b;
				
				_default += "data[\"" + i + "\"] = \"" + this.data[i] + "\"\n";

				if ( this.data[i] is ByTable ) {
					L = this.data[i];

					foreach (dynamic _a in Lang13.Enumerate( L )) {
						t = _a;
						
						_default += "data[\"" + i + "\"] list has: " + t;
					}
				}
			}
			return _default;
		}

		// Function from file: communications.dm
		public void copy_from( Signal model = null ) {
			this.source = model.source;
			this.transmission_method = model.transmission_method;
			this.data = model.data;
			this.encryption = model.encryption;
			this.frequency = model.frequency;
			return;
		}

		// Function from file: communications.dm
		public override dynamic Destroy(  ) {
			GlobalVars.pointers.Remove( new Txt().Ref( this ).ToString() );
			return base.Destroy();
		}

	}

}