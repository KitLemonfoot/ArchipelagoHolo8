from typing import List
from dataclasses import dataclass

@dataclass
class Holo8Region:
    short_name: str
    full_name: str

class Regions:
    normal = Holo8Region("normal", "Normal Anomalies")
    everyday = Holo8Region("everyday", "Everyday Anomalies")

    all_regions: List[Holo8Region] = [
        normal, everyday
    ]