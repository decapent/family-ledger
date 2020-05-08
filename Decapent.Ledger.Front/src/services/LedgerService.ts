import ILedgerService from "./ILedgerService";
import LedgerEvent from "../models/LedgerEvent";
import axios from 'axios';

export default class LedgerService implements ILedgerService {
    public async getEvents(): Promise<LedgerEvent[]> {
        return await axios.get(`https://localhost:44330/LedgerEvent`)
            .then(response => {
                const dateOptions: Intl.DateTimeFormatOptions = {
                    year: "numeric", month: "numeric", day: "numeric",
                    hour: "2-digit", minute: "2-digit"
                }

                let events: Array<LedgerEvent> = []
                for(let i = 0; i < response.data.length; i++) {
                    const event: LedgerEvent = {
                        Id: response.data[i].id,
                        Date : new Date(response.data[i].date).toLocaleString("en-ca", dateOptions),
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