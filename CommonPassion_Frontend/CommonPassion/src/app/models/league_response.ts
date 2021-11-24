import { Country } from "./country";
import { League } from "./league";
import { Season } from "./season";

export interface LeagueResponse {
    league: League;
    country: Country;
    seasons: Season[];
}