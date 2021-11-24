import { LeagueResponse } from "./league_response";
import { Parameters } from "./Parameters";
import { Paging } from "./Paging";

export interface RootLeague {
    response: LeagueResponse[];
    parameters: Parameters;
    paging: Paging;
    
 
}