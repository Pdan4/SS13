// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Chick : Mob_Living_SimpleAnimal {

		public int amount_grown = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "chick";
			this.icon_dead = "chick_dead";
			this.icon_gib = "chick_gib";
			this.speak = new ByTable(new object [] { "Cherp.", "Cherp?", "Chirrup.", "Cheep!" });
			this.speak_emote = new ByTable(new object [] { "cheeps" });
			this.emote_hear = new ByTable(new object [] { "cheeps." });
			this.emote_see = new ByTable(new object [] { "pecks at the ground.", "flaps its tiny wings." });
			this.speak_chance = 2;
			this.turns_per_move = 2;
			this.butcher_results = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab), 1 );
			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.response_harm = "kicks";
			this.attacktext = "kicks";
			this.health = 1;
			this.ventcrawler = 2;
			this.pass_flags = 21;
			this.mob_size = 0;
			this.gold_core_spawnable = 2;
			this.icon_state = "chick";
		}

		// Function from file: farm_animals.dm
		public Mob_Living_SimpleAnimal_Chick ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -6, 6 );
			this.pixel_y = Rand13.Int( 0, 10 );
			return;
		}

		// Function from file: farm_animals.dm
		public override bool Life(  ) {
			bool _default = false;

			_default = base.Life();

			if ( !_default ) {
				return _default;
			}

			if ( !( this.stat != 0 ) && !Lang13.Bool( this.ckey ) ) {
				this.amount_grown += Rand13.Int( 1, 2 );

				if ( this.amount_grown >= 100 ) {
					new Mob_Living_SimpleAnimal_Chicken( this.loc );
					GlobalFuncs.qdel( this );
				}
			}
			return _default;
		}

	}

}