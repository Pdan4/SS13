// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Mineral_StackingUnitConsole : Obj_Machinery_Mineral {

		public dynamic machine = null;
		public int machinedir = 6;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/machines/mining_machines.dmi";
			this.icon_state = "console";
		}

		// Function from file: machine_stacking.dm
		public Obj_Machinery_Mineral_StackingUnitConsole ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 7, (Task13.Closure)(() => {
				this.machine = Lang13.FindIn( typeof(Obj_Machinery_Mineral_StackingMachine), Map13.GetStep( this, this.machinedir ) );

				if ( Lang13.Bool( this.machine ) ) {
					this.machine.CONSOLE = this;
				} else {
					GlobalFuncs.qdel( this );
				}
				return;
			}));
			return;
		}

		// Function from file: machine_stacking.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Base_Data inp = null;
			dynamic _out = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["release"] ) ) {
				
				if ( !Lang13.Bool( this.machine.stack_list.Contains( Lang13.FindClass( href_list["release"] ) ) ) ) {
					return null;
				}
				inp = this.machine.stack_list[Lang13.FindClass( href_list["release"] )];
				_out = Lang13.Call( inp.type );
				_out.amount = ((dynamic)inp).amount;
				((dynamic)inp).amount = 0;
				((Obj_Machinery_Mineral)this.machine).unload_mineral( _out );
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: machine_stacking.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			Base_Data s = null;
			dynamic dat = null;
			dynamic O = null;

			dat += "<b>Stacking unit console</b><br><br>";

			foreach (dynamic _a in Lang13.Enumerate( this.machine.stack_list )) {
				O = _a;
				
				s = this.machine.stack_list[O];

				if ( Convert.ToDouble( ((dynamic)s).amount ) > 0 ) {
					dat += new Txt().item( GlobalFuncs.capitalize( ((dynamic)s).name ) ).str( ": " ).item( ((dynamic)s).amount ).str( " <A href='?src=" ).Ref( this ).str( ";release=" ).item( s.type ).str( "'>Release</A><br>" ).ToString();
				}
			}
			dat += "<br>Stacking: " + this.machine.stack_amt + "<br><br>";
			Interface13.Browse( a, "" + dat, "window=console_stacking_machine" );
			return null;
		}

	}

}