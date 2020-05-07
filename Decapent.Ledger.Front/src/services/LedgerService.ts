import ILedgerService from "./ILedgerService";
import LedgerEvent from "../models/LedgerEvent";
import axios from 'axios';
import { EventType } from "../models/EventType";

export default class LedgerService implements ILedgerService {
    public async getEvents(): Promise<LedgerEvent[]> {
        return await axios.get(`https://localhost:44330/LedgerEvent`)
            .then(response => {
                let events: Array<LedgerEvent> = []
                for(let i = 0; i < response.data.length; i++) {
                    debugger;
                    const event: LedgerEvent = {
                        Id: response.data[i].id,
                        Date : response.data[i].date,
                        Description: response.data[i].description,
                        Author: response.data[i].author,
                        City: response.data[i].city,
                        Type: response.data[i].type,
                        LedgerPage: response.data[i].ledgerPage,
                        LedgerImage: response.data[i].ledgerImage
                    }

                    events.push(event);
                }

                return events
            });
    }
}