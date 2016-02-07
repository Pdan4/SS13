// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Construct : Mob_Living_SimpleAnimal_Hostile {

		public ByTable construct_spells = new ByTable();
		public string playstyle_string = "<b>You are a generic construct! Your job is to not exist, and you should probably adminhelp this.</b>";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "Construct";
			this.speak_emote = new ByTable(new object [] { "hisses" });
			this.response_help = "thinks better of touching";
			this.response_disarm = "flails at";
			this.response_harm = "punches";
			this.speak_chance = 1;
			this.speed = 0;
			this.a_intent = "harm";
			this.stop_automated_movement = true;
			this.attack_sound = "sound/weapons/punch1.ogg";
			this.damage_coeff = new ByTable().Set( "brute", 1 ).Set( "fire", 1 ).Set( "tox", 0 ).Set( "clone", 0 ).Set( "stamina", 0 ).Set( "oxy", 0 );
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.maxbodytemp = Double.PositiveInfinity;
			this.healable = false;
			this.faction = new ByTable(new object [] { "cult" });
			this.flying = true;
			this.pressure_resistance = 200;
			this.unique_name = true;
			this.AIStatus = 3;
			this.icon = "icons/mob/mob.dmi";
			this.see_in_dark = 7;
		}

		// Function from file: constructs.dm
		public Mob_Living_SimpleAnimal_Hostile_Construct ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic spell = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.Enumerate( this.construct_spells )) {
				spell = _a;
				
				this.AddSpell( Lang13.Call( spell, null ) );
			}
			return;
		}

		// Function from file: constructs.dm
		public override void narsie_act(  ) {
			return;
		}

		// Function from file: constructs.dm
		public override int Process_Spacemove( dynamic movement_dir = null ) {
			movement_dir = movement_dir ?? 0;

			return 1;
		}

		// Function from file: constructs.dm
		public override bool attack_animal( Mob_Living user = null ) {
			
			if ( user is Mob_Living_SimpleAnimal_Hostile_Construct_Builder ) {
				
				if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
					this.adjustHealth( -5 );

					if ( this != user ) {
						this.Beam( user, "sendbeam", "icons/effects/effects.dmi", 4 );
						user.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " repairs some of " ).the( this ).str( "<b>" ).item().str( "'s</b> dents.</span>" ).ToString(), "<span class='cult'>You repair some of <b>" + this + "'s</b> dents, leaving <b>" + this + "</b> at <b>" + this.health + "/" + this.maxHealth + "</b> health.</span>" );
					} else {
						user.visible_message( "<span class='danger'>" + user + " repairs some of its own dents.</span>", "<span class='cult'>You repair some of your own dents, leaving you at <b>" + user.health + "/" + user.maxHealth + "</b> health.</span>" );
					}
				} else if ( this != user ) {
					user.WriteMsg( "<span class='cult'>You cannot repair <b>" + this + "'s</b> dents, as it has none!</span>" );
				} else {
					user.WriteMsg( "<span class='cult'>You cannot repair your own dents, as you have none!</span>" );
				}
			} else if ( this != user ) {
				base.attack_animal( user );
			}
			return false;
		}

		// Function from file: constructs.dm
		public override double examine( dynamic user = null ) {
			string msg = null;

			msg = new Txt( "<span cass='info'>*---------*\nThis is " ).icon( this ).str( " " ).a( this ).str( "<b>" ).item().str( "</b>!\n" ).ToString();

			if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
				msg += "<span class='warning'>";

				if ( Convert.ToDouble( this.health ) >= Convert.ToDouble( this.maxHealth / 2 ) ) {
					msg += "It looks slightly dented.\n";
				} else {
					msg += "<b>It looks severely dented!</b>\n";
				}
				msg += "</span>";
			}
			msg += "*---------*</span>";
			user.WriteMsg( msg );
			return 0;
		}

		// Function from file: constructs.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			base.death( true, toast );
			new Obj_Item_Weapon_Ectoplasm( this.loc );
			this.visible_message( "<span class='danger'>" + this + " collapses in a shattered heap.</span>" );
			this.ghostize();
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.assigned_role = "" + Lang13.Initial( this, "name" );
			this.mind.special_role = "Cultist";
			return;
		}

	}

}