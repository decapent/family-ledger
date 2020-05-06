import { EventType } from "./EventType";

export default interface LedgerEvent {
    Id : string
    Type : EventType
    Date : string
    Description : string
    Author: string
    City: string
    LedgerImage: string
    LedgerPage: number
}