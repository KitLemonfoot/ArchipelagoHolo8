from typing import List
from dataclasses import dataclass
from enum import Enum
from BaseClasses import ItemClassification

#If you think this represents anything other than the game name, go fuck yourself.
base_id = 888888

@dataclass
class Holo8Item:
    classification: ItemClassification
    name: str

#Base item list
item_list: List[Holo8Item] = [

    #Hololive Generations
    Holo8Item(ItemClassification.progression, "Hololive Generation 0"),
    Holo8Item(ItemClassification.progression, "Hololive Generation 1"),
    Holo8Item(ItemClassification.progression, "Hololive Generation 2"),
    Holo8Item(ItemClassification.progression, "Hololive GAMERS"),
    Holo8Item(ItemClassification.progression, "Hololive Fantasy"),
    Holo8Item(ItemClassification.progression, "HoloForce"),
    Holo8Item(ItemClassification.progression, "NePoLaBo"),
    Holo8Item(ItemClassification.progression, "HoloX Secret Society"),
    Holo8Item(ItemClassification.progression, "ReGLOSS"),
    Holo8Item(ItemClassification.progression, "FLOW GLOW"),
    Holo8Item(ItemClassification.progression, "Area 15"),
    Holo8Item(ItemClassification.progression, "Holoro"),
    Holo8Item(ItemClassification.progression, "Holoh3ro"),
    Holo8Item(ItemClassification.progression, "Hololive Myth"),
    Holo8Item(ItemClassification.progression, "Hololive CouncilRyS"),
    Holo8Item(ItemClassification.progression, "Hololive Advent"),
    Holo8Item(ItemClassification.progression, "Hololive Justice"),

    #Key items for goal
    Holo8Item(ItemClassification.progression, "Mikodanye"),
    Holo8Item(ItemClassification.progression, "Taranchama"),

    #Filler
    Holo8Item(ItemClassification.filler, "Nothing"),

    #Goal item, created here to prevent AP servers from crashing
    Holo8Item(ItemClassification.progression_skip_balancing, "Paper Shreds"),
    
    ]