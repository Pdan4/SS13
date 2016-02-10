// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Wallmed1 : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_ads = "Go save some lives!;The best stuff for your medbay.;Only the finest tools.;Natural chemicals!;This stuff saves lives.;Don't you want some?";
			this.icon_deny = "wallmed-deny";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Stack_Medical_BruisePack), 2 )
				.Set( typeof(Obj_Item_Stack_Medical_Ointment), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Syringe_Inaprovaline), 4 )
				.Set( typeof(Obj_Item_Device_Healthanalyzer), 1 )
			;
			this.contraband = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Syringe_Antitoxin), 4 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Syringe_Antiviral), 4 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Pill_Tox), 1 )
			;
			this.pack = typeof(Obj_Structure_Vendomatpack_Medical);
			this.component_parts = 0;
			this.icon_state = "wallmed";
		}

		// Function from file: vending.dm
		public Obj_Machinery_Vending_Wallmed1 ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = 0;
			return;
		}

		// Function from file: vending.dm
		public override int crowbarDestroy( dynamic user = null ) {
			Obj I = null;

			((Ent_Static)user).visible_message( "" + user + " begins to pry out the NanoMed from the wall.", "You begin to pry out the NanoMed from the wall..." );

			if ( GlobalFuncs.do_after( user, this, 40 ) ) {
				((Ent_Static)user).visible_message( "" + user + " detaches the NanoMed from the wall.", "You detach the NanoMed from the wall." );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Crowbar.ogg", 50, 1 );
				new Obj_Item_Mounted_Frame_Wallmed( this.loc );

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
					I = _a;
					
					GlobalFuncs.qdel( I );
				}
				new Obj_Item_Weapon_Circuitboard_Vendomat( this.loc );
				new Obj_Item_Stack_CableCoil( this.loc, 5 );
				return 1;
			}
			return -1;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}