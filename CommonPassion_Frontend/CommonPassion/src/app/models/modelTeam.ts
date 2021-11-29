import { League } from "./league";
import { Paging } from "./Paging";

export interface ApiTeam {
    get: string;
    parameters: ParametersTeam;
    errors: any[];
    results: number;
    paging: Paging;
    response: ResponseTeam[]; //ResponseTeam from ApiTeam
}

    export interface ApiAvaialbleSeasons {
      
        response: number[];
        paging: Paging;
    }

    export interface ParametersTeam {
        id: string;
        league: string;
        season: string;
        team: string;
    }


    export interface ResponseTeam // Rp from ApiTeam 
    {
        team: Team ;
        venue: Venue ;
        leagueN: string ;
        season: string; 
        league: League ;
        form: string ;
        fixtures: Fixtures ;
        goals: GoalsT ;
        biggest: Biggest; 
        clean_sheet: Clean_Sheet ;
        failed_to_score: Failed_To_Score ;
        penalty: PenaltyT ;
        lineups: Lineup[];
        //cards: CardsT;;
    }

    export interface Team {
        id: number;
        name: string;
        country: string;
        founded: number;
        national: boolean;
        logo: string;
    }




        export interface Venue {
        id: number;
        name: string;
        address: string;
        city: string;
        capacity: number;
        surface: string;
        image: string;
    }

    export interface LeagueStats {
        id: number;
        name: string;
        country: string;
        logo: string;
        flag: string;
        season: number;
    }



    export interface Fixtures {
        played: Played;
        wins: Wins;
        draws: Draws;
        loses: Loses;
    }

    export interface Played {
        home: number;
        away: number;
        total: number;
    }

    export interface Wins {
        home: number;
        away: number;
        total: number;
    }

    export interface Draws {
        home: number;
        away: number;
        total: number;
    }

    export interface Loses {
        home: number;
        away: number;
        total: number;
    }

    export interface GoalsT {
        _for: For;
        against: Against;
    }

    export interface For {
        total: Total;
        average: Average;
        // minute: Minute;
    }

    export interface Total {
        home: number;
        away: number;
        total: number;
    }

    export interface Average {
        home: string;
        away: string;
        total: string;
    }

    /* export interface Minute {
         _015: _015;
         _1630: _1630;
         _3145: _3145;
         _4660: _4660;
         _6175: _6175;
         _7690: _7690;
         _91105: _91105;
         _106120: _106120;
     }

     export interface _015 {
         total: number;
         percentage: string;
     }

     export interface _1630 {
         total: number;
         percentage: string;
     }

     export interface _3145 {
         total: number;
         percentage: string;
     }

     export interface _4660 {
         total: number;
         percentage: string;
     }

     export interface _6175 {
         total: number;
         percentage: string;
     }

     export interface _7690 {
         total: number;
         percentage: string;
     }

     export interface _91105 {
         total: number;
         percentage: string;
     }

     export interface _106120 {
         total: any;
         percentage: any;
     }
 */
    export interface Against {
        total: Total1;
        //average: Average1;
        //minute: Minute1;
    }

    export interface Total1 {
        home: number;
        away: number;
        total: number;
    }

    /*export interface Average1 {
        home: string;
        away: string;
        total: string;
    }

    export interface Minute1 {
        _015: _0151;
        _1630: _16301;
        _3145: _31451;
        _4660: _46601;
        _6175: _61751;
        _7690: _76901;
        _91105: _911051;
        _106120: _1061201;
    }

    export interface _0151 {
        total: number;
        percentage: string;
    }

    export interface _16301 {
        total: number;
        percentage: string;
    }

    export interface _31451 {
        total: number;
        percentage: string;
    }

    export interface _46601 {
        total: number;
        percentage: string;
    }

    export interface _61751 {
        total: number;
        percentage: string;
    }

    export interface _76901 {
        total: number;
        percentage: string;
    }

    export interface _911051 {
        total: number;
        percentage: string;
    }

    export interface _1061201 {
        total: any;
        percentage: any;
    }*/

    export interface Biggest {
        streak: Streak;
        wins: Wins1;
        loses: Loses1;
        goals: Goals1;
    }

    export interface Streak {
        wins: number;
        draws: number;
        loses: number;
    }

    export interface Wins1 {
        home: string;
        away: string;
    }

    export interface Loses1 {
        home: string;
        away: any;
    }

    export interface Goals1 {
        _for: For1;
        against: Against1;
    }

    export interface For1 {
        home: number;
        away: number;
    }

    export interface Against1 {
        home: number;
        away: number;
    }

    export interface Clean_Sheet {
        home: number;
        away: number;
        total: number;
    }

    export interface Failed_To_Score {
        home: number;
        away: number;
        total: number;
    }

    export interface PenaltyT {
        scored: Scored;
        missed: Missed;
        total: number;
    }

    export interface Scored {
        total: number;
        percentage: string;
    }

    export interface Missed {
        total: number;
        percentage: string;
    }

    /*    export interface CardsT {
            yellow: Yellow;
            red: Red;
        }

        export interface Yellow {
            _015: _0152;
            _1630: _16302;
            _3145: _31452;
            _4660: _46602;
            _6175: _61752;
            _7690: _76902;
            _91105: _911052;
            _106120: _1061202;
        }

        export interface _0152 {
            total: number;
            percentage: string;
        }

        export interface _16302 {
            total: number;
            percentage: string;
        }

        export interface _31452 {
            total: number;
            percentage: string;
        }

        export interface _46602 {
            total: number;
            percentage: string;
        }

        export interface _61752 {
            total: number;
            percentage: string;
        }

        export interface _76902 {
            total: number;
            percentage: string;
        }

        export interface _911052 {
            total: any;
            percentage: any;
        }

        export interface _1061202 {
            total: any;
            percentage: any;
        }

        export interface Red {
            _015: _0153;
            _1630: _16303;
            _3145: _31453;
            _4660: _46603;
            _6175: _61753;
            _7690: _76903;
            _91105: _911053;
            _106120: _1061203;
        }

        export interface _0153 {
            total: any;
            percentage: any;
        }

        export interface _16303 {
            total: number;
            percentage: string;
        }

        export interface _31453 {
            total: any;
            percentage: any;
        }

        export interface _46603 {
            total: any;
            percentage: any;
        }

        export interface _61753 {
            total: any;
            percentage: any;
        }

        export interface _76903 {
            total: any;
            percentage: any;
        }

        export interface _911053 {
            total: any;
            percentage: any;
        }

        export interface _1061203 {
            total: any;
            percentage: any;
        }*/

    export interface Lineup {
        formation: string;
        played: number;
    }
