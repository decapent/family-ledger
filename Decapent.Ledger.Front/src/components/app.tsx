import * as React from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

import Timeline from "./timeline/Timeline";

// Styles
import 'react-vertical-timeline-component/style.min.css';
import './App.scss';

export interface IAppProps { }

export default function IApp(props: IAppProps) {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Ligne du temps</Link>
            </li>
            <li>
              <Link to="/stats">Statistiques</Link>
            </li>
          </ul>
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/stats">
            <About />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
      </div>
    </Router>
  );

  function Home() {
    return <Timeline tabarnak=""></Timeline>;
  }
  
  function About() {
    return <h2>Section de statistiques</h2>;
  }
  
}

