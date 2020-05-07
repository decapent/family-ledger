import * as React from "react";
import LedgerEvent from "../../models/LedgerEvent";
import { VerticalTimeline, VerticalTimelineElement } from "react-vertical-timeline-component";
import { TimelineEvent } from "./TimelineEvent";
import { EventType } from "../../models/EventType";
import ILedgerService from "../../services/ILedgerService";
import LedgerService from "../../services/LedgerService";
import MockLedgerService from "../../services/MockLedgerService";
import axios from 'axios';



export interface ITimelineState {
    readonly events: Array<LedgerEvent>
    readonly shouldRender: boolean
}

export interface ITimelineProps {
    tabarnak: string
}

export default class Timeline extends React.Component<ITimelineProps, ITimelineState> {

    private _ledgerService: ILedgerService;

    constructor(props: ITimelineProps) {
        super(props);

        this._ledgerService = new LedgerService();

        this.state = {
            events: [],
            shouldRender: false
        };
    }

    async componentDidMount() {
        this.setState({
            events: await this._ledgerService.getEvents(),
            shouldRender: true
        })
    }

    render() {
        if (!this.state.shouldRender) {
            console.log("Ca arrive tu que c<est trop pauvre pour pas render ?");
            return (<div>Loading...</div>);
        }

        console.log("Ya tu fucking de quoi dans ce array la ?", this.state.events);
        return (
            <div>
                <VerticalTimeline>
                    {this.state.events.map((ledgerEvent, i) => {
                        return <TimelineEvent model={ledgerEvent} key={i}></TimelineEvent>
                    })}
                </VerticalTimeline>
            </div>
        )
    }
}