// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Mimic_Copy_Ranged : Mob_Living_SimpleAnimal_Hostile_Mimic_Copy {

		public Ent_Static TrueGun = null;
		public Ent_Static Zapstick = null;
		public Ent_Static Pewgun = null;
		public Ent_Static Zapgun = null;

		public Mob_Living_SimpleAnimal_Hostile_Mimic_Copy_Ranged ( dynamic loc = null, Ent_Static copy = null, dynamic creator = null, bool? destroy_original = null ) : base( (object)(loc), copy, (object)(creator), destroy_original ) {
			
		}

		// Function from file: mimic.dm
		public override void OpenFire( dynamic A = null ) {
			Obj_Item_AmmoCasing_Energy shot = null;

			
			if ( this.Zapgun != null ) {
				
				if ( Lang13.Bool( ((dynamic)this.Zapgun).power_supply ) ) {
					shot = ((dynamic)this.Zapgun).ammo_type[((dynamic)this.Zapgun).select];

					if ( Convert.ToDouble( ((dynamic)this.Zapgun).power_supply.charge ) >= ( shot.e_cost ??0) ) {
						((dynamic)this.Zapgun).power_supply.use( shot.e_cost );
						((dynamic)this.Zapgun).update_icon();
						base.OpenFire( (object)(A) );
					}
				}
			} else if ( this.Zapstick != null ) {
				
				if ( Lang13.Bool( ((dynamic)this.Zapstick).charges ) ) {
					((dynamic)this.Zapstick).charges--;
					((dynamic)this.Zapstick).update_icon();
					base.OpenFire( (object)(A) );
				}
			} else if ( this.Pewgun != null ) {
				
				if ( Lang13.Bool( ((dynamic)this.Pewgun).chambered ) ) {
					
					if ( Lang13.Bool( ((dynamic)this.Pewgun).chambered.BB ) ) {
						GlobalFuncs.qdel( ((dynamic)this.Pewgun).chambered.BB );
						((dynamic)this.Pewgun).chambered.BB = null;
						((dynamic)this.Pewgun).chambered.update_icon();
						base.OpenFire( (object)(A) );
					} else {
						this.visible_message( "<span class='danger'>The <b>" + this + "</b> clears a jam!</span>" );
					}
					((dynamic)this.Pewgun).chambered.loc = this.loc;
					((dynamic)this.Pewgun).chambered = null;

					if ( Lang13.Bool( ((dynamic)this.Pewgun).magazine ) && ((dynamic)this.Pewgun).magazine.stored_ammo.len != 0 ) {
						((dynamic)this.Pewgun).chambered = ((Obj_Item_AmmoBox)((dynamic)this.Pewgun).magazine).get_round( false );
						((dynamic)this.Pewgun).chambered.loc = this.Pewgun;
					}
					((dynamic)this.Pewgun).update_icon();
				} else if ( Lang13.Bool( ((dynamic)this.Pewgun).magazine ) && ((dynamic)this.Pewgun).magazine.stored_ammo.len != 0 ) {
					((dynamic)this.Pewgun).chambered = ((Obj_Item_AmmoBox)((dynamic)this.Pewgun).magazine).get_round( false );
					((dynamic)this.Pewgun).chambered.loc = this.Pewgun;
					this.visible_message( "<span class='danger'>The <b>" + this + "</b> cocks itself!</span>" );
				}
			} else {
				this.ranged = false;
				this.retreat_distance = 0;
				this.minimum_distance = 1;
				return;
			}
			this.icon_state = this.TrueGun.icon_state;
			this.icon_living = this.TrueGun.icon_state;
			return;
		}

		// Function from file: mimic.dm
		public override bool CopyObject( Ent_Static O = null, dynamic user = null, bool? destroy_original = null ) {
			destroy_original = destroy_original ?? false;

			Ent_Static G = null;
			dynamic M = null;
			dynamic M2 = null;
			dynamic selectfiresetting = null;
			dynamic E = null;

			
			if ( base.CopyObject( O, (object)(user), destroy_original ) ) {
				this.emote_see = new ByTable(new object [] { "aims menacingly" });
				this.environment_smash = 0;
				this.ranged = true;
				this.retreat_distance = 1;
				this.minimum_distance = 6;
				G = O;
				this.melee_damage_upper = ((dynamic)G).force;
				this.melee_damage_lower = ((dynamic)G).force - Num13.MaxInt( 0, Convert.ToInt32( ((dynamic)G).force / 2 ) );
				this.move_to_delay = Convert.ToInt32( ((dynamic)G).w_class * 2 + 1 );
				this.projectilesound = ((dynamic)G).fire_sound;
				this.TrueGun = G;

				if ( G is Obj_Item_Weapon_Gun_Magic ) {
					this.Zapstick = G;
					M = ((dynamic)this.Zapstick).ammo_type;
					this.projectiletype = Lang13.Initial( M, "projectile_type" );
				}

				if ( G is Obj_Item_Weapon_Gun_Projectile ) {
					this.Pewgun = G;
					M2 = ((dynamic)this.Pewgun).mag_type;
					this.casingtype = Lang13.Initial( M2, "ammo_type" );
				}

				if ( G is Obj_Item_Weapon_Gun_Energy ) {
					this.Zapgun = G;
					selectfiresetting = ((dynamic)this.Zapgun).select;
					E = ((dynamic)this.Zapgun).ammo_type[selectfiresetting];
					this.projectiletype = Lang13.Initial( E, "projectile_type" );
				}
			}
			return false;
		}

	}

}