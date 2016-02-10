// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Borghypo : Obj_Item_Weapon_ReagentContainers {

		public int mode = 1;
		public int charge_cost = 50;
		public int charge_tick = 0;
		public int recharge_time = 5;
		public ByTable reagent_list = new ByTable();
		public ByTable reagent_ids = new ByTable(new object [] { "tricordrazine", "inaprovaline", "spaceacillin" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hypo";
			this.possible_transfer_amounts = null;
			this.icon = "icons/obj/syringe.dmi";
			this.icon_state = "borghypo";
		}

		// Function from file: borghydro.dm
		public Obj_Item_Weapon_ReagentContainers_Borghypo ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic reagent = null;
			Reagents reagents = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalFuncs.qdel( this.reagents );
			this.reagents = null;

			foreach (dynamic _a in Lang13.Enumerate( this.reagent_ids )) {
				reagent = _a;
				
				reagents = new Reagents( this.volume );
				reagents.my_atom = this;
				reagents.add_reagent( reagent, this.volume );
				this.reagent_list.Add( reagents );
			}
			GlobalVars.processing_objects.Add( this );
			return;
		}

		// Function from file: borghydro.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			bool contents_count = false;
			Reagents reagents = null;

			base.examine( (object)(user), size );
			contents_count = false;

			foreach (dynamic _a in Lang13.Enumerate( this.reagent_list, typeof(Reagents) )) {
				reagents = _a;
				
				GlobalFuncs.to_chat( user, "<span class='info'>It's currently has " + reagents.total_volume + " units of " + this.reagent_ids[++contents_count] + " stored.</span>" );
			}
			GlobalFuncs.to_chat( user, "<span class='info'>It's currently producing '" + this.reagent_ids[this.mode] + "'.</span>" );
			return null;
		}

		// Function from file: borghydro.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/pop.ogg", 50, 0 );

			if ( ++this.mode > this.reagent_list.len ) {
				this.mode = 1;
			}
			this.charge_tick = 0;
			GlobalFuncs.to_chat( user, "<span class='notice'>Synthesizer is now producing '" + this.reagent_ids[this.mode] + "'.</span>" );
			return null;
		}

		// Function from file: borghydro.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			Reagents reagents = null;
			dynamic transferred = null;

			reagents = this.reagent_list[this.mode];

			if ( !Lang13.Bool( reagents.total_volume ) ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>The injector is empty.</span>" );
				return null;
			}

			if ( !( M is Mob ) ) {
				return null;
			}
			GlobalFuncs.to_chat( user, "<span class='info'>You inject " + M + " with the injector.<span>" );
			GlobalFuncs.to_chat( M, "<span class='warning'>You feel a tiny prick!</span>" );
			reagents.reaction( M, GlobalVars.INGEST );

			if ( Lang13.Bool( M.reagents ) ) {
				transferred = reagents.trans_to( M, this.amount_per_transfer_from_this );
				GlobalFuncs.to_chat( user, "<span class='notice'>" + transferred + " units injected. " + reagents.total_volume + " units remaining.</span>" );
			}
			return null;
		}

		// Function from file: borghydro.dm
		public override dynamic process(  ) {
			Ent_Static robot = null;
			Reagents reagents = null;

			
			if ( ++this.charge_tick < this.recharge_time ) {
				return 0;
			}
			this.charge_tick = 0;

			if ( this.loc is Mob_Living_Silicon_Robot ) {
				robot = this.loc;

				if ( robot != null && Lang13.Bool( ((dynamic)robot).cell ) ) {
					reagents = this.reagent_list[this.mode];

					if ( ( reagents.total_volume ??0) < Convert.ToDouble( reagents.maximum_volume ) ) {
						((dynamic)robot).cell.use( this.charge_cost );
						reagents.add_reagent( this.reagent_ids[this.mode], 5 );
					}
				}
			}
			return 1;
		}

		// Function from file: borghydro.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Reagents reagents = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.reagent_list, typeof(Reagents) )) {
				reagents = _a;
				
				GlobalFuncs.qdel( reagents );
			}
			this.reagent_list = null;
			GlobalVars.processing_objects.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}