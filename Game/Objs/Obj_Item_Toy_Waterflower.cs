// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Waterflower : Obj_Item_Toy {

		public bool empty = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "sunflower";
			this.flags = 0;
			this.icon = "icons/obj/harvest.dmi";
			this.icon_state = "sunflower";
		}

		// Function from file: toys.dm
		public Obj_Item_Toy_Waterflower ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 10 );
			((Reagents)this.reagents).add_reagent( "water", 10 );
			return;
		}

		// Function from file: toys.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, "" + this.reagents.total_volume + " units of water left!" );
			return null;
		}

		// Function from file: toys.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			Obj_Effect_Decal D = null;
			int? i = null;
			Ent_Static T = null;

			
			if ( A is Obj_Item_Weapon_Storage_Backpack || A is Obj_Structure_Bed_Chair_Vehicle_Clowncart ) {
				return false;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Table), this.loc ) ) ) {
				return false;
			} else if ( A is Obj_Structure_ReagentDispensers_Watertank && Map13.GetDistance( this, A ) <= 1 ) {
				((Reagents)A.reagents).trans_to( this, 10 );
				GlobalFuncs.to_chat( user, "<span class = 'notice'>You refill your flower!</span>" );
				return false;
			} else if ( ( this.reagents.total_volume ??0) < 1 ) {
				this.empty = true;
				GlobalFuncs.to_chat( user, "<span class = 'notice'>Your flower has run dry!</span>" );
				return false;
			} else {
				this.empty = false;
				D = new Obj_Effect_Decal( GlobalFuncs.get_turf( this ) );
				D.name = "water";
				D.icon = "icons/obj/chemical.dmi";
				D.icon_state = "chempuff";
				D.create_reagents( 5 );
				((Reagents)this.reagents).trans_to( D, 1 );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/spray3.ogg", 50, 1, -6 );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					i = null;
					i = 0;

					while (( i ??0) < 1) {
						Map13.StepTowardsSimple( D, A );
						((Reagents)D.reagents).reaction( GlobalFuncs.get_turf( D ) );

						foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( D ), typeof(Ent_Static) )) {
							T = _a;
							
							((Reagents)D.reagents).reaction( T );

							if ( T is Mob && Lang13.Bool( ((dynamic)T).client ) ) {
								GlobalFuncs.to_chat( ((dynamic)T).client, "<span class = 'danger'>" + user + " has sprayed you with water!</span>" );
							}
						}
						Task13.Sleep( 4 );
						i++;
					}
					GlobalFuncs.qdel( D );
					D = null;
					return;
				}));
				return false;
			}
			return false;
		}

		// Function from file: toys.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			return null;
		}

	}

}