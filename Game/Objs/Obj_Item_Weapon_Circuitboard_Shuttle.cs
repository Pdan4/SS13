// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Shuttle : Obj_Item_Weapon_Circuitboard {

		public dynamic shuttleId = null;
		public string possible_destinations = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Computer_Shuttle);
		}

		public Obj_Item_Weapon_Circuitboard_Shuttle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: buildandrepair.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			int chosen_id = 0;

			
			if ( A is Obj_Item_Device_Multitool ) {
				chosen_id = Num13.Floor( Convert.ToDouble( Interface13.Input( Task13.User, "Choose an ID number (-1 for reset):", "Input an Integer", null, null, InputType.Num | InputType.Null ) ) );

				if ( chosen_id >= 0 ) {
					this.shuttleId = chosen_id;
				} else {
					this.shuttleId = Lang13.Initial( this, "shuttleId" );
				}
			}
			return null;
		}

	}

}