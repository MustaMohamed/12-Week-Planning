import { AppRouteDetails, GetRouteDetails, RouteNames } from '../types';
import { PlansList } from '../components';

const AppRoutes: { [key: string]: AppRouteDetails } = {
  [RouteNames.Home]: {
    Name: RouteNames.Home,
    Path: [RouteNames.Base, RouteNames.Home],
    Exact: true,
    Secret: false,
  },
  [RouteNames.About]: {
    Name: RouteNames.About,
    Path: RouteNames.About,
    Exact: false,
    Secret: false,
  },
  [RouteNames.Plans]: {
    Name: RouteNames.Plans,
    Path: RouteNames.Plans,
    Exact: false,
    Secret: false,
    Component: PlansList,
  },
};

export const getRouteDetails: GetRouteDetails = (routeName: RouteNames) => AppRoutes[routeName];


export default {
  getRouteDetails,
};