import * as React from "react";
import LedgerEvent from "../../models/LedgerEvent";
import { VerticalTimeline, VerticalTimelineElement } from "react-vertical-timeline-component";
import { TimelineEvent } from "./TimelineEvent";
import { EventType } from "../../models/EventType";

export interface ITimelineState {
    readonly events: Array<LedgerEvent>
}

export interface ITimelineProps {
    tabarnak: string
}

export default class Timeline extends React.Component<ITimelineProps, ITimelineState> {
    constructor(props: ITimelineProps) {
        super(props);

        let event: LedgerEvent = {
            Author: "Autheur",
            City: "Ville",
            Date: "1850/04/12",
            Description: "Description",
            Id: "MonId",
            LedgerImage: "Une image",
            LedgerPage: 42,
            Type: EventType.Marriage
        }

        this.state = {
            events: [event, event, event, event, event]
        };
    }

    // The render function, where we actually tell the browser what it should show
    render() {
        return (
            <div>
                <VerticalTimeline>
                    {this.state.events.map((ledgerEvent, i) => {
                        return <TimelineEvent model={ledgerEvent}></TimelineEvent>
                    })}
                </VerticalTimeline>
            </div>
        )
    }
}