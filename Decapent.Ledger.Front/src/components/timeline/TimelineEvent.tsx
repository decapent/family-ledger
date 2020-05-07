import * as React from 'react'
import LedgerEvent from '../../models/LedgerEvent'
import { VerticalTimelineElement } from 'react-vertical-timeline-component'

type EventProps = {
    model: LedgerEvent
}

export const TimelineEvent = ({ model }: EventProps) =>
    <VerticalTimelineElement
        className="vertical-timeline-element--work"
        contentStyle={{ background: 'rgb(33, 150, 243)', color: '#fff' }}
        contentArrowStyle={{ borderRight: '7px solid  rgb(33, 150, 243)' }}
        date={model.Date}
        iconStyle={{ background: 'rgb(33, 150, 243)', color: '#fff' }}
    >
        <h3 className="vertical-timeline-element-title">{model.Type}</h3>
        <h4 className="vertical-timeline-element-subtitle">{model.City}</h4>
        <h4 className="vertical-timeline-element-subtitle">{model.Author}</h4>
        <p>{model.Description}</p>
    </VerticalTimelineElement>
