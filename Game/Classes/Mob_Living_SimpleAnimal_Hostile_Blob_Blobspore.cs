// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore : Mob_Living_SimpleAnimal_Hostile_Blob {

		public Obj_Effect_Blob_Factory factory = null;
		public ByTable human_overlays = new ByTable();
		public bool is_zombie = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "blobpod";
			this.health = 40;
			this.maxHealth = 40;
			this.melee_damage_lower = 2;
			this.melee_damage_upper = 4;
			this.attacktext = "hits";
			this.attack_sound = "sound/weapons/genhit1.ogg";
			this.speak_emote = new ByTable(new object [] { "pulses" });
			this.gold_core_spawnable = 1;
			this.icon_state = "blobpod";
		}

		// Function from file: blob_mobs.dm
		public Mob_Living_SimpleAnimal_Hostile_Blob_Blobspore ( dynamic loc = null, Obj_Effect_Blob_Factory linked_node = null ) : base( (object)(loc) ) {
			
			if ( linked_node is Obj_Effect_Blob_Factory ) {
				this.factory = linked_node;
				this.factory.spores.Add( this );
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: blob_mobs.dm
		public override void update_icons(  ) {
			Image I = null;

			base.update_icons();

			if ( this.is_zombie ) {
				this.overlays.Cut();
				this.overlays = this.human_overlays;
				I = new Image( "icons/mob/blob.dmi", null, "blob_head" );
				I.color = this.color;
				this.color = Lang13.Initial( this, "color" );
				this.overlays.Add( I );
			}
			return;
		}

		// Function from file: blob_mobs.dm
		public override dynamic Destroy(  ) {
			dynamic M = null;

			
			if ( this.factory != null ) {
				this.factory.spores.Remove( this );
			}
			this.factory = null;

			if ( this.contents != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.contents )) {
					M = _a;
					
					M.loc = this.loc;
				}
			}
			return base.Destroy();
		}

		// Function from file: blob_mobs.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			EffectSystem_SmokeSpread_Chem S = null;
			dynamic location = null;

			base.death( true, toast );
			S = new EffectSystem_SmokeSpread_Chem();
			location = GlobalFuncs.get_turf( this );
			this.create_reagents( 10 );

			if ( this.overmind != null && Lang13.Bool( this.overmind.blob_reagent_datum ) ) {
				this.reagents.add_reagent( this.overmind.blob_reagent_datum.id, 10 );
			} else {
				this.reagents.add_reagent( "spore", 10 );
			}
			S.attach( location );
			S.set_up( this.reagents, 0, location );
			S.start();
			this.ghostize();
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: blob_mobs.dm
		public void Zombify( Mob_Living_Carbon_Human H = null ) {
			dynamic A = null;

			this.is_zombie = true;

			if ( Lang13.Bool( H.wear_suit ) ) {
				A = H.wear_suit;

				if ( Lang13.Bool( A.armor ) && Lang13.Bool( A.armor["melee"] ) ) {
					this.maxHealth += A.armor["melee"];
				}
			}
			this.maxHealth += 40;
			this.health = this.maxHealth;
			this.name = "blob zombie";
			this.desc = "A shambling corpse animated by the blob.";
			this.melee_damage_lower += 8;
			this.melee_damage_upper += 11;
			this.icon = H.icon;
			this.speak_emote = new ByTable(new object [] { "groans" });
			this.icon_state = "zombie_s";
			H.hair_style = null;
			H.update_hair();
			this.human_overlays = H.overlays;
			this.update_icons();
			H.loc = this;
			this.loc.visible_message( "<span class='warning'>The corpse of " + H.name + " suddenly rises!</span>" );
			return;
		}

		// Function from file: blob_mobs.dm
		public override bool Life(  ) {
			Mob_Living_Carbon_Human H = null;

			
			if ( !this.is_zombie && this.loc is Tile ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( 1, this ), typeof(Mob_Living_Carbon_Human) )) {
					H = _a;
					

					if ( H.stat == 2 ) {
						this.Zombify( H );
						break;
					}
				}
			}

			if ( this.factory != null && this.z != this.factory.z ) {
				this.death();
			}
			base.Life();
			return false;
		}

		// Function from file: blob_mobs.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( mover is Obj_Effect_Blob ) {
				return true;
			}
			return base.CanPass( (object)(mover), (object)(target), height, air_group );
		}

		// Function from file: blob_mobs.dm
		public override bool fire_act( bool? air = null, dynamic exposed_temperature = null, double? exposed_volume = null ) {
			base.fire_act( air, (object)(exposed_temperature), exposed_volume );
			this.adjustBruteLoss( Num13.MaxInt( 1, Num13.MinInt( Convert.ToInt32( exposed_temperature * 0.01 ), 5 ) ) );
			return false;
		}

	}

}