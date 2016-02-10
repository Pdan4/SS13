// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_FarmbotArmAssembly : Obj_Item_Weapon {

		public int build_step = 0;
		public dynamic created_name = "Farmbot";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/aibots.dmi";
			this.icon_state = "water_arm";
		}

		// Function from file: farmbot.dm
		public Obj_Item_Weapon_FarmbotArmAssembly ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic tank = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 4, (Task13.Closure)(() => {
				tank = Lang13.FindIn( typeof(Obj_Structure_ReagentDispensers_Watertank), this.contents );

				if ( !Lang13.Bool( tank ) ) {
					new Obj_Structure_ReagentDispensers_Watertank( this );
				}
				return;
			}));
			return;
		}

		// Function from file: farmbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Machinery_Bot_Farmbot S = null;
			Obj_Structure_ReagentDispensers_Watertank wTank = null;
			dynamic t = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Device_Analyzer_PlantAnalyzer && !( this.build_step != 0 ) ) {
				this.build_step++;
				GlobalFuncs.to_chat( b, "You add the plant analyzer to " + this + "!" );
				this.name = "farmbot assembly";
				GlobalFuncs.qdel( a );
				a = null;
			} else if ( a is Obj_Item_Weapon_ReagentContainers_Glass_Bucket && this.build_step == 1 ) {
				this.build_step++;
				GlobalFuncs.to_chat( b, "You add a bucket to " + this + "!" );
				this.name = "farmbot assembly with bucket";
				GlobalFuncs.qdel( a );
				a = null;
			} else if ( a is Obj_Item_Weapon_Minihoe && this.build_step == 2 ) {
				this.build_step++;
				GlobalFuncs.to_chat( b, "You add a minihoe to " + this + "!" );
				this.name = "farmbot assembly with bucket and minihoe";
				GlobalFuncs.qdel( a );
				a = null;
			} else if ( GlobalFuncs.isprox( a ) && this.build_step == 3 ) {
				this.build_step++;
				GlobalFuncs.to_chat( b, "You complete the Farmbot! Beep boop." );
				S = new Obj_Machinery_Bot_Farmbot();

				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Structure_ReagentDispensers_Watertank) )) {
					wTank = _a;
					
					wTank.loc = S;
					S.tank = wTank;
				}
				S.loc = GlobalFuncs.get_turf( this );
				S.name = this.created_name;
				GlobalFuncs.qdel( a );
				a = null;
				GlobalFuncs.qdel( this );
			} else if ( a is Obj_Item_Weapon_Pen ) {
				t = Interface13.Input( b, "Enter new robot name", this.name, this.created_name, null, InputType.Str );
				t = String13.SubStr( GlobalFuncs.sanitize( t ), 1, 26 );

				if ( !Lang13.Bool( t ) ) {
					return null;
				}

				if ( !GlobalFuncs.in_range( this, Task13.User ) && this.loc != Task13.User ) {
					return null;
				}
				this.created_name = t;
			}
			return null;
		}

	}

}