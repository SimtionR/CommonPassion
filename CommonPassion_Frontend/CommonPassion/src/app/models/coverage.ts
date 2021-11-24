import { Fixtures } from "./fixtures";

export interface Coverage {
    fixtures: Fixtures;
    standings: boolean;
    players: boolean;
    top_scorers: boolean;
    top_assists: boolean;
    top_cards: boolean;
    injuries: boolean;
    predictions: boolean;
    odds: boolean;
}
