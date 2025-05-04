from dataclasses import dataclass
from Options import Toggle, Choice, Range, DeathLink, PerGameCommonOptions

class AnomalyTypes(Choice):
    """
    You can choose which type of anomalies you would like to see, including from the base game, Everyday mode, or both.
    """
    display_name = "Anomaly Types"
    option_normal = 0
    option_everyday = 1
    option_both = 2
    default = 0

class NoAnomalyPercentage(Range):
    """
    Percentage chance to land on a floor with no anomaly.
    This does not affect the 2-floor anomaly failsafe.
    It is recommended to keep this value low for syncs, and midrange for asyncs.
    """
    display_name = "No Anomaly Percentage"
    range_start = 0
    range_end = 100
    default = 20

class ReusedAnomalyPercentage(Range):
    """
    Percentage chance during floor shuffle to include floors with anomalies that you have already seen.
    """
    display_name = "Reused Anomaly Percentage"
    range_start = 0
    range_end = 100
    default = 0

class HardAnomalies(Toggle):
    """
    Enable anomalies that are difficult to spot.
    It is recommended to keep this option turned off for syncs.
    """
    display_name = "Hard Anomalies"

class Holo8DeathLink(DeathLink):
    """
    When you die, everyone dies. The reverse is also true.
    """

@dataclass
class Holo8Options(PerGameCommonOptions):
    anomaly_types: AnomalyTypes
    no_anomaly_percentage: NoAnomalyPercentage
    reused_anomaly_percentage: ReusedAnomalyPercentage
    hard_anomalies: HardAnomalies
    death_link: Holo8DeathLink