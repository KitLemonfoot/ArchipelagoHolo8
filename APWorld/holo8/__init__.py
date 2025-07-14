from typing import Dict, Any
from worlds.AutoWorld import WebWorld, World
from BaseClasses import Tutorial, Region, Location, Entrance, Item, ItemClassification
from .Options import Holo8Options
from .Items import base_id, item_list
from .Locations import get_location_data
from .Regions import Regions

class Holo8Web(WebWorld):
    theme = "stone"
    tutorials = [Tutorial(
        "Multiworld Setup Guide",
        "A guide to setting up the holo8 game for use with Archipelago.",
        "English",
        "holo8_en.md",
        "holo8/en",
        ["KitLemonfoot"]
    )]

class Holo8Item(Item):
    game = "holo8"

class Holo8Location(Location):
    game = "holo8"

class Holo8World(World):
    """
    holo8 is an Exit8-like game based around the Hololive idol group released under the HoloIndie project by frog blend. 
    Set in Hololive's temporary office, you are tasked with reaching the first floor of an endlessly looping office building while detecting and avoiding anomalies.
    """

    game = "holo8"

    options_dataclass = Holo8Options
    options: Holo8Options
    web = Holo8Web()

    item_name_to_id = {item.name: (base_id + index) for index, item in enumerate(item_list)}
    location_name_to_id = {loc.name: (base_id + index) for index, loc in enumerate(get_location_data(-1, None, True, True))}


    def __init__(self, multiworld, player):
        super(Holo8World, self).__init__(multiworld, player)
        self.game_id_to_long: Dict[str, int] = {}
        self.doNormal = True
        self.doEveryday = True
        

    def create_item(self, name: str, anomalyTypes=2) -> Holo8Item:
        item_id: int = self.item_name_to_id[name]
        id = item_id - base_id
        if(self.options.anomaly_types.value<2 and (anomalyTypes!=self.options.anomaly_types.value and anomalyTypes!=2)):
            classification = ItemClassification.filler
        else:
            classification = item_list[id].classification
        return Holo8Item(name, classification, item_id, self.player)
    

    def create_regions(self):

        player = self.player
        multiworld = self.multiworld

        #Determine what locations to add.
        self.doNormal = self.options.anomaly_types%2==0
        self.doEveryday = self.options.anomaly_types>0

        #Region handler
        menu = Region("Menu", player, multiworld)
        for r in Regions.all_regions:
            multiworld.regions += [Region(r.full_name, player, multiworld)]
            menu.add_exits({r.full_name})
        multiworld.regions.append(menu)

        #Handle locations.
        for loc in get_location_data(player, self.options, self.doNormal, self.doEveryday):
            id = self.location_name_to_id[loc.name]
            self.game_id_to_long[loc.game_id] = id
            region: Region = self.get_region(loc.region.full_name)
            location = Holo8Location(player, loc.name, id, region)
            if loc.logic:
                location.access_rule = loc.logic
            region.locations.append(location)

        #Handle goal.
        victory: Location = self.get_location("Escaped")
        victory.place_locked_item(self.create_item("Shredded Ofuda Tags", 2))
        multiworld.completion_condition[player] = lambda state: state.has("Shredded Ofuda Tags", player)
   

    def create_items(self):
        pool=[]

        #Handle static items.
        for item in item_list:
            if(item.name=="Shredded Ofuda Tags" or item.name=="Nothing"):
                continue
            if(item.itemType != self.options.talentsanity.value and item.itemType!=2):
                continue
            pool.append(self.create_item(item.name, item.anomalyTypes))

        #Handle junk items.
        junk = len(self.multiworld.get_unfilled_locations(self.player)) - len(pool)
        for _ in range(junk):
            pool.append(self.create_item("Nothing", 2))

        self.multiworld.itempool += pool

    def fill_slot_data(self) -> Dict[str, Any]:
        slot_data: Dict[str, Any] = {
            "version": "0.2.1",
            "locations": self.game_id_to_long,
            "AnomalyTypes": self.options.anomaly_types.value,
            "NoAnomalyPercentage": self.options.no_anomaly_percentage.value,
            "ReusedAnomalyPercentage": self.options.reused_anomaly_percentage.value,
            "HardAnomalies": bool(self.options.hard_anomalies.value),
            "death_link": bool(self.options.death_link),
            "DeathLinkOnWrongElevator": bool(self.options.deathlink_on_wrong_elevator.value)
        }
        return slot_data