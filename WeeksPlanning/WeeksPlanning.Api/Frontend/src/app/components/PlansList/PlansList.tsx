import React, { Component } from 'react';
import { Container, Placeholder, Table } from 'semantic-ui-react';

type Props = {

}

type State = {
  plans: any[];
}

class PlansList extends Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.state = {
      plans: [],
    };
  }

  async componentDidMount(): Promise<void> {
    const response = await fetch('/api/plans');
    const data: any[] = await response.json();
    console.log(data);
    this.setState({
      plans: data.map((plan, idx) => ({
        name: plan.name,
        durationInWeeks: plan.durationInWeeks,
        startingDate: new Date(plan.startingDateUtc),
        createdByUser: plan.createdByUser.name,
      })),
    });
  };

  render() {
    return (
      <Container>
        {!this.state.plans && <Placeholder>
            <Placeholder.Line/>
            <Placeholder.Line/>
            <Placeholder.Line/>
            <Placeholder.Line/>
            <Placeholder.Line/>
        </Placeholder>}
        {this.state.plans && <Table celled>
            <Table.Header>
                <Table.Row>
                    <Table.HeaderCell>Plan Name</Table.HeaderCell>
                    <Table.HeaderCell>Starting Date</Table.HeaderCell>
                    <Table.HeaderCell>Duration In Weeks</Table.HeaderCell>
                    <Table.HeaderCell>Created By User</Table.HeaderCell>
                </Table.Row>
            </Table.Header>

            <Table.Body>
              {this.state.plans.map((plan, idx) =>
                <Table.Row key={idx}>
                  <Table.Cell>{plan.name}</Table.Cell>
                  <Table.Cell>{plan.startingDate.toLocaleDateString()}</Table.Cell>
                  <Table.Cell>{plan.durationInWeeks}</Table.Cell>
                  <Table.Cell>{plan.createdByUser}</Table.Cell>
                </Table.Row>,
              )}
            </Table.Body>
        </Table>}
      </Container>
    );
  }
}

export default PlansList;