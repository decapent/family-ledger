import * as React from "react";
import { VerticalTimeline } from "react-vertical-timeline-component";
import LedgerEvent from "../../models/LedgerEvent";
import ILedgerService from "../../services/ILedgerService";
import LedgerService from "../../services/LedgerService";
import { TimelineEvent } from "./TimelineEvent";

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
            return (<div>Loading...</div>);
        }

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