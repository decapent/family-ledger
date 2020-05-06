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
            City: "Saint-Paul de l'ile au noix",
            Date: "1850/04/12",
            Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus at viverra purus, sed vulputate lorem. Aliquam est nunc, iaculis non leo vel, tristique vestibulum libero. Quisque et tempor ex. Sed vestibulum lorem ac lacus rhoncus, at iaculis lorem consectetur. Sed condimentum porta arcu pharetra auctor. Sed at volutpat dui, quis hendrerit nisi. Maecenas scelerisque suscipit lacus, quis molestie nibh aliquet vitae. Vivamus nisi turpis, euismod at magna ut, ultricies ultrices quam. Etiam eu hendrerit arcu, ut laoreet massa. In erat nunc, dapibus non velit vitae, maximus ullamcorper quam. Cras turpis dolor, venenatis interdum velit id, congue porta massa. Cras blandit dui eu magna tempus porta. Aenean vitae mi consectetur, ultricies leo at, auctor nulla. Vivamus eu magna a metus pulvinar tincidunt.",
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