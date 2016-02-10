// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_Spawnergrenade : Obj_Item_Weapon_Grenade {

		public bool banglet = false;
		public Type spawner_type = null;
		public int? deliveryamt = 1;
		public dynamic owner = null;
		public string mob_faction = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=3;magnets=4";
			this.icon_state = "delivery";
		}

		public Obj_Item_Weapon_Grenade_Spawnergrenade ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: spawnergrenade.dm
		public virtual void postPrime( ByTable spawned_atoms = null ) {
			return;
		}

		// Function from file: spawnergrenade.dm
		public virtual void handle_faction( dynamic spawned = null, dynamic L = null ) {
			return;
		}

		// Function from file: spawnergrenade.dm
		public override void prime( dynamic L = null ) {
			dynamic T = null;
			Mob_Living_Carbon_Human M = null;
			ByTable spawned_atoms = null;
			int? i = null;
			dynamic x = null;
			int? j = null;

			
			if ( this.spawner_type != null && Lang13.Bool( this.deliveryamt ) ) {
				T = GlobalFuncs.get_turf( this );
				GlobalFuncs.playsound( T, "sound/effects/phasein.ogg", 100, 1 );

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, T ), typeof(Mob_Living_Carbon_Human) )) {
					M = _a;
					

					if ( M.eyecheck() <= 0 ) {
						Icon13.Flick( "e_flash", M.flash );
					}
				}
				spawned_atoms = new ByTable();
				i = null;
				i = 1;

				while (( i ??0) <= ( this.deliveryamt ??0)) {
					x = Lang13.Call( this.spawner_type );
					spawned_atoms.Add( x );
					x.loc = T;

					if ( Rand13.PercentChance( 50 ) ) {
						j = null;
						j = 1;

						while (( j ??0) <= Rand13.Int( 1, 3 )) {
							Map13.Step( x, Convert.ToInt32( Rand13.Pick(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST }) ) );
							j++;
						}
					}

					if ( Lang13.Bool( L ) && L is Mob_Living ) {
						this.handle_faction( x, L );
					}
					i++;
				}
				this.postPrime( spawned_atoms );
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}