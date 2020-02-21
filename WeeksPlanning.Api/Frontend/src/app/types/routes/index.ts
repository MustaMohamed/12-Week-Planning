import { ReactNode } from 'react';

export enum RouteNames {
  Base = '/',
  Home = '/home',
  About = '/about',
  Plans = '/plans',
}

export type AppRouteDetails = {
  Name: string;
  Path: string | string[];
  Exact: boolean;
  Secret: boolean;
  Component?: ReactNode
}

export type GetRouteDetails = (routeName: RouteNames) => AppRouteDetails;
