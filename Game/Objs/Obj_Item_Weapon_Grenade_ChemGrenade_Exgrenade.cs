// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_ChemGrenade_Exgrenade : Obj_Item_Weapon_Grenade_ChemGrenade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_containers = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Glass), typeof(Obj_Item_SlimeExtract) });
			this.origin_tech = "combat=4;materials=3;engineering=2";
			this.affected_area = 4;
			this.icon_state = "ex_grenade";
		}

		public Obj_Item_Weapon_Grenade_ChemGrenade_Exgrenade ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: chem_grenade.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic det = null;

			
			if ( a is Obj_Item_Device_AssemblyHolder && ( !( this.stage != 0 ) || this.stage == 1 ) && this.path != 2 ) {
				det = a;

				if ( Lang13.Bool( ((dynamic)det.a_right.type).IsInstanceOfType( det.a_left ) ) || !GlobalFuncs.isigniter( det.a_left ) && !GlobalFuncs.isigniter( det.a_right ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'> Assembly must contain one igniter.</span>" );
					return null;
				}

				if ( !Lang13.Bool( det.secured ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'> Assembly must be secured with screwdriver.</span>" );
					return null;
				}
				this.path = 1;
				GlobalFuncs.to_chat( b, "<span class='notice'>You insert " + a + " into the grenade.</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 25, -3 );
				((Mob)b).remove_from_mob( det );
				det.loc = this;
				this.detonator = det;
				this.icon_state = Lang13.Initial( this, "icon_state" ) + "_ass";
				this.name = "unsecured EX grenade with " + this.beakers.len + " containers" + ( Lang13.Bool( this.detonator ) ? " and detonator" : "" );
				this.stage = 1;
			} else if ( a is Obj_Item_Weapon_Screwdriver && this.path != 2 ) {
				
				if ( this.stage == 1 ) {
					this.path = 1;

					if ( this.beakers.len != 0 ) {
						GlobalFuncs.to_chat( b, "<span class='notice'>You lock the assembly.</span>" );
						this.name = "EX Grenade";
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>You lock the empty assembly.</span>" );
						this.name = "fake grenade";
					}
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 25, -3 );
					this.icon_state = Lang13.Initial( this, "icon_state" ) + "_locked";
					this.stage = 2;
				} else if ( this.stage == 2 ) {
					
					if ( this.active && Rand13.PercentChance( 95 ) ) {
						GlobalFuncs.to_chat( b, "<span class='attack'>You trigger the assembly!</span>" );
						this.prime();
						return null;
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>You unlock the assembly.</span>" );
						GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 25, -3 );
						this.name = "unsecured EX grenade with " + this.beakers.len + " containers" + ( Lang13.Bool( this.detonator ) ? " and detonator" : "" );
						this.icon_state = Lang13.Initial( this, "icon_state" ) + ( Lang13.Bool( this.detonator ) ? "_ass" : "" );
						this.stage = 1;
						this.active = false;
					}
				}
			} else if ( GlobalFuncs.is_type_in_list( a, this.allowed_containers ) && ( !( this.stage != 0 ) || this.stage == 1 ) && this.path != 2 ) {
				this.path = 1;

				if ( this.beakers.len == 3 ) {
					GlobalFuncs.to_chat( b, "<span class='warning'> The grenade can not hold more containers.</span>" );
					return null;
				} else if ( a is Obj_Item_SlimeExtract ) {
					
					if ( ( this.inserted_cores ?1:0) > 1 ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>You cannot fit more than two slime cores in this grenade.</span>" );
					} else if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You add " ).the( a ).item().str( " to the assembly.</span>" ).ToString() );
						this.beakers.Add( a );
						this.stage = 1;
						this.name = "unsecured grenade with " + this.beakers.len + " containers" + ( Lang13.Bool( this.detonator ) ? " and detonator" : "" );
					}
				} else if ( Lang13.Bool( a.reagents.total_volume ) ) {
					
					if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
						GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You add " ).the( a ).item().str( " to the assembly.</span>" ).ToString() );
						this.beakers.Add( a );
						this.stage = 1;
						this.name = "unsecured EX grenade with " + this.beakers.len + " containers" + ( Lang13.Bool( this.detonator ) ? " and detonator" : "" );
					}
				} else {
					GlobalFuncs.to_chat( b, new Txt( "<span class='warning'> " ).the( a ).item().str( " is empty.</span>" ).ToString() );
				}
			}
			return null;
		}

	}

}