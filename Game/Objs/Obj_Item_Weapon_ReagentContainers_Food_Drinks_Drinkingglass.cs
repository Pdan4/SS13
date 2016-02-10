// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass : Obj_Item_Weapon_ReagentContainers_Food_Drinks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.isGlass = true;
			this.amount_per_transfer_from_this = 10;
			this.starting_materials = new ByTable().Set( "$glass", 500 );
			this.force = 5;
			this.smashtext = "";
			this.smashname = "broken glass";
			this.melt_temperature = 1773.1500244140625;
			this.w_type = 2;
			this.icon_state = "glass_empty";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Drinkingglass ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: drinkingglass.dm
		public override void on_reagent_change(  ) {
			Image filling = null;

			base.on_reagent_change();
			this.viewcontents = true;
			this.overlays.len = 0;

			if ( this.reagents.reagent_list.len > 0 ) {
				this.flammable = false;

				if ( !( this.molotov != 0 ) ) {
					this.lit = false;
				}
				this.light_color = null;
				this.set_light( 0 );
				this.isGlass = true;

				switch ((string)( ((Reagents)this.reagents).get_master_reagent_id() )) {
					case "beer":
						this.icon_state = "beerglass";
						this.name = "beer glass";
						this.desc = "A freezing pint of beer.";
						break;
					case "beer2":
						this.icon_state = "beerglass";
						this.name = "beer glass";
						this.desc = "A freezing pint of beer.";
						break;
					case "ale":
						this.icon_state = "aleglass";
						this.name = "ale glass";
						this.desc = "A freezing pint of delicious ale.";
						break;
					case "milk":
						this.icon_state = "glass_white";
						this.name = "glass of milk";
						this.desc = "White and nutritious goodness!";
						break;
					case "cream":
						this.icon_state = "glass_white";
						this.name = "glass of cream";
						this.desc = "Ewwww...";
						break;
					case "chocolate":
						this.icon_state = "chocolateglass";
						this.name = "glass of chocolate";
						this.desc = "Tasty.";
						break;
					case "lemonjuice":
						this.icon_state = "lemonglass";
						this.name = "glass of lemonjuice";
						this.desc = "Sour...";
						break;
					case "cola":
						this.icon_state = "glass_brown";
						this.name = "glass of Space Cola";
						this.desc = "A glass of refreshing Space Cola.";
						break;
					case "nuka_cola":
						this.icon_state = "nuka_colaglass";
						this.name = "ÿNuka Cola";
						this.desc = "Don't cry, Don't raise your eye, It's only nuclear wasteland";
						break;
					case "orangejuice":
						this.icon_state = "glass_orange";
						this.name = "glass of orange juice";
						this.desc = "Vitamins! Yay!";
						break;
					case "tomatojuice":
						this.icon_state = "glass_red";
						this.name = "glass of tomato juice";
						this.desc = "Are you sure this is tomato juice?";
						break;
					case "blood":
						this.icon_state = "glass_red";
						this.name = "glass of tomato juice";
						this.desc = "Are you sure this is tomato juice?";
						break;
					case "limejuice":
						this.icon_state = "glass_green";
						this.name = "glass of lime juice";
						this.desc = "A glass of sweet-sour lime juice.";
						break;
					case "whiskey":
						this.icon_state = "whiskeyglass";
						this.name = "glass of whiskey";
						this.desc = "The silky, smokey whiskey goodness inside the glass makes the drink look very classy.";
						break;
					case "gin":
						this.icon_state = "ginvodkaglass";
						this.name = "glass of gin";
						this.desc = "A crystal clear glass of Griffeater gin.";
						break;
					case "vodka":
						this.icon_state = "ginvodkaglass";
						this.name = "glass of vodka";
						this.desc = "The glass contain wodka. Xynta.";
						break;
					case "sake":
						this.icon_state = "ginvodkaglass";
						this.name = "glass of sake";
						this.desc = "A glass of Sake.";
						break;
					case "goldschlager":
						this.icon_state = "ginvodkaglass";
						this.name = "glass of Goldschlager";
						this.desc = "100 proof that teen girls will drink anything with gold in it.";
						break;
					case "wine":
						this.icon_state = "wineglass";
						this.name = "glass of wine";
						this.desc = "A very classy looking drink.";
						break;
					case "cognac":
						this.icon_state = "cognacglass";
						this.name = "glass of cognac";
						this.desc = "Damn, you feel like some kind of French aristocrat just by holding this.";
						break;
					case "kahlua":
						this.icon_state = "kahluaglass";
						this.name = "glass of RR coffee liquor";
						this.desc = "DAMN, THIS THING LOOKS ROBUST";
						break;
					case "vermouth":
						this.icon_state = "vermouthglass";
						this.name = "glass of vermouth";
						this.desc = "You wonder why you're even drinking this straight.";
						break;
					case "tequila":
						this.icon_state = "tequilaglass";
						this.name = "glass of tequila";
						this.desc = "Now all that's missing is the weird colored shades!";
						break;
					case "patron":
						this.icon_state = "patronglass";
						this.name = "glass of Patron";
						this.desc = "Drinking Patron in the bar, with all the subpar ladies.";
						break;
					case "rum":
						this.icon_state = "rumglass";
						this.name = "glass of rum";
						this.desc = "Now you want to Pray for a pirate suit, don't you?";
						break;
					case "gintonic":
						this.icon_state = "gintonicglass";
						this.name = "gin and tonic";
						this.desc = "A mild but still great cocktail. Drink up, like a true Englishman.";
						break;
					case "whiskeycola":
						this.icon_state = "whiskeycolaglass";
						this.name = "whiskey cola";
						this.desc = "An innocent-looking mixture of cola and Whiskey. Delicious.";
						break;
					case "whiterussian":
						this.icon_state = "whiterussianglass";
						this.name = "ÿWhite Russian";
						this.desc = "A very nice looking drink. But that's just, like, your opinion, man.";
						break;
					case "screwdrivercocktail":
						this.icon_state = "screwdriverglass";
						this.name = "ÿScrewdriver";
						this.desc = "A simple, yet superb mixture of Vodka and orange juice. Just the thing for the tired engineer.";
						break;
					case "bloodymary":
						this.icon_state = "bloodymaryglass";
						this.name = "ÿBloody Mary";
						this.desc = "Tomato juice, mixed with Vodka and a lil' bit of lime. Tastes like liquid murder.";
						break;
					case "martini":
						this.icon_state = "martiniglass";
						this.name = "classic martini";
						this.desc = "Damn, the bartender even stirred it, not shook it.";
						break;
					case "vodkamartini":
						this.icon_state = "martiniglass";
						this.name = "vodka martini";
						this.desc = "A bastardisation of the classic martini. Still great.";
						break;
					case "gargleblaster":
						this.icon_state = "gargleblasterglass";
						this.name = "ÿPan-Galactic Gargle Blaster";
						this.desc = "Does... does this mean that Arthur and Ford are on the station? Oh joy.";
						break;
					case "bravebull":
						this.icon_state = "bravebullglass";
						this.name = "ÿBrave Bull";
						this.desc = "Tequila and coffee liquor, brought together in a mouthwatering mixture. Drink up.";
						break;
					case "tequilasunrise":
						this.icon_state = "tequilasunriseglass";
						this.name = "ÿTequila Sunrise";
						this.desc = "Oh great, now you feel nostalgic about sunrises back on Terra...";
						break;
					case "toxinsspecial":
						this.icon_state = "toxinsspecialglass";
						this.name = "ÿToxins Special";
						this.desc = "Whoah, this thing is on FIRE!";
						break;
					case "beepskysmash":
						this.icon_state = "beepskysmashglass";
						this.name = "ÿBeepsky Smash";
						this.desc = "Heavy, hot and strong. Just like the Iron fist of the LAW.";
						break;
					case "doctorsdelight":
						this.icon_state = "doctorsdelightglass";
						this.name = "ÿDoctor's Delight";
						this.desc = "A healthy mixture of juices, guaranteed to keep you healthy until the next toolboxing takes place.";
						break;
					case "manlydorf":
						this.icon_state = "manlydorfglass";
						this.name = "The Manly Dorf";
						this.desc = "A manly concotion made from Ale and Beer. Intended for true men only.";
						break;
					case "irishcream":
						this.icon_state = "irishcreamglass";
						this.name = "ÿIrish Cream";
						this.desc = "It's cream, mixed with whiskey. What else would you expect from the Irish?";
						break;
					case "cubalibre":
						this.icon_state = "cubalibreglass";
						this.name = "ÿCuba Libre";
						this.desc = "A classic mix of rum and cola.";
						break;
					case "b52":
						this.icon_state = "b52glass";
						this.name = "ÿB-52";
						this.desc = "Kahlua, Irish Cream, and congac. You will get bombed.";
						this.light_color = "#000080";

						if ( !this.lit ) {
							this.flammable = true;
						}
						break;
					case "atomicbomb":
						this.icon_state = "atomicbombglass";
						this.name = "ÿAtomic Bomb";
						this.desc = "Nanotrasen cannot take legal responsibility for your actions after imbibing.";
						break;
					case "longislandicedtea":
						this.icon_state = "longislandicedteaglass";
						this.name = "ÿLong Island Iced Tea";
						this.desc = "The liquor cabinet, brought together in a delicious mix. Intended for middle-aged alcoholic women only.";
						break;
					case "threemileisland":
						this.icon_state = "threemileislandglass";
						this.name = "ÿThree Mile Island Ice Tea";
						this.desc = "A glass of this is sure to prevent a meltdown.";
						break;
					case "margarita":
						this.icon_state = "margaritaglass";
						this.name = "ÿMargarita";
						this.desc = "On the rocks with salt on the rim. Arriba~!";
						break;
					case "blackrussian":
						this.icon_state = "blackrussianglass";
						this.name = "ÿBlack Russian";
						this.desc = "For the lactose-intolerant. Still as classy as a White Russian.";
						break;
					case "vodkatonic":
						this.icon_state = "vodkatonicglass";
						this.name = "vodka and tonic";
						this.desc = "For when a gin and tonic isn't Russian enough.";
						break;
					case "manhattan":
						this.icon_state = "manhattanglass";
						this.name = "ÿManhattan";
						this.desc = "The Detective's undercover drink of choice. He never could stomach gin...";
						break;
					case "manhattan_proj":
						this.icon_state = "proj_manhattanglass";
						this.name = "ÿManhattan Project";
						this.desc = "A scienitst drink of choice, for thinking how to blow up the station.";
						break;
					case "ginfizz":
						this.icon_state = "ginfizzglass";
						this.name = "ÿGin Fizz";
						this.desc = "Refreshingly lemony, deliciously dry.";
						break;
					case "irishcoffee":
						this.icon_state = "irishcoffeeglass";
						this.name = "ÿIrish Coffee";
						this.desc = "Coffee and alcohol. More fun than a Mimosa to drink in the morning.";
						break;
					case "hooch":
						this.icon_state = "glass_brown2";
						this.name = "ÿHooch";
						this.desc = "You've really hit rock bottom now... your liver packed its bags and left last night.";
						break;
					case "whiskeysoda":
						this.icon_state = "whiskeysodaglass2";
						this.name = "whiskey soda";
						this.desc = "Ultimate refreshment.";
						break;
					case "tonic":
						this.icon_state = "glass_clear";
						this.name = "glass of tonic water";
						this.desc = "Quinine tastes funny, but at least it'll keep that Space Malaria away.";
						break;
					case "sodawater":
						this.icon_state = "glass_clear";
						this.name = "glass of soda water";
						this.desc = "Soda water. Why not make a scotch and soda?";
						break;
					case "water":
						this.icon_state = "glass_clear";
						this.name = "glass of water";
						this.desc = "The father of all refreshments.";
						break;
					case "spacemountainwind":
						this.icon_state = "Space_mountain_wind_glass";
						this.name = "glass of Space Mountain Wind";
						this.desc = "Space Mountain Wind. As you know, there are no mountains in space, only wind.";
						break;
					case "thirteenloko":
						this.icon_state = "thirteen_loko_glass";
						this.name = "glass of Thirteen Loko";
						this.desc = "This is a glass of Thirteen Loko, it appears to be of the highest quality. The drink, not the glass.";
						break;
					case "dr_gibb":
						this.icon_state = "dr_gibb_glass";
						this.name = "glass of Dr. Gibb";
						this.desc = "Dr. Gibb. Not as dangerous as the name might imply.";
						break;
					case "space_up":
						this.icon_state = "space-up_glass";
						this.name = "glass of Space-up";
						this.desc = "Space-up. It helps keep your cool.";
						break;
					case "moonshine":
						this.icon_state = "glass_clear";
						this.name = "ÿMoonshine";
						this.desc = "You've really hit rock bottom now... your liver packed its bags and left last night.";
						break;
					case "soymilk":
						this.icon_state = "glass_white";
						this.name = "glass of soy milk";
						this.desc = "White and nutritious soy goodness!";
						break;
					case "berryjuice":
						this.icon_state = "berryjuice";
						this.name = "glass of berry juice";
						this.desc = "Berry juice. Or maybe its jam. Who cares?";
						break;
					case "poisonberryjuice":
						this.icon_state = "poisonberryjuice";
						this.name = "glass of poison berry juice";
						this.desc = "A glass of deadly juice.";
						break;
					case "carrotjuice":
						this.icon_state = "carrotjuice";
						this.name = "glass of  carrot juice";
						this.desc = "It is just like a carrot but without crunching.";
						break;
					case "banana":
						this.icon_state = "banana";
						this.name = "glass of banana juice";
						this.desc = "The raw essence of a banana. HONK";
						break;
					case "bahama_mama":
						this.icon_state = "bahama_mama";
						this.name = "ÿBahama Mama";
						this.desc = "Tropic cocktail.";
						break;
					case "singulo":
						this.icon_state = "singulo";
						this.name = "ÿSingulo";
						this.desc = "A blue-space beverage.";
						break;
					case "alliescocktail":
						this.icon_state = "alliescocktail";
						this.name = "ÿAllies Cocktail";
						this.desc = "A drink made from your allies.";
						break;
					case "antifreeze":
						this.icon_state = "antifreeze";
						this.name = "ÿAnti-freeze";
						this.desc = "The ultimate refreshment.";
						break;
					case "barefoot":
						this.icon_state = "b&p";
						this.name = "ÿBarefoot";
						this.desc = "Barefoot and pregnant.";
						break;
					case "demonsblood":
						this.icon_state = "demonsblood";
						this.name = "ÿDemon's Blood";
						this.desc = "Just looking at this thing makes the hair at the back of your neck stand up.";
						break;
					case "booger":
						this.icon_state = "booger";
						this.name = "ÿBooger";
						this.desc = "Ewww...";
						break;
					case "snowwhite":
						this.icon_state = "snowwhite";
						this.name = "ÿSnow White";
						this.desc = "A cold refreshment.";
						break;
					case "aloe":
						this.icon_state = "aloe";
						this.name = "aloe";
						this.desc = "Very, very, very good.";
						break;
					case "andalusia":
						this.icon_state = "andalusia";
						this.name = "ÿAndalusia";
						this.desc = "A nice, strange named drink.";
						break;
					case "sbiten":
						this.icon_state = "sbitenglass";
						this.name = "ÿSbiten";
						this.desc = "A spicy mix of vodka and spice. Very hot.";
						break;
					case "red_mead":
						this.icon_state = "red_meadglass";
						this.name = "red mead";
						this.desc = "A True Vikings Beverage, though its color is strange.";
						break;
					case "mead":
						this.icon_state = "meadglass";
						this.name = "mead";
						this.desc = "A Vikings Beverage, though a cheap one.";
						break;
					case "iced_beer":
						this.icon_state = "iced_beerglass";
						this.name = "iced Beer";
						this.desc = "A beer so frosty, the air around it freezes.";
						break;
					case "grog":
						this.icon_state = "grogglass";
						this.name = "grog";
						this.desc = "A fine and cepa drink for Space.";
						break;
					case "soy_latte":
						this.icon_state = "soy_latte";
						this.name = "soy latte";
						this.desc = "A nice and refrshing beverage while you are reading.";
						break;
					case "cafe_latte":
						this.icon_state = "cafe_latte";
						this.name = "cafe latte";
						this.desc = "A nice, strong and refreshing beverage while you are reading.";
						break;
					case "acidspit":
						this.icon_state = "acidspitglass";
						this.name = "ÿAcid Spit";
						this.desc = "A drink from Nanotrasen. Made from live aliens.";
						break;
					case "amasec":
						this.icon_state = "amasecglass";
						this.name = "ÿAmasec";
						this.desc = "Always handy before COMBAT!!!";
						break;
					case "neurotoxin":
						this.icon_state = "neurotoxinglass";
						this.name = "ÿNeurotoxin";
						this.desc = "A drink that is guaranteed to knock you silly.";
						break;
					case "hippiesdelight":
						this.icon_state = "hippiesdelightglass";
						this.name = "ÿHippie's Delight";
						this.desc = "A drink enjoyed by people during the 1960's.";
						break;
					case "bananahonk":
						this.icon_state = "bananahonkglass";
						this.name = "ÿBanana Honk";
						this.desc = "A drink from banana heaven.";
						break;
					case "silencer":
						this.icon_state = "silencerglass";
						this.name = "ÿSilencer";
						this.desc = "A drink from mime heaven.";
						break;
					case "nothing":
						this.icon_state = "nothing";
						this.name = "nothing";
						this.desc = "Absolutely nothing.";
						break;
					case "devilskiss":
						this.icon_state = "devilskiss";
						this.name = "ÿDevils Kiss";
						this.desc = "Creepy time!";
						break;
					case "changelingsting":
						this.icon_state = "changelingsting";
						this.name = "ÿChangeling Sting";
						this.desc = "A stingy drink.";
						break;
					case "irishcarbomb":
						this.icon_state = "irishcarbomb";
						this.name = "ÿIrish Car Bomb";
						this.desc = "An irish car bomb.";
						break;
					case "syndicatebomb":
						this.icon_state = "syndicatebomb";
						this.name = "ÿSyndicate Bomb";
						this.desc = "A syndicate bomb.";
						this.isGlass = false;
						break;
					case "erikasurprise":
						this.icon_state = "erikasurprise";
						this.name = "ÿErika Surprise";
						this.desc = "The surprise is, it's green!";
						break;
					case "driestmartini":
						this.icon_state = "driestmartiniglass";
						this.name = "ÿDriest Martini";
						this.desc = "Only for the experienced. You think you see sand floating in the glass.";
						break;
					case "ice":
						this.icon_state = "iceglass";
						this.name = "glass of ice";
						this.desc = "Generally, you're supposed to put something else in there too...";
						break;
					case "icecoffee":
						this.icon_state = "icedcoffeeglass";
						this.name = "iced Coffee";
						this.desc = "A drink to perk you up and refresh you!";
						break;
					case "coffee":
						this.icon_state = "glass_brown";
						this.name = "glass of coffee";
						this.desc = "Don't drop it, or you'll send scalding liquid and glass shards everywhere.";
						break;
					case "bilk":
						this.icon_state = "glass_brown";
						this.name = "glass of bilk";
						this.desc = "A brew of milk and beer. For those alcoholics who fear osteoporosis.";
						break;
					case "fuel":
						this.icon_state = "dr_gibb_glass";
						this.name = "glass of welder fuel";
						this.desc = "Unless you are an industrial tool, this is probably not safe for consumption.";
						break;
					case "brownstar":
						this.icon_state = "brownstar";
						this.name = "ÿBrown Star";
						this.desc = "Its not what it sounds like...";
						break;
					case "icetea":
						this.icon_state = "icetea";
						this.name = "iced tea";
						this.desc = "No relation to a certain rap artist/ actor.";
						break;
					case "arnoldpalmer":
						this.icon_state = "arnoldpalmer";
						this.name = "Arnold Palmer";
						this.desc = "Known as half and half to some.  A mix of ice tea and lemonade";
						break;
					case "milkshake":
						this.icon_state = "milkshake";
						this.name = "milkshake";
						this.desc = "Glorious brainfreezing mixture.";
						break;
					case "lemonade":
						this.icon_state = "lemonade";
						this.name = "lemonade";
						this.desc = "Oh the nostalgia...";
						break;
					case "kiraspecial":
						this.icon_state = "kiraspecial";
						this.name = "ÿKira Special";
						this.desc = "Long live the guy who everyone had mistaken for a girl. Baka!";
						break;
					case "rewriter":
						this.icon_state = "rewriter";
						this.name = "ÿRewriter";
						this.desc = "The secert of the sanctuary of the Libarian...";
						break;
					case "pinacolada":
						this.icon_state = "pinacolada";
						this.name = "ÿPina Colada";
						this.desc = "If you like this and getting caught in the rain, come with me and escape.";
						break;
					default:
						this.icon_state = "glass_colour";
						GlobalFuncs.get_reagent_name( this );
						filling = new Image( "icons/obj/reagentfillings.dmi", this, "glass" );
						filling.icon += GlobalFuncs.mix_color_from_reagents( this.reagents.reagent_list );
						filling.alpha = Convert.ToInt32( GlobalFuncs.mix_alpha_from_reagents( this.reagents.reagent_list ) );
						this.overlays.Add( filling );
						break;
				}

				if ( ((Reagents)this.reagents).has_reagent( "blackcolor" ) ) {
					this.icon_state = "blackglass";
					this.name = "international drink of mystery";
					this.desc = "The identity of this drink has been concealed for its protection.";
					this.viewcontents = false;
				}
			} else {
				this.icon_state = "glass_empty";
				this.name = "drinking glass";
				this.desc = "Your standard drinking glass.";
				return;
			}
			return;
		}

	}

}