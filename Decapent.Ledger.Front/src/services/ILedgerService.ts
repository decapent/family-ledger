import LedgerEvent from "../models/LedgerEvent";

export default interface ILedgerService {
    getEvents() : Promise<LedgerEvent[]>
}