// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Firstaid_Fire : Obj_Item_Weapon_Storage_Firstaid {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "firstaid-ointment";
			this.icon_state = "ointment";
		}

		// Function from file: firstaid.dm
		public Obj_Item_Weapon_Storage_Firstaid_Fire ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.empty ) {
				return;
			}
			this.icon_state = Rand13.Pick(new object [] { "ointment", "firefirstaid" });
			new Obj_Item_Device_Healthanalyzer( this );
			new Obj_Item_Weapon_ReagentContainers_Hypospray_Autoinjector( this );
			new Obj_Item_Stack_Medical_Ointment( this );
			new Obj_Item_Stack_Medical_Ointment( this );
			new Obj_Item_Weapon_ReagentContainers_Pill_Kelotane( this );
			new Obj_Item_Weapon_ReagentContainers_Pill_Kelotane( this );
			new Obj_Item_Weapon_ReagentContainers_Pill_Kelotane( this );
			return;
		}

	}

}