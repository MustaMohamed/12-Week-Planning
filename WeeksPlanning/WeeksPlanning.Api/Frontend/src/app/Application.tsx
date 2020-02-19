import React, { Component } from 'react';
import '../semantic/dist/semantic.min.css';
import { Layout, PlansList } from './components';

class Application extends Component {
  render() {
    return (
      <Layout>
        <p>Application Layout</p>
        <PlansList/>
      </Layout>
    );
  }
}

export default Application;