from typing import List, Optional, Callable
from BaseClasses import CollectionState
from dataclasses import dataclass
from .Regions import Regions, Holo8Region
from .Options import Holo8Options

@dataclass
class Holo8Location:
    name: str
    region: Holo8Region
    game_id: str
    logic: Optional[Callable[[CollectionState], bool]] = None

def get_location_data(player: Optional[int], options: Optional[Holo8Options], doNormal: bool, doEveryday: bool):

    locations: List[Holo8Location] = []

    #Normal anomalies.
    if doNormal:
        locations += (
            Holo8Location("Black-Haired Suisei", Regions.normal, "0_0"),
            Holo8Location("35P Graffiti", Regions.normal, "0_2", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("35P Ball", Regions.normal, "0_4", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Ririka Poster", Regions.normal, "0_5", lambda state: state.has('ReGLOSS', player) or state.has('Ichijou Ririka', player)),
            Holo8Location("Red-Tinted Office", Regions.normal, "0_6"),
            Holo8Location("Gigi at the Buttons", Regions.normal, "0_7", lambda state: state.has('Hololive Justice', player) or state.has('Gigi Murin', player)),
            Holo8Location("Ayame with Silly Glasses", Regions.normal, "0_8"),
            Holo8Location("Miteiru Lights Off", Regions.normal, "0_9"),
            Holo8Location("Ayame Dancing", Regions.normal, "0_10"),
            Holo8Location("Hyper Dancing", Regions.normal, "0_11"),
            Holo8Location("Ao's Long Legs", Regions.normal, "0_12", lambda state: state.has('ReGLOSS', player) or state.has('Hiodoshi Ao', player)),
            Holo8Location("35P Poster", Regions.normal, "0_13", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Nousagi and Ayame", Regions.normal, "0_14", lambda state: state.has('Hololive Fantasy', player) or state.has('Usada Pekora', player)),
            Holo8Location("35P and Suisei", Regions.normal, "0_15", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Marine's Strained Back", Regions.normal, "0_16"),
            Holo8Location("miComet", Regions.normal, "0_17", lambda state: state.has('Hololive Generation 0', player) or state.has_all({'Sakura Miko', 'Hoshimachi Suisei'}, player)),
            Holo8Location("Large Nousagi", Regions.normal, "0_18", lambda state: state.has('Hololive Fantasy', player) or state.has('Usada Pekora', player)),
            Holo8Location("YAGOO Nameplate", Regions.normal, "0_19"),
            Holo8Location("Watame's Chair Spinning", Regions.normal, "0_20", lambda state: state.has('HoloForce', player) or state.has('Tsunomaki Watame', player)),
            Holo8Location("Just Koyori.", Regions.normal, "0_21", lambda state: state.has('HoloX Secret Society', player) or state.has('Hakui Koyori', player)),
            Holo8Location("Watchful Akirose", Regions.normal, "0_22", lambda state: state.has('Hololive Generation 1', player) or state.has('Aki Rosenthal', player)),
            Holo8Location("Laughing Voice", Regions.normal, "0_23", lambda state: state.has('NePoLaBo', player) or state.has('Shishiro Botan', player)),
            Holo8Location("Sora in the Elevator", Regions.normal, "0_24", lambda state: state.has('Hololive Generation 0', player) or state.has('Tokino Sora', player)),
            Holo8Location("Choco and Fubuzilla", Regions.normal, "0_25", lambda state: state.has_all({'Hololive Generation 1', 'Hololive Generation 2'}, player) or state.has_all({'Shirakami Fubuki', 'Yuzuki Choco'}, player)),
            Holo8Location("Mio and Ayame", Regions.normal, "0_26", lambda state: state.has_all({'Hololive Generation 2', 'Hololive GAMERS'}, player) or state.has_all({'Nakiri Ayame', 'Ookami Mio'}, player)),
            Holo8Location("Poster Movement", Regions.normal, "0_27"),
            Holo8Location("Kanade's Meme Dance", Regions.normal, "0_28", lambda state: state.has('ReGLOSS', player) or state.has('Otonose Kanade', player)),
            Holo8Location("Suisei's Large Phone", Regions.normal, "0_29"),
            Holo8Location("Ayame's Growth", Regions.normal, "0_30"),
            Holo8Location("Marine's Growth", Regions.normal, "0_31"),
            Holo8Location("Light and Shadow", Regions.normal, "0_32"),
            Holo8Location("Ayame Looking At You", Regions.normal, "0_33"),
            Holo8Location("Suisei's Smile", Regions.normal, "0_34"),
            Holo8Location("Angry Ayame", Regions.normal, "0_35"),
            Holo8Location("Marine's Smile", Regions.normal, "0_36"),
            Holo8Location("AZKi in the Elevator", Regions.normal, "0_37", lambda state: state.has('Hololive Generation 0', player) or state.has('AZKi', player)),
            Holo8Location("Ayame Hugging Koronesuki", Regions.normal, "0_38", lambda state: state.has('Hololive GAMERS', player) or state.has('Inugami Korone', player)),
            Holo8Location("Miko in the Elevator", Regions.normal, "0_39", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Mikodanye in the Hallway", Regions.normal, "0_40", lambda state: state.has('Mikodanye', player)),
            Holo8Location("Taranchama in the Hallway", Regions.normal, "0_41", lambda state: state.has('Taranchama', player)),
            Holo8Location("Tree-Kun", Regions.normal, "0_42", lambda state: state.has('Hololive GAMERS', player) or state.has('Inugami Korone', player)),
            Holo8Location("Tired Fubuzilla", Regions.normal, "0_43", lambda state: state.has('Hololive Generation 1', player) or state.has('Shirakami Fubuki', player)),
            Holo8Location("Miteiru in the Hallway", Regions.normal, "0_44", lambda state: state.has('Hololive Generation 1', player) or state.has('Shirakami Fubuki', player)),
            Holo8Location("Loli Subaru", Regions.normal, "0_45", lambda state: state.has('Hololive Generation 2', player) or state.has('Oozora Subaru', player)),
            Holo8Location("AquShio Broomstick Ride", Regions.normal, "0_46", lambda state: state.has('Hololive Generation 2', player) or state.has_all({'Minato Aqua', 'Murasaki Shion'}, player)),
            Holo8Location("Watame in the Private Room", Regions.normal, "0_47", lambda state: state.has('HoloForce', player) or state.has('Tsunomaki Watame', player)),
            Holo8Location("Kanata as a Wall", Regions.normal, "0_48", lambda state: state.has('HoloForce', player) or state.has('Amane Kanata', player)),
            Holo8Location("Botan's Shopping Cart", Regions.normal, "0_49", lambda state: state.has('NePoLaBo', player) or state.has('Shishiro Botan', player)),
            Holo8Location("Ollie Jumpscare", Regions.normal, "0_50", lambda state: state.has('Holoro', player) or state.has('Kureiji Ollie', player)),
            Holo8Location("Mumei's Nightmare", Regions.normal, "0_51", lambda state: state.has('Hololive CouncilRyS', player) or state.has('Nanashi Mumei', player)),
            Holo8Location("Fuwamoco in the Hallway", Regions.normal, "0_52", lambda state: state.has('Hololive Advent', player) or state.has('FUWAMOCO', player)),
            Holo8Location("Raden's Noh Mask", Regions.normal, "0_53", lambda state: state.has('ReGLOSS', player) or state.has('Juufuutei Raden', player)),
            Holo8Location("Kiara in the Elevator", Regions.normal, "0_55", lambda state: state.has('Hololive Myth', player) or state.has('Takanashi Kiara', player)),
            Holo8Location("Hiding Fubuki", Regions.normal, "0_57", lambda state: state.has('Hololive Generation 1', player) or state.has('Shirakami Fubuki', player)),
            Holo8Location("Surrounding a Koronesuki", Regions.normal, "0_58", lambda state: state.has('Hololive GAMERS', player) or state.has('Inugami Korone', player)),
            Holo8Location("Observation Room", Regions.normal, "0_59", lambda state: state.has_all({'Mikodanye', 'Taranchama'}, player)),
            Holo8Location("Kanata's Handshake Event", Regions.normal, "0_60", lambda state: state.has('HoloForce', player) or state.has('Amane Kanata', player)),
            Holo8Location("No Overtime", Regions.normal, "0_62"),
            Holo8Location("Mikodanye Stuck in a Door", Regions.normal, "0_63", lambda state: state.has('Mikodanye', player)),
            Holo8Location("Polpeller", Regions.normal, "0_64", lambda state: state.has('NePoLaBo', player) or state.has('Omaru Polka', player)),
            Holo8Location("Nene and Giraffa", Regions.normal, "0_66", lambda state: state.has('NePoLaBo', player) or state.has('Momosuzu Nene', player)),
            Holo8Location("Vivi's Makeup Session", Regions.normal, "0_67", lambda state: state.has_all({'ReGLOSS', 'FLOW GLOW'}, player) or state.has_all({'Juufuutei Raden', 'Kikirara Vivi'}, player)),
            Holo8Location("Under Construction", Regions.normal, "0_68", lambda state: state.has_all({'Mikodanye', 'Taranchama'}, player)),
            Holo8Location("35P on the Exit Door", Regions.normal, "0_69", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Coco's Piggyback Ride", Regions.normal, "0_71", lambda state: state.has('HoloForce', player) or state.has_all({'Amane Kanata', 'Kiryu Coco'}, player)),
            Holo8Location("Hagebo", Regions.normal, "0_72", lambda state: state.has('Hololive Generation 0', player) or state.has('Roboco', player)),
            Holo8Location("Suicopath", Regions.normal, "0_73", lambda state: state.has('Hololive Generation 0', player) or state.has('Hoshimachi Suisei', player)),
            Holo8Location("AZKi's Telephone", Regions.normal, "0_74", lambda state: state.has('Hololive Generation 0', player) or state.has('AZKi', player)),
            Holo8Location("Onion in the Poster", Regions.normal, "0_75"),
            Holo8Location("Marine's Watchful Eye", Regions.normal, "0_78", lambda state: state.has('Hololive Fantasy', player) or state.has('Houshou Marine', player)),
            Holo8Location("Miko's Escape from the Elevator", Regions.normal, "0_79", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Hiding Kaela", Regions.normal, "0_80", lambda state: state.has('Holoh3ro', player) or state.has('Kaela Kovalskia', player)),
            Holo8Location("Shion Poster", Regions.normal, "0_81", lambda state: state.has('Hololive Generation 2', player) or state.has('Murasaki Shion', player)),
            Holo8Location("Jumping Ririka", Regions.normal, "0_82", lambda state: state.has('ReGLOSS', player) or state.has('Ichijou Ririka', player)),
            Holo8Location("Oshimiya-san", Regions.normal, "0_83", lambda state: state.has('HoloForce', player) or state.has('Tsunomaki Watame', player)),
        )
        #Hard anomalies.
        #These anomalies require heavy attention to the playfield, which can be difficult to attain in syncs.
        if not options or options.hard_anomalies:
            locations +=(
                Holo8Location("Ayame's Clothes", Regions.normal, "0_1"),
                Holo8Location("Taranchama Eyes", Regions.normal, "0_3", lambda state: state.has('Taranchama', player)),
                Holo8Location("Blinking AZKi Poster", Regions.normal, "0_54"),
                Holo8Location("Incorrect Heterochromia", Regions.normal, "0_56"),
                Holo8Location("Miteiru Poster's Eyes", Regions.normal, "0_61"),
                Holo8Location("Marine's Eyepatch Design", Regions.normal, "0_61"),
                Holo8Location("Botan's Camouflage", Regions.normal, "0_70", lambda state: state.has('NePoLaBo', player) or state.has('Shishiro Botan', player)),
                Holo8Location("Hidden Sapling", Regions.normal, "0_76"),
                Holo8Location("Chloe Bath Poster", Regions.normal, "0_77"),
            )

    #Everyday anomalies.
    #Everyday anomalies are never marked as hard.
    if doEveryday:
        locations += (
            Holo8Location("HoloFantasy Tower", Regions.everyday, "1_0", lambda state: state.has('Hololive Fantasy', player) or state.has_all({'Usada Pekora', 'Shiranui Flare', 'Shirogane Noel', 'Houshou Marine'}, player)),
            Holo8Location("NePoLaBo's Shopping Cart Race", Regions.everyday, "1_1", lambda state: state.has('NePoLaBo', player) or state.has_all({'Yukihana Lamy', 'Shishiro Botan', 'Momosuzu Nene', 'Omaru Polka'}, player)),
            Holo8Location("Biboo Tax", Regions.everyday, "1_2", lambda state: state.has('Hololive Advent', player) or state.has_all({'Shiori Novella', 'Koseki Bijou', 'Nerissa Ravencroft', 'FUWAMOCO'}, player)),
            Holo8Location("Miko's Japanese Lesson", Regions.everyday, "1_3", lambda state: state.has_all({'Hololive Generation 0', 'Hololive CouncilRyS', 'Holoro'}, player) or state.has_all({'Sakura Miko', 'IRyS', 'Anya Melfissa'}, player)),
            Holo8Location("Petting the Koronesuki", Regions.everyday, "1_4", lambda state: state.has('Hololive GAMERS', player) or state.has_all({'Nekomata Okayu', 'Inugami Korone'}, player)),
            Holo8Location("StartEnd", Regions.everyday, "1_5", lambda state: state.has_all({'Hololive Generation 2', 'HoloForce'}, player) or state.has_all({'Minato Aqua', 'Tokoyami Towa'}, player)),
            Holo8Location("Duck ASMR", Regions.everyday, "1_6", lambda state: state.has('Hololive Generation 2', player) or state.has_all({'Yuzuki Choco', 'Oozora Subaru'}, player)),
            Holo8Location("Peeping Matsuri", Regions.everyday, "1_7", lambda state: state.has_all({'Hololive Generation 1', 'Hololive Generation 2'}, player) or state.has_all({'Natsuiro Matsuri', 'Oozora Subaru'}, player)),
            Holo8Location("Luna and the Ducks", Regions.everyday, "1_8", lambda state: state.has_all({'Hololive Generation 2', 'HoloForce'}, player) or state.has_all({'Oozora Subaru', 'Himemori Luna'}, player)),
            Holo8Location("Chloe's Bathtime", Regions.everyday, "1_9", lambda state: state.has('HoloX Secret Society', player) or state.has_all({'Laplus Darknesss', 'Sakamata Chloe'}, player)),
            Holo8Location("Amelia and Smol Ame Behind the Door", Regions.everyday, "1_10", lambda state: state.has('Hololive Myth', player) or state.has('Amelia Watson', player)),
            Holo8Location("Zeta and Iroha's Chat", Regions.everyday, "1_11", lambda state: state.has_all({'HoloX Secret Society', 'Holoh3ro'}, player) or state.has_all({'Kazama Iroha', 'Vestia Zeta'}, player)),
            Holo8Location("Attacked by Ina's Tentacles", Regions.everyday, "1_12", lambda state: state.has('Hololive Myth', player) or state.has('Ninomae Inanis', player)),
            Holo8Location("Home on Time", Regions.everyday, "1_13"),
            Holo8Location("A-chan Working", Regions.everyday, "1_14"),
            Holo8Location("Suisei with a 35P Head", Regions.everyday, "1_15", lambda state: state.has('Hololive Generation 0', player) or state.has('Sakura Miko', player)),
            Holo8Location("Okanyan Kabedon", Regions.everyday, "1_16", lambda state: state.has('Hololive GAMERS', player) or state.has('Nekomata Okayu', player)),
            Holo8Location("Marine's Mosaic Costume", Regions.everyday, "1_17"),
            Holo8Location("Classmate Marine", Regions.everyday, "1_18"),
            Holo8Location("Nekko Plants", Regions.everyday, "1_19", lambda state: state.has('NePoLaBo', player) or state.has('Momosuzu Nene', player)),
            Holo8Location("Chloe's Handwriting", Regions.everyday, "1_20", lambda state: state.has('HoloX Secret Society', player) or state.has('Sakamata Chloe', player)),
            Holo8Location("Stalker Iroha", Regions.everyday, "1_21", lambda state: state.has('HoloX Secret Society', player) or state.has('Kazama Iroha', player)),
            Holo8Location("Lui and the Sleepy Ayame", Regions.everyday, "1_22", lambda state: state.has_all({'Hololive Generation 2', 'HoloX Secret Society'}, player) or state.has_all({'Nakiri Ayame', 'Takane Lui'}, player)),
            Holo8Location("Risu and Hairball Korone", Regions.everyday, "1_23", lambda state: state.has_all({'Hololive GAMERS', 'Area 15'}, player) or state.has_all({'Inugami Korone', 'Ayunda Risu'}, player)),
            Holo8Location("Iofi's Prank", Regions.everyday, "1_24", lambda state: state.has('Area 15', player) or state.has('Airani Iofifteen', player)),
            Holo8Location("Moona on the Moon", Regions.everyday, "1_25", lambda state: state.has('Area 15', player) or state.has('Moona Hoshinova', player)),
            Holo8Location("Kaela and Ckia", Regions.everyday, "1_26", lambda state: state.has('Holoh3ro', player) or state.has('Kaela Kovalskia', player)),
            Holo8Location("Gura's Bathtub", Regions.everyday, "1_27", lambda state: state.has('Hololive Myth', player) or state.has('Gawr Gura', player)),
            Holo8Location("The Oozora Police Chase", Regions.everyday, "1_28", lambda state: state.has_all({'Hololive Generation 2', 'Hololive Myth', 'Hololive CouncilRyS'}, player) or state.has_all({'Oozora Subaru', 'Gawr Gura', 'Hakos Baelz'}, player)),
            Holo8Location("Fauna and the Slaplings", Regions.everyday, "1_29", lambda state: state.has('Hololive CouncilRyS', player) or state.has('Ceres Fauna', player)),
            Holo8Location("Kronii's Udon", Regions.everyday, "1_30", lambda state: state.has('Hololive CouncilRyS', player) or state.has('Ouro Kronii', player)),
            Holo8Location("Watchful Nerissa", Regions.everyday, "1_31", lambda state: state.has('Hololive Advent', player) or state.has('Nerissa Ravencroft', player)),
            Holo8Location("Ririka and her SOSages", Regions.everyday, "1_32", lambda state: state.has('ReGLOSS', player) or state.has('Ichijou Ririka', player)),
            Holo8Location("Hajime and Kanade's Tricycles", Regions.everyday, "1_33", lambda state: state.has('ReGLOSS', player) or state.has_all({'Otonose Kanade', 'Todoroki Hajime'}, player)),
            Holo8Location("Ao Appears", Regions.everyday, "1_34", lambda state: state.has('ReGLOSS', player) or state.has('Hiodoshi Ao', player)),
            Holo8Location("Sana and Yatagarasu", Regions.everyday, "1_35", lambda state: state.has('Hololive CouncilRyS', player) or state.has('Tsukumo Sana', player)),
            Holo8Location("Marine's Asacoco", Regions.everyday, "1_36"),
            Holo8Location("Nodoka Working", Regions.everyday, "1_37"),
            Holo8Location("Suisei and Calliope's Ramen", Regions.everyday, "1_38", lambda state: state.has_all({'Hololive Generation 0', 'Hololive Myth'}, player) or state.has_all({'Hoshimachi Suisei', 'Mori Calliope'}, player)),
            Holo8Location("IRyS and her Tofu", Regions.everyday, "1_39", lambda state: state.has('Hololive CouncilRyS', player) or state.has('IRyS', player)),
            Holo8Location("Mio and Fubuki", Regions.everyday, "1_40", lambda state: state.has_all({'Hololive Generation 1', 'Hololive GAMERS'}, player) or state.has_all({'Shirakami Fubuki', 'Ookami Mio'}, player)),
            Holo8Location("Justice's Japanese Lesson", Regions.everyday, "1_41", lambda state: state.has_all({'Hololive Generation 0', 'Hololive Justice'}, player) or state.has_all({'Sakura Miko', 'Elizabeth Rose Bloodflame', 'Gigi Murin', 'Cecilia Immergreen', 'Raora Panthera'}, player)),
            Holo8Location("Mukirose Captures Dinosaur Mikochi", Regions.everyday, "1_42", lambda state: state.has_all({'Hololive Generation 0', 'Hololive Generation 1'}, player) or state.has_all({'Sakura Miko', 'Aki Rosenthal'}, player)),
            Holo8Location("Haachama Cooking", Regions.everyday, "1_43", lambda state: state.has('Hololive Generation 1', player) or state.has('Akai Haato', player)),
            Holo8Location("Korone Chasing Koronesuki", Regions.everyday, "1_44", lambda state: state.has('Hololive GAMERS', player) or state.has('Inugami Korone', player)),
            Holo8Location("Excited Fubuki Watching", Regions.everyday, "1_45", lambda state: state.has('Hololive Generation 1', player) or state.has('Shirakami Fubuki', player)),
            Holo8Location("Inconspicuous Aqua", Regions.everyday, "1_46", lambda state: state.has('Hololive Generation 2', player) or state.has('Minato Aqua', player)),
            Holo8Location("Mayonnaise Drinker Koyori", Regions.everyday, "1_47", lambda state: state.has('HoloX Secret Society', player) or state.has('Hakui Koyori', player)),
            Holo8Location("Reine and Tatang", Regions.everyday, "1_48", lambda state: state.has('Holoro', player) or state.has('Pavolia Reine', player)),
            Holo8Location("Kanata's Watermelons", Regions.everyday, "1_49", lambda state: state.has('HoloForce', player) or state.has('Amane Kanata', player)),
            Holo8Location("Kobo's Rainstorm", Regions.everyday, "1_50", lambda state: state.has('Holoh3ro', player) or state.has('Kobo Kanaeru', player)),
            Holo8Location("Amelia's Sweet Potatoes", Regions.everyday, "1_51", lambda state: state.has('Hololive Myth', player) or state.has('Amelia Watson', player)),
            Holo8Location("Laplus in the Window", Regions.everyday, "1_52", lambda state: state.has('HoloX Secret Society', player) or state.has('Laplus Darknesss', player)),
            Holo8Location("Gomoku World Record", Regions.everyday, "1_53", lambda state: state.has_all({'Hololive Generation 0', 'Hololive Generation 1'}, player) or state.has_all({'Sakura Miko', 'Shirakami Fubuki'}, player)),
            Holo8Location("Cardboard Fubuki", Regions.everyday, "1_54", lambda state: state.has('Hololive Generation 1', player) or state.has('Shirakami Fubuki', player)),
            Holo8Location("Koronesuki Poster", Regions.everyday, "1_55", lambda state: state.has_all({'Hololive GAMERS', 'Hololive Fantasy'}, player) or state.has_all({'Inugami Korone', 'Houshou Marine'}, player)),
            Holo8Location("Noel's Gyudon", Regions.everyday, "1_56", lambda state: state.has('Hololive Fantasy', player) or state.has('Shirogane Noel', player)),
            Holo8Location("PekoRap", Regions.everyday, "1_57", lambda state: state.has('Hololive Fantasy', player) or state.has('Usada Pekora', player)),
            Holo8Location("Liverface Lamy", Regions.everyday, "1_58", lambda state: state.has('NePoLaBo', player) or state.has('Yukihana Lamy', player)),
            Holo8Location("Sora and Ankimo", Regions.everyday, "1_59", lambda state: state.has('Hololive Generation 0', player) or state.has('Tokino Sora', player)),
            Holo8Location("Matsuri, Matsurisu, and Ebufulion", Regions.everyday, "1_60", lambda state: state.has('Hololive Generation 1', player) or state.has('Natsuiro Matsuri', player)),
            Holo8Location("Towa and Bibi", Regions.everyday, "1_61", lambda state: state.has('HoloForce', player) or state.has('Tokoyami Towa', player)),
            Holo8Location("Bae and Mr. Squeaks", Regions.everyday, "1_62", lambda state: state.has('Hololive CouncilRyS', player) or state.has('Hakos Baelz', player)),
            Holo8Location("Riona, Niko, and the Tiger", Regions.everyday, "1_63", lambda state: state.has('FLOW GLOW', player) or state.has_all({'Isaki Riona', 'Koganei Niko'}, player)),
            Holo8Location("Chihaya at the Reception Desk", Regions.everyday, "1_64", lambda state: state.has('FLOW GLOW', player) or state.has('Rindo Chihaya', player)),
            Holo8Location("Su and Kanata's Apple Exercise", Regions.everyday, "1_65", lambda state: state.has_all({'HoloForce', 'FLOW GLOW'}, player) or state.has_all({'Amane Kanata', 'Mizumiya Su'}, player)),
            Holo8Location("Roboco Charging", Regions.everyday, "1_66", lambda state: state.has('Hololive Generation 0', player) or state.has('Roboco', player)),
            Holo8Location("Anya and the Ghost", Regions.everyday, "1_67", lambda state: state.has('Holoro', player) or state.has('Anya Melfissa', player)),
            Holo8Location("Shirakami Pineapple", Regions.everyday, "1_68", lambda state: state.has_all({'Hololive Generation 1', 'Hololive Fantasy'}, player) or state.has_all({'Shirakami Fubuki', 'Shiranui Flare'}, player)),
            Holo8Location("Shion and Aqua", Regions.everyday, "1_69", lambda state: state.has('Hololive Generation 2', player) or state.has_all({'Minato Aqua', 'Murasaki Shion'}, player)),
            Holo8Location("Shion's Stolen Towel", Regions.everyday, "1_70", lambda state: state.has_all({'Hololive Generation 2', 'HoloX Secret Society'}, player) or state.has_all({'Murasaki Shion', 'Sakamata Chloe'}, player)),
            Holo8Location("Generation 2's Dance", Regions.everyday, "1_71", lambda state: state.has('Hololive Generation 2', player) or state.has_all({'Minato Aqua', 'Murasaki Shion', 'Nakiri Ayame', 'Yuzuki Choco', 'Oozora Subaru'}, player)),
            Holo8Location("Shion and Shiokko", Regions.everyday, "1_72", lambda state: state.has('Hololive Generation 2', player) or state.has('Murasaki Shion', player)),
            Holo8Location("Menya Botan", Regions.everyday, "1_73", lambda state: state.has('NePoLaBo', player) or state.has_all({'Yukihana Lamy', 'Shishiro Botan', 'Momosuzu Nene', 'Omaru Polka'}, player)),
            Holo8Location("Anya and Toaster-kun", Regions.everyday, "1_74", lambda state: state.has('Holoro', player) or state.has('Anya Melfissa', player)),
            Holo8Location("Watame's Sheep Shearing", Regions.everyday, "1_75", lambda state: state.has('HoloForce', player) or state.has('Tsunomaki Watame', player)),
            Holo8Location("Generation 4 and the Splits", Regions.everyday, "1_76", lambda state: state.has('HoloForce', player) or state.has_all({'Amane Kanata', 'Tsunomaki Watame', 'Kiryu Coco', 'Tokoyami Towa', 'Himemori Luna'}, player)),
            Holo8Location("AZKi's Ice Cream Bar", Regions.everyday, "1_77", lambda state: state.has('Hololive Generation 0', player) or state.has('AZKi', player)),
        )

        #Interactive anomalies.
        #These are explicitly sent out for interacting with interactive anomalies.
        if not options or options.enable_interactive_anomalies:
            locations +=(
                Holo8Location("Enjoy A Bowl of Char Siu Ramen", Regions.everyday, "special_menyabotan", lambda state: state.has('NePoLaBo', player) or state.has_all({'Yukihana Lamy', 'Shishiro Botan', 'Momosuzu Nene', 'Omaru Polka'}, player)),
                Holo8Location("Toasting Toaster-Kun's Toast", Regions.everyday, "special_anyatoaster", lambda state: state.has('Holoro', player) or state.has('Anya Melfissa', player)),
                Holo8Location("Situational Voice at the Ice Cream Bar", Regions.everyday, "special_azkibar", lambda state: state.has('Hololive Generation 0', player) or state.has('AZKi', player)),
            )
    
    #Goal Location
    locations.append(Holo8Location("Escaped", Regions.normal, "Goal", lambda state: state.has_all({'Mikodanye', 'Taranchama'}, player)))

    return locations
