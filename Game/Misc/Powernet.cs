// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Powernet : Game_Data {

		public ByTable cables = new ByTable();
		public ByTable nodes = new ByTable();
		public ByTable components = new ByTable();
		public double load = 0;
		public double newavail = 0;
		public double avail = 0;
		public double viewload = 0;
		public bool number = false;
		public double netexcess = 0;

		// Function from file: powernet.dm
		public Powernet (  ) {
			GlobalVars.powernets.Or( this );
			return;
		}

		// Function from file: powernet.dm
		public void set_to_build(  ) {
			Obj_Structure_Cable C = null;
			Obj_Machinery_Power P = null;
			PowerConnection C2 = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.cables, typeof(Obj_Structure_Cable) )) {
				C = _a;
				
				C.build_status = true;
				C.oldload = this.load;
				C.oldavail = this.avail;
				C.oldnewavail = this.newavail;
			}

			foreach (dynamic _b in Lang13.Enumerate( this.nodes, typeof(Obj_Machinery_Power) )) {
				P = _b;
				
				P.build_status = true;
			}

			foreach (dynamic _c in Lang13.Enumerate( this.components, typeof(PowerConnection) )) {
				C2 = _c;
				
				C2.build_status = true;
			}
			GlobalFuncs.returnToPool( this );
			return;
		}

		// Function from file: powernet.dm
		public int get_electrocute_damage(  ) {
			return Num13.Floor( Math.Pow( this.avail, 0.3333333432674408 ) * ( Rand13.Int( 100, 125 ) / 100 ) );
		}

		// Function from file: powernet.dm
		public void reset(  ) {
			Obj_Machinery_Power_Battery B = null;
			Obj_Machinery_Power_BatteryPort BP = null;
			PowerConnection C = null;

			this.netexcess = this.avail - this.load;

			if ( this.netexcess > 100 && this.nodes != null && this.nodes.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.nodes, typeof(Obj_Machinery_Power_Battery) )) {
					B = _a;
					
					B.restore();
				}

				foreach (dynamic _b in Lang13.Enumerate( this.nodes, typeof(Obj_Machinery_Power_BatteryPort) )) {
					BP = _b;
					

					if ( BP.connected != null ) {
						BP.connected.restore();
					}
				}
			}

			if ( this.netexcess > 100 && this.components != null && this.components.len != 0 ) {
				
				foreach (dynamic _c in Lang13.Enumerate( this.components, typeof(PowerConnection) )) {
					C = _c;
					
					C.excess( this.netexcess );
				}
			}
			this.viewload = this.viewload * 0.8 + this.load * 0.2;
			this.viewload = Num13.Floor( this.viewload );
			this.load = 0;
			this.avail = this.newavail;
			this.newavail = 0;
			return;
		}

		// Function from file: powernet.dm
		public void add_component( PowerConnection C = null ) {
			
			if ( C.powernet != null ) {
				
				if ( C.powernet == this ) {
					return;
				} else {
					C.disconnect();
				}
			}
			C.build_status = false;
			C.powernet = this;
			this.components.Add( C );
			return;
		}

		// Function from file: powernet.dm
		public void add_machine( Obj_Machinery_Power M = null ) {
			
			if ( Lang13.Bool( M.powernet ) ) {
				
				if ( M.powernet == this ) {
					return;
				} else {
					M.disconnect_from_network();
				}
			}
			M.build_status = false;
			M.powernet = this;
			this.nodes.Add( M );
			return;
		}

		// Function from file: powernet.dm
		public void add_cable( dynamic C = null ) {
			
			if ( Lang13.Bool( C.powernet ) ) {
				
				if ( C.powernet == this ) {
					return;
				} else {
					((Powernet)C.powernet).remove_cable( C );
				}
			}
			C.build_status = 0;
			C.powernet = this;
			this.cables.Add( C );
			return;
		}

		// Function from file: powernet.dm
		public void remove_component( PowerConnection C = null ) {
			this.components.Remove( C );
			C.powernet = null;

			if ( this.is_empty() ) {
				GlobalFuncs.returnToPool( this );
			}
			return;
		}

		// Function from file: powernet.dm
		public void remove_machine( Obj_Machinery_Power M = null ) {
			this.nodes.Remove( M );
			M.powernet = null;

			if ( this.is_empty() ) {
				GlobalFuncs.returnToPool( this );
			}
			return;
		}

		// Function from file: powernet.dm
		public void remove_cable( dynamic C = null ) {
			this.cables.Remove( C );
			C.powernet = null;

			if ( this.is_empty() ) {
				GlobalFuncs.returnToPool( this );
			}
			return;
		}

		// Function from file: powernet.dm
		public bool is_empty(  ) {
			return !( this.cables.len != 0 ) && !( this.nodes.len != 0 ) && !( this.components.len != 0 );
		}

		// Function from file: powernet.dm
		public override dynamic resetVariables( string args = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { args } ).Extend(_);

			base.resetVariables( "cables", "nodes" );
			this.cables = new ByTable();
			this.nodes = new ByTable();
			this.components = new ByTable();
			return null;
		}

		// Function from file: powernet.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj_Structure_Cable C = null;
			Obj_Machinery_Power P = null;
			PowerConnection C2 = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.cables, typeof(Obj_Structure_Cable) )) {
				C = _a;
				
				C.powernet = null;
			}

			foreach (dynamic _b in Lang13.Enumerate( this.nodes, typeof(Obj_Machinery_Power) )) {
				P = _b;
				
				P.powernet = null;
			}

			foreach (dynamic _c in Lang13.Enumerate( this.components, typeof(PowerConnection) )) {
				C2 = _c;
				
				C2.powernet = null;
			}
			this.cables = null;
			this.nodes = null;
			this.components = null;
			return null;
		}

		// Function from file: powernet.dm
		public override void Del(  ) {
			GlobalVars.powernets.Remove( this );
			base.Del();
			return;
		}

	}

}