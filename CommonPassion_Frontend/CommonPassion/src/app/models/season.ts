import { Coverage } from "./coverage";

export interface Season {
    year: number;
    start: string;
    end: string;
    current: boolean;
    coverage: Coverage;
}