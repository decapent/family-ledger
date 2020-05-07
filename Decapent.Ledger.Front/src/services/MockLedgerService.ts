import ILedgerService from "./ILedgerService";
import LedgerEvent from "../models/LedgerEvent";
import axios from 'axios';
import { EventType } from "../models/EventType";

export default class LedgerService implements ILedgerService {

    private readonly _events: Array<LedgerEvent> = [];
    private readonly _mockEvent: LedgerEvent = {
            Author: "Patrick Lavallee 2e",
            City: "Saint-Paul de l'ile au noix",
            Date: "1850/04/12",
            Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus at viverra purus, sed vulputate lorem. Aliquam est nunc, iaculis non leo vel, tristique vestibulum libero. Quisque et tempor ex. Sed vestibulum lorem ac lacus rhoncus, at iaculis lorem consectetur. Sed condimentum porta arcu pharetra auctor. Sed at volutpat dui, quis hendrerit nisi. Maecenas scelerisque suscipit lacus, quis molestie nibh aliquet vitae. Vivamus nisi turpis, euismod at magna ut, ultricies ultrices quam. Etiam eu hendrerit arcu, ut laoreet massa. In erat nunc, dapibus non velit vitae, maximus ullamcorper quam. Cras turpis dolor, venenatis interdum velit id, congue porta massa. Cras blandit dui eu magna tempus porta. Aenean vitae mi consectetur, ultricies leo at, auctor nulla. Vivamus eu magna a metus pulvinar tincidunt.",
            Id: "MonId",
            LedgerImage: "Une image",
            LedgerPage: 42,
            Type: EventType.Marriage
    }

    constructor() {
        for(let i = 0; i < 10; i++) {
            this._events.push(this._mockEvent);
        }
    }

    public async getEvents(): Promise<Array<LedgerEvent>> {
        return await new Promise<Array<LedgerEvent>>((resolve) => {
            resolve(this._events)
        });
    }
}