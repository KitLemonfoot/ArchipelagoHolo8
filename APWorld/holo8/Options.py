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

class EnableInteractiveAnomalies(Toggle):
    """
    If enabled, this will add checks tied to interacting with certain special anomalies such as Menya Botan and AZKi's Ice Cream Bar.
    """
    display_name = "Enable Interactive Anomalies"

class TalentSanity(Choice):
    """
    You can choose whether to group anomalies by Hololive gen, or by individual talent.
    Generation provides more fluid logic, but introduces a lot of filler.
    Talent has less filler, but has very one-to-one logic.
    """
    display_name = "Talentsanity"
    option_generation = 0
    option_talent = 1
    default = 1


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
    When you die, everyone dies. The reverse is also true (you will immediately be sent back to Floor 8).
    """

class DeathLinkOnWrongElevator(Toggle):
    """
    If enabled, will also send a DeathLink if you board the wrong elevator.
    Will have no effect if DeathLink is disabled.
    """
    display_name = "DeathLink On Wrong Elevator"

@dataclass
class Holo8Options(PerGameCommonOptions):
    anomaly_types: AnomalyTypes
    enable_interactive_anomalies: EnableInteractiveAnomalies
    talentsanity: TalentSanity
    no_anomaly_percentage: NoAnomalyPercentage
    reused_anomaly_percentage: ReusedAnomalyPercentage
    hard_anomalies: HardAnomalies
    death_link: Holo8DeathLink
    deathlink_on_wrong_elevator: DeathLinkOnWrongElevator