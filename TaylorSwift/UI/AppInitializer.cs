using TaylorSwift.Worksheets;

namespace TaylorSwift.UI
{// --- AppInitializer Class: Builds the entire menu structure ---
    public static class AppInitializer
    {
        /// <summary>
        /// Creates the entire application menu tree.
        /// </summary>
        public static MenuNode InitializeAppStructure(Action exitAction)
        {
            // 1. Create Main Menu
            var main = new MenuNode("Main Menu");

            // 2. Create TSIS (Taylor Swift Information System) - Min 20 Nodes
            var tsis = CreateTaylorSwiftSystem();
            main.Children.Add(tsis);

            // 3. Create Activities Module (Extendable Worksheets)
            var activities = CreateActivitiesModule();
            main.Children.Add(activities);

            var TSDance = new MenuNode("Taylor Swift Dancing ASCII 30 Minutes", null, () => TaylorSwiftAnimation.Play(1000));
            main.Children.Add(TSDance);

            return main;
        }

        private static MenuNode CreateTaylorSwiftSystem()
        {
            var tsis = new MenuNode("Taylor Swift Information System (TSIS)",
                "Curated information detailing the career, impact, and discography of Taylor Swift. Navigate the categories below to explore her work and legacy.");

            var biography = new MenuNode("Biography");
            var overview = new MenuNode("Overview and Legacy",
                "Taylor Swift is one of the most influential artists of the 21st century. She is the first artist to win the Grammy Award for Album of the Year four times, mastering genre transitions and reshaping artist rights.");
            var earlyLife = new MenuNode("Early Life and Influences",
                "Born in 1989 in Pennsylvania, raised on a Christmas tree farm, and inspired by country icons. She moved to Nashville at 14, becoming the youngest signed artist at Sony/ATV Publishing.");
            var publicImage = new MenuNode("Public Image and Media",
                "Her image evolved from a country prodigy to a self-aware cultural figure reclaiming her narrative through albums like 'reputation.'");
            var philanthropy = new MenuNode("Philanthropy and Activism",
                "Donations to education, disaster relief, and advocacy for artist ownership define her public impact.");
            biography.Children.AddRange(new[] { overview, earlyLife, publicImage, philanthropy });
            tsis.Children.Add(biography);

            var career = new MenuNode("Career Overview");
            var milestones = new MenuNode("Career Milestones (1989 - Present)",
                "Her career spans from her 2006 country debut to pop superstardom and independent ownership. Major phases include her country beginnings, pop domination, and indie reinvention.");
            var reRecordings = new MenuNode("The Re-Recordings Project",
                "A major ownership effort to re-record her first six albums ('Taylor’s Version'), adding 'From the Vault' tracks.");
            var awards = new MenuNode("Major Awards and Accolades",
                "Holder of record Grammy wins (4 for Album of the Year) and most AMA wins of all time. Recognized across multiple genres.");
            var influence = new MenuNode("Cultural and Economic Impact",
                "'The Eras Tour' became the highest-grossing tour in history, driving 'Swiftonomics' and reshaping artist-fan economics.");
            career.Children.AddRange(new[] { milestones, reRecordings, awards, influence });
            tsis.Children.Add(career);

            var eras = new MenuNode("Musical Eras");
            tsis.Children.Add(eras);

            // --- Era 1: Country Foundations ---
            var era1 = new MenuNode("Country Foundations (2006–2010)",
                "Covers her early Nashville country era and rise as a teen songwriter with 'Taylor Swift,' 'Fearless,' and 'Speak Now.'");

            var debut = new MenuNode("Taylor Swift (Debut, 2006)",
                "Taylor Swift’s self-titled debut album introduced her as a prodigious country-pop storyteller with remarkable songwriting maturity for her age. The record captures the emotional landscape of adolescence—first love, heartbreak, and ambition—through a mix of acoustic guitar-driven melodies and diary-like lyrics. It established her as a fresh voice in Nashville and earned her multiple awards, setting the foundation for her evolution into a global artist.");
            debut.Children.AddRange(new[]
            {
        new MenuNode("Tim McGraw", "Written while she was in high school, the song nostalgically associates a romantic memory with a favorite artist’s music. It blends youthful sentimentality with sophisticated lyrical framing uncommon for debut singles. The song became her breakthrough, signaling her potential as both a writer and performer."),
        new MenuNode("Teardrops on My Guitar", "This track captures the sting of unrequited love with vivid simplicity and emotional honesty. Its crossover success marked her first steps beyond country radio, reaching mainstream pop audiences. The song’s tender vocals and melodic restraint highlight her ability to universalize teenage emotion."),
        new MenuNode("Our Song", "A fiddle-driven, upbeat anthem that celebrates young love and small-town life. Its playful lyrical structure and spoken-word verses showcase Swift’s early storytelling flair. The track became her first solo No. 1 on the Country charts and cemented her reputation as a natural hitmaker.")
    });

            var fearless = new MenuNode("Fearless (2008 / Taylor’s Version 2021)",
                "Fearless elevated Swift to superstardom by fusing country and pop sensibilities with cinematic songwriting. The album revolves around youthful idealism, romantic optimism, and heartbreak, often framed as fairytales for the modern age. Its commercial success and critical acclaim made Swift the youngest artist to win the Grammy for Album of the Year at the time.");
            fearless.Children.AddRange(new[]
            {
        new MenuNode("Love Story", "A modern retelling of Romeo and Juliet with a happy ending, reimagining forbidden love through a hopeful lens. Its fusion of country storytelling and pop hooks made it one of the defining songs of the late 2000s. The song became an international phenomenon, solidifying her crossover appeal."),
        new MenuNode("You Belong with Me", "A catchy, anthemic portrayal of unreciprocated affection and the feeling of being overlooked. Its relatable narrative and clever contrast between “popular girl” and “best friend” archetypes resonated widely. The music video and melody further cemented Swift’s image as the voice of teenage emotion.")
    });

            var speakNow = new MenuNode("Speak Now (2010 / Taylor’s Version 2023)",
                "Speak Now is entirely self-written, a rarity in mainstream pop, showcasing Swift’s control over her craft and narrative. The album’s themes include regret, empowerment, apology, and self-awareness, framed within a confessional structure. It represented her transition from country teen idol to a fully realized storyteller commanding both lyrical and melodic complexity.");
            speakNow.Children.AddRange(new[]
            {
        new MenuNode("Mine", "A pop-country fusion detailing the tension between fear of commitment and desire for stability. The song demonstrates Swift’s maturation as she reflects on her family’s past and her own relationship anxieties. It balances optimism with realism, offering a nuanced take on adult relationships."),
        new MenuNode("Dear John", "A slow, emotionally charged ballad about manipulation, regret, and personal awakening. The track’s raw vulnerability and lyrical precision invite comparisons to classic singer-songwriter confessions. It remains one of her most searing and personal works, exemplifying her bravery in autobiographical storytelling.")
    });

            era1.Children.AddRange(new[] { debut, fearless, speakNow });
            eras.Children.Add(era1);

            // --- Era 2: Pop Expansion ---
            var era2 = new MenuNode("Pop Expansion (2012–2019)",
                "Transition from country roots to full pop dominance through sonic experimentation and narrative control.");

            var red = new MenuNode("Red (2012 / Taylor’s Version 2021)",
                "Red marks the turning point between Swift’s country roots and pop reinvention, symbolizing emotional chaos through its namesake color. The album’s eclectic sound ranges from acoustic ballads to dubstep-infused anthems, reflecting heartbreak’s volatility. It is often described as her most transitional and experimental project, bridging two musical worlds.");
            red.Children.AddRange(new[]
            {
        new MenuNode("All Too Well (10 Minute Version)", "A sweeping, cinematic narrative chronicling the unraveling of a past relationship in visceral detail. Its imagery—scarves, autumn leaves, and lingering pain—became cultural shorthand for emotional devastation. The extended version transformed it into a generational masterpiece of long-form songwriting."),
        new MenuNode("I Knew You Were Trouble.", "A bold venture into electronic pop production, merging emotional turmoil with aggressive beats. The song’s chorus collapse symbolizes internal chaos and disillusionment. It proved Swift’s adaptability and foreshadowed her eventual move toward full-scale pop dominance.")
    });

            var nineteenEightyNine = new MenuNode("1989 (2014 / Taylor’s Version 2023)",
                "1989 is a complete stylistic rebirth, embracing glossy synth-pop and 1980s influences while shedding her country identity. The album’s themes center on self-definition, fame, and freedom, presented through confident and playful songwriting. Its commercial and critical triumph redefined pop for the 2010s and won Swift her second Album of the Year Grammy.");
            nineteenEightyNine.Children.AddRange(new[]
            {
        new MenuNode("Shake It Off", "A jubilant anthem about resilience and indifference to criticism. Its energetic horns, percussive rhythm, and irreverent lyrics marked her break from country entirely. The song’s infectious optimism became emblematic of Swift’s new creative era."),
        new MenuNode("Blank Space", "A self-aware, satirical commentary on her public image as a serial dater. Through sharp wit and minimalist pop production, she transforms media caricature into empowerment. The song’s irony-laden persona made it one of her most iconic artistic statements.")
    });

            var reputation = new MenuNode("Reputation (2017)",
                "Reputation is a dark, aggressive response to public scrutiny, exploring revenge, reinvention, and rediscovery of love. Its production leans into trap and electro-pop, reflecting paranoia and defiance. Beneath the cynicism, the album reveals an emotional core about finding genuine affection amid chaos.");
            reputation.Children.AddRange(new[]
            {
        new MenuNode("Look What You Made Me Do", "A biting, theatrical declaration of rebirth and revenge. The track’s minimalist beat and serpentine imagery symbolize the death of “the old Taylor.” It redefined her aesthetic and marked one of the boldest shifts in her career."),
        new MenuNode("Delicate", "A fragile, intimate synth-pop track that contrasts vulnerability against the noise of fame. Its vocoder-laced vocals emphasize insecurity and sincerity. The song humanizes Swift, offering a glimpse of quiet authenticity in an era of spectacle.")
    });

            var lover = new MenuNode("Lover (2019)",
                "Lover celebrates healing, romantic stability, and political awareness after the turbulence of Reputation. It blends pastel pop with introspection, reclaiming color and joy as central motifs. The album also marks her first release under full creative ownership with Republic Records.");
            lover.Children.AddRange(new[]
            {
        new MenuNode("Cruel Summer", "A euphoric, tension-filled anthem about forbidden love and emotional chaos. The track’s explosive bridge exemplifies Swift’s talent for cathartic songwriting. Despite its delayed single release, it became one of her most celebrated pop tracks."),
        new MenuNode("Lover", "A nostalgic waltz capturing domestic contentment and enduring affection. Its simplicity and warmth make it one of her most timeless love songs. The composition reflects a matured, confident romantic perspective.")
    });

            era2.Children.AddRange(new[] { red, nineteenEightyNine, reputation, lover });
            eras.Children.Add(era2);

            // --- Era 3: Indie and Reinvention ---
            var era3 = new MenuNode("Indie Reinvention (2020–2024)",
                "Artistic evolution toward introspective, narrative, and alternative pop styles, exploring identity and storytelling.");

            var folklore = new MenuNode("Folklore (2020)",
                "Folklore is an introspective, indie-folk pivot that trades spectacle for quiet storytelling and literary subtlety. It features fictional characters woven into interconnected narratives about love, memory, and grief. The album’s restrained production and poetic detail earned it universal acclaim and her third Album of the Year Grammy.");
            folklore.Children.AddRange(new[]
            {
        new MenuNode("Cardigan", "A melancholic ballad exploring love and nostalgia through tactile metaphors. Its piano-driven sound evokes a sense of faded intimacy and emotional residue. The song encapsulates the album’s understated and reflective tone."),
        new MenuNode("Exile", "A duet with Bon Iver portraying two ex-lovers who can no longer communicate. The interplay of voices dramatizes emotional distance and mutual misunderstanding. It stands as one of her most sophisticated narrative compositions.")
    });

            var evermore = new MenuNode("Evermore (2020)",
                "A whimsical, witchy love song rooted in natural metaphors and destiny. Its soft instrumentation mirrors the fluidity of love’s pull. The track’s mystical aesthetic aligns with the album’s enchanting atmosphere.");
            evermore.Children.AddRange(new[]
            {
        new MenuNode("Willow", "A whimsical, witchy love song rooted in natural metaphors and destiny. Its soft instrumentation mirrors the fluidity of love’s pull. The track’s mystical aesthetic aligns with the album’s enchanting atmosphere."),
        new MenuNode("Champagne Problems", "A poignant piano ballad about a rejected marriage proposal. Its emotional complexity arises from empathy for both perspectives. The song’s narrative craftsmanship highlights Swift’s evolution as a novelist-like songwriter.")
    });

            var midnights = new MenuNode("Midnights (2022)",
                "Midnights returns to synth-pop, framing self-examination and insecurity through nocturnal introspection. The concept unites thirteen sleepless nights across her life, blending confessional vulnerability with sharp wit. It became her most commercially dominant record and earned her a record-breaking fourth Album of the Year Grammy..");
            midnights.Children.AddRange(new[]
            {
        new MenuNode("Anti-Hero", "A sardonic self-portrait exposing insecurities and impostor syndrome. Its chorus, “It’s me, hi, I’m the problem,” became a cultural meme of radical self-awareness. The song balances humor and existential anxiety with lyrical precision."),
        new MenuNode("Lavender Haze", "An exploration of maintaining love under public pressure. Its dreamy soundscape evokes intimacy and escape from media intrusion. The song reaffirms Swift’s romantic idealism amid modern chaos."),
        new MenuNode("Mastermind", "A confession of strategic control in love and career. The song acknowledges her calculated nature while reframing it as a form of self-preservation. It closes the album with playful candor and thematic resolution.")
    });

            var torturedPoets = new MenuNode("The Tortured Poets Department (2024)",
                "The Tortured Poets Department is a sprawling, introspective work that explores grief, obsession, and creative exhaustion. Its sound merges synth-pop minimalism with poetic melancholy, often blurring autobiography with performance. The album functions as both a breakup chronicle and an essay on art, fame, and self-mythology.");
            torturedPoets.Children.AddRange(new[]
            {
        new MenuNode("Fortnight", "A collaboration with Post Malone examining the intensity and brevity of doomed love. Its restrained production mirrors emotional numbness and obsession. The song sets the tone for the album’s themes of transience and delusion."),
        new MenuNode("The Tortured Poets Department", "The title track satirizes the archetype of the “suffering artist” while confronting emotional dependence. It juxtaposes grandeur with absurdity, critiquing the romanticization of pain. The song encapsulates the album’s central tension between sincerity and performance.")
    });

            era3.Children.AddRange(new[] { folklore, evermore, midnights, torturedPoets });
            eras.Children.Add(era3);

            return tsis;
        }

        private static MenuNode CreateActivitiesModule()
        {
            var activities = new MenuNode("Activities Module");

            var module1 = new MenuNode("Module 1 - Input / Output");
            var module2 = new MenuNode("Module 2 - Conditional Statements");
            var module3 = new MenuNode("Module 3 - Looping");
            activities.Children.Add(module1);
            activities.Children.Add(module2);
            activities.Children.Add(module3);

            List<IActivity> module1Worksheets = new()
            {
                new Worksheets.Module_1.Worksheet1(),
                new Worksheets.Module_1.Worksheet2(),
                new Worksheets.Module_1.Worksheet3(),
                new Worksheets.Module_1.Worksheet4(),
                new Worksheets.Module_1.Worksheet5(),
                new Worksheets.Module_1.Worksheet6(),
                new Worksheets.Module_1.Worksheet7(),
                new Worksheets.Module_1.Worksheet8(),
                new Worksheets.Module_1.Worksheet9(),
                new Worksheets.Module_1.Worksheet10(),
            };

            List<IActivity> module2Worksheets = new()
            {
                new Worksheets.Module_2.Worksheet1(),
                new Worksheets.Module_2.Worksheet2(),
                new Worksheets.Module_2.Worksheet3(),
                new Worksheets.Module_2.Worksheet4(),
                new Worksheets.Module_2.Worksheet5(),
                new Worksheets.Module_2.Worksheet6(),
                new Worksheets.Module_2.Worksheet7(),
                new Worksheets.Module_2.Worksheet8(),
                new Worksheets.Module_2.Worksheet9(),
                new Worksheets.Module_2.Worksheet10(),
            };

            List<IActivity> module3Worksheets = new()
            {
                new Worksheets.Module_3.Worksheet1(),
                new Worksheets.Module_3.Worksheet2(),
                new Worksheets.Module_3.Worksheet3(),
                new Worksheets.Module_3.Worksheet4(),
                new Worksheets.Module_3.Worksheet5(),
                new Worksheets.Module_3.Worksheet6(),
                new Worksheets.Module_3.Worksheet7(),
                new Worksheets.Module_3.Worksheet8(),
                new Worksheets.Module_3.Worksheet9(),
                new Worksheets.Module_3.Worksheet10(),
            };

            foreach (var worksheet in module1Worksheets)
            {
                var worksheetNode = new MenuNode(worksheet.Title)
                {
                    ActivityInstance = worksheet
                };
                module1.Children.Add(worksheetNode);
            }

            foreach (var worksheet in module2Worksheets)
            {
                var worksheetNode = new MenuNode(worksheet.Title)
                {
                    ActivityInstance = worksheet
                };
                module2.Children.Add(worksheetNode);
            }

            foreach (var worksheet in module3Worksheets)
            {
                var worksheetNode = new MenuNode(worksheet.Title)
                {
                    ActivityInstance = worksheet
                };
                module3.Children.Add(worksheetNode);
            }

            return activities;
        }
    }
}
