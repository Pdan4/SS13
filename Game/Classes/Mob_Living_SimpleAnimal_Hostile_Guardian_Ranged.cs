// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Guardian_Ranged : Mob_Living_SimpleAnimal_Hostile_Guardian {

		public ByTable snares = new ByTable();
		public bool? toggle = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.friendly = "quietly assesses";
			this.melee_damage_lower = 10;
			this.melee_damage_upper = 10;
			this.damage_transfer = 081;
			this.projectiletype = typeof(Obj_Item_Projectile_Guardian);
			this.ranged_cooldown_cap = 0;
			this.projectilesound = "sound/effects/hit_on_shattered_glass.ogg";
			this.ranged = true;
			this.range = 13;
			this.playstyle_string = "As a ranged type, you have only light damage resistance, but are capable of spraying shards of crystal at incredibly high speed. You can also deploy surveillance snares to monitor enemy movement. Finally, you can switch to scout mode, in which you can't attack, but can move without limit.";
			this.magic_fluff_string = "..And draw the Sentinel, an alien master of ranged combat.";
			this.tech_fluff_string = "Boot sequence complete. Ranged combat modules active. Holoparasite swarm online.";
		}

		public Mob_Living_SimpleAnimal_Hostile_Guardian_Ranged ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: guardian.dm
		public override void ToggleMode(  ) {
			
			if ( this.loc == this.summoner ) {
				
				if ( this.toggle == true ) {
					this.ranged = true;
					this.melee_damage_lower = 10;
					this.melee_damage_upper = 10;
					this.alpha = 255;
					this.range = 13;
					this.incorporeal_move = 0;
					this.WriteMsg( "<span class='danger'><B>You switch to combat mode.</span></B>" );
					this.toggle = GlobalVars.FALSE;
				} else {
					this.ranged = false;
					this.melee_damage_lower = 0;
					this.melee_damage_upper = 0;
					this.alpha = 60;
					this.range = 255;
					this.incorporeal_move = 1;
					this.WriteMsg( "<span class='danger'><B>You switch to scout mode.</span></B>" );
					this.toggle = GlobalVars.TRUE;
				}
			} else {
				this.WriteMsg( "<span class='danger'><B>You have to be recalled to toggle modes!</span></B>" );
			}
			return;
		}

		// Function from file: guardian.dm
		[Verb]
		[VerbInfo( name: "Remove Surveillance Trap", desc: "Disarm unwanted surveillance traps.", group: "Guardian" )]
		public void DisarmSnare(  ) {
			dynamic picked_snare = null;

			picked_snare = Interface13.Input( this, "Pick which trap to disarm", "Disarm Trap", null, this.snares, InputType.Null | InputType.Any );

			if ( Lang13.Bool( picked_snare ) ) {
				this.snares.Remove( picked_snare );
				GlobalFuncs.qdel( picked_snare );
				this.WriteMsg( "<span class='danger'><B>Snare disarmed.</span></B>" );
			}
			return;
		}

		// Function from file: guardian.dm
		[Verb]
		[VerbInfo( name: "Set Surveillance Trap", desc: "Set an invisible trap that will alert you when living creatures walk over it. Max of 5", group: "Guardian" )]
		public void Snare(  ) {
			dynamic snare_loc = null;
			Obj_Item_Effect_Snare S = null;

			
			if ( this.snares.len < 6 ) {
				snare_loc = GlobalFuncs.get_turf( this.loc );
				S = new Obj_Item_Effect_Snare( snare_loc );
				S.spawner = this;
				S.name = "" + GlobalFuncs.get_area( snare_loc ) + " trap (" + Rand13.Int( 1, 1000 ) + ")";
				this.snares.Or( S );
				this.WriteMsg( "<span class='danger'><B>Surveillance trap deployed!</span></B>" );
			} else {
				this.WriteMsg( "<span class='danger'><B>You have too many traps deployed. Delete some first.</span></B>" );
			}
			return;
		}

	}

}