from typing import List, Optional
from dataclasses import dataclass
from enum import Enum
from BaseClasses import ItemClassification

#If you think this represents anything other than the game name, go fuck yourself.
base_id = 888888

@dataclass
class Holo8Item:
    classification: ItemClassification
    name: str
    itemType: int
    anomalyTypes: int

#Base item list
item_list: List[Holo8Item] = [

    #Hololive Generations
    Holo8Item(ItemClassification.progression, "Hololive Generation 0", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive Generation 1", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive Generation 2", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive GAMERS", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive Fantasy", 0, 2),
    Holo8Item(ItemClassification.progression, "HoloForce", 0, 2),
    Holo8Item(ItemClassification.progression, "NePoLaBo", 0, 2),
    Holo8Item(ItemClassification.progression, "HoloX Secret Society", 0, 2),
    Holo8Item(ItemClassification.progression, "ReGLOSS", 0, 2),
    Holo8Item(ItemClassification.progression, "FLOW GLOW", 0, 2),
    Holo8Item(ItemClassification.progression, "Area 15", 0, 1),
    Holo8Item(ItemClassification.progression, "Holoro", 0, 2),
    Holo8Item(ItemClassification.progression, "Holoh3ro", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive Myth", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive CouncilRyS", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive Advent", 0, 2),
    Holo8Item(ItemClassification.progression, "Hololive Justice", 0, 2),

    #Hololive Members
    Holo8Item(ItemClassification.progression, "Tokino Sora", 1, 2),
    Holo8Item(ItemClassification.progression, "Roboco", 1, 2),
    Holo8Item(ItemClassification.progression, "Sakura Miko", 1, 2),
    Holo8Item(ItemClassification.progression, "Hoshimachi Suisei", 1, 0),
    Holo8Item(ItemClassification.progression, "AZKi", 1, 2),
    Holo8Item(ItemClassification.progression, "Aki Rosenthal", 1, 2),
    Holo8Item(ItemClassification.progression, "Akai Haato", 1, 2),
    Holo8Item(ItemClassification.progression, "Shirakami Fubuki", 1, 2),
    Holo8Item(ItemClassification.progression, "Natsuiro Matsuri", 1, 1),
    Holo8Item(ItemClassification.progression, "Minato Aqua", 1, 2),
    Holo8Item(ItemClassification.progression, "Murasaki Shion", 1, 2),
    Holo8Item(ItemClassification.progression, "Nakiri Ayame", 1, 1),
    Holo8Item(ItemClassification.progression, "Yuzuki Choco", 1, 2),
    Holo8Item(ItemClassification.progression, "Oozora Subaru", 1, 2),
    Holo8Item(ItemClassification.progression, "Ookami Mio", 1, 2),
    Holo8Item(ItemClassification.progression, "Nekomata Okayu", 1, 1),
    Holo8Item(ItemClassification.progression, "Inugami Korone", 1, 2),
    Holo8Item(ItemClassification.progression, "Usada Pekora", 1, 2),
    Holo8Item(ItemClassification.progression, "Shiranui Flare", 1, 1),
    Holo8Item(ItemClassification.progression, "Shirogane Noel", 1, 1),
    Holo8Item(ItemClassification.progression, "Houshou Marine", 1, 2),
    Holo8Item(ItemClassification.progression, "Amane Kanata", 1, 2),
    Holo8Item(ItemClassification.progression, "Tsunomaki Watame", 1, 2),
    Holo8Item(ItemClassification.progression, "Kiryu Coco", 1, 2),
    Holo8Item(ItemClassification.progression, "Tokoyami Towa", 1, 1),
    Holo8Item(ItemClassification.progression, "Himemori Luna", 1, 1),
    Holo8Item(ItemClassification.progression, "Yukihana Lamy", 1, 1),
    Holo8Item(ItemClassification.progression, "Momosuzu Nene", 1, 2),
    Holo8Item(ItemClassification.progression, "Shishiro Botan", 1, 2),
    Holo8Item(ItemClassification.progression, "Omaru Polka", 1, 2),
    Holo8Item(ItemClassification.progression, "Laplus Darknesss", 1, 1),
    Holo8Item(ItemClassification.progression, "Takane Lui", 1, 1),
    Holo8Item(ItemClassification.progression, "Hakui Koyori", 1, 2),
    Holo8Item(ItemClassification.progression, "Sakamata Chloe", 1, 1),
    Holo8Item(ItemClassification.progression, "Kazama Iroha", 1, 1),
    Holo8Item(ItemClassification.progression, "Hiodoshi Ao", 1, 2),
    Holo8Item(ItemClassification.progression, "Otonose Kanade", 1, 2),
    Holo8Item(ItemClassification.progression, "Ichijou Ririka", 1, 2),
    Holo8Item(ItemClassification.progression, "Juufuutei Raden", 1, 0),
    Holo8Item(ItemClassification.progression, "Todoroki Hajime", 1, 1),
    Holo8Item(ItemClassification.progression, "Isaki Riona", 1, 1),
    Holo8Item(ItemClassification.progression, "Koganei Niko", 1, 1),
    Holo8Item(ItemClassification.progression, "Mizumiya Su", 1, 1),
    Holo8Item(ItemClassification.progression, "Rindo Chihaya", 1, 1),
    Holo8Item(ItemClassification.progression, "Kikirara Vivi", 1, 0),
    Holo8Item(ItemClassification.progression, "Ayunda Risu", 1, 1),
    Holo8Item(ItemClassification.progression, "Moona Hoshinova", 1, 1),
    Holo8Item(ItemClassification.progression, "Airani Iofifteen", 1, 1),
    Holo8Item(ItemClassification.progression, "Kureiji Ollie", 1, 0),
    Holo8Item(ItemClassification.progression, "Anya Melfissa", 1, 1),
    Holo8Item(ItemClassification.progression, "Pavolia Reine", 1, 1),
    Holo8Item(ItemClassification.progression, "Vestia Zeta", 1, 1),
    Holo8Item(ItemClassification.progression, "Kaela Kovalskia", 1, 2),
    Holo8Item(ItemClassification.progression, "Kobo Kanaeru", 1, 1),
    Holo8Item(ItemClassification.progression, "Mori Calliope", 1, 1),
    Holo8Item(ItemClassification.progression, "Takanashi Kiara", 1, 0),
    Holo8Item(ItemClassification.progression, "Ninomae Inanis", 1, 1),
    Holo8Item(ItemClassification.progression, "Gawr Gura", 1, 1),
    Holo8Item(ItemClassification.progression, "Amelia Watson", 1, 1),
    Holo8Item(ItemClassification.progression, "IRyS", 1, 1),
    Holo8Item(ItemClassification.progression, "Tsukumo Sana", 1, 1),
    Holo8Item(ItemClassification.progression, "Ceres Fauna", 1, 1),
    Holo8Item(ItemClassification.progression, "Ouro Kronii", 1, 1),
    Holo8Item(ItemClassification.progression, "Nanashi Mumei", 1, 0),
    Holo8Item(ItemClassification.progression, "Hakos Baelz", 1, 1),
    Holo8Item(ItemClassification.progression, "Shiori Novella", 1, 1),
    Holo8Item(ItemClassification.progression, "Koseki Bijou", 1, 1),
    Holo8Item(ItemClassification.progression, "Nerissa Ravencroft", 1, 1),
    Holo8Item(ItemClassification.progression, "FUWAMOCO", 1, 2),
    Holo8Item(ItemClassification.progression, "Elizabeth Rose Bloodflame", 1, 1),
    Holo8Item(ItemClassification.progression, "Gigi Murin", 1, 2),
    Holo8Item(ItemClassification.progression, "Cecilia Immergreen", 1, 1),
    Holo8Item(ItemClassification.progression, "Raora Panthera", 1, 1),

    #Key items for goal
    Holo8Item(ItemClassification.progression, "Mikodanye", 2, 2),
    Holo8Item(ItemClassification.progression, "Taranchama", 2, 2),

    #Filler
    Holo8Item(ItemClassification.filler, "Nothing", 2, 2),

    #Goal item, created here to prevent AP servers from crashing
    Holo8Item(ItemClassification.progression_skip_balancing, "Shredded Ofuda Tags", 2, 2),
    
    ]