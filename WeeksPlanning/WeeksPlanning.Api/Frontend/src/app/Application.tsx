import React, { Component, ComponentClass } from 'react';
import '../semantic/dist/semantic.min.css';
import { Layout } from './components';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AppRouter from './router';
import { RouteNames } from './types/routes';

class Application extends Component<any, any> {
  render() {
    return (
      <Router>
        <Layout>
          <Switch>
            {Object.values(RouteNames).filter(r => r !== RouteNames.Base).map((route, idx) => {
              return <Route key={idx}
                            exact={AppRouter.getRouteDetails(route).Exact}
                            path={AppRouter.getRouteDetails(route).Path}
                            component={AppRouter.getRouteDetails(route).Component as ComponentClass}/>;
            })}
            <Route path={'*'}>
              <h3>Not Found</h3></Route>
          </Switch>
        </Layout>
      </Router>
    );
  }
}

export default Application;