import { Paging } from "./RootLeague";
import {League} from './RootLeague';
import { Team } from "./api_team";


export interface ApiStanding {
    get: string;
    parameters: ParametersStanding;
    errors: any[];
    results: number;
    paging: Paging;
    response: ResponseStanding[];
}

export interface ParametersStanding {
    league: string;
    season: string;
}


export interface ResponseStanding {
    league: League;
}


export interface Standing {
    rank: number;
    team: Team;
    points: number;
    goalsDiff: number;
    group: string;
    form: string;
    status: string;
    description: string;
    all: All;
    home: Home;
    away: Away;
    update: Date | string;
}



export interface All {
    played: number;
    win: number;
    draw: number;
    lose: number;
    goals: GoalsTotal;
}

export interface GoalsTotal {
    _for: number;
    against: number;
}

export interface Home {
    played: number;
    win: number;
    draw: number;
    lose: number;
    goals: GoalsHome;
}

export interface GoalsHome {
    _for: number;
    against: number;
}

export interface Away {
    played: number;
    win: number;
    draw: number;
    lose: number;
    goals: GoalsAway;
}

export interface GoalsAway {
    _for: number;
    against: number ;
}