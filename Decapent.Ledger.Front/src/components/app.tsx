import * as React from "react";
import { VerticalTimeline, VerticalTimelineElement  } from 'react-vertical-timeline-component';
import Timeline from "./timeline/Timeline";

// Styles
import 'react-vertical-timeline-component/style.min.css';
import './App.scss';

export interface IAppProps { }

export default function IApp(props: IAppProps) {
  return <Timeline tabarnak=""></Timeline>
}